using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockAppWebAPI.Repositories
{
	public class UserRepository:IUserRepository
	{
		private readonly StockAppContext _stockAppContext;
		private readonly IConfiguration _configuration;
		public UserRepository(StockAppContext stockAppContext, IConfiguration configuration)
		{
			_stockAppContext = stockAppContext;
			_configuration = configuration;
		}
		public async Task<User?>GetById(int id)
		{
			return await _stockAppContext.Users.FindAsync(id);
		}
		public async Task<User?> GetByUsername(string username)
		{
			return await _stockAppContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
		}
		public async Task<User?> GetByEmail(string email)
		{
			return await _stockAppContext.Users.FirstOrDefaultAsync(u => u.Email == email);
		}
		public async Task<User?> Create (RegisterViewModel registerViewModel)
		{ string sql = "EXECUTE dbo.RegisterUser @username,@password,@email,@phone,@full_name,@date_of_birth,@country";

			IEnumerable<User> result=await _stockAppContext.Users.FromSqlRaw(sql,
				new SqlParameter("@username", registerViewModel.Username ?? ""),
				new SqlParameter("@password", registerViewModel.Password),
				new SqlParameter("@email", registerViewModel.Email),
				new SqlParameter("@phone", registerViewModel.Phone ?? ""),
				new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
				new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
				new SqlParameter("@country", registerViewModel.Country)).ToListAsync();
			User? user = result.FirstOrDefault();
			return user;
		}
		public async Task<string> Login(LoginViewModel loginViewModel)
		{
			string sql = "EXECUTE dbo.CheckLogIn @email,@password";
			IEnumerable<User> result = await _stockAppContext.Users.FromSqlRaw(sql,
				new SqlParameter("@email", loginViewModel.Email),
				new SqlParameter("@password", loginViewModel.Password)
				).ToListAsync();
			User? user=result.FirstOrDefault();
			if(user!=null)
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"] ?? "");
				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
	  {
			new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
			
	  }),
					Expires = DateTime.UtcNow.AddDays(30),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
					
				};

				var token = tokenHandler.CreateToken(tokenDescriptor);
				var tokenString = tokenHandler.WriteToken(token);
				return tokenString; 
			}
			else
			{
				throw new ArgumentException("Wrong email or password");
			}
			
		}
	}
}

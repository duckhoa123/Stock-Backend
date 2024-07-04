using StockAppWebAPI.Models;
using StockAppWebAPI.Repositories;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Services
{
	public class UserService:IUserService
	{
		private readonly IUserRepository _repository;
		public UserService(IUserRepository repository)
		{
			_repository = repository;
		}
		public async Task<User?> Register(RegisterViewModel user)
		{
			var existingUserByUsername=await _repository.GetByUsername(user.Username);
			if (existingUserByUsername != null) {
				throw new ArgumentException("Username already exists");
			}
			var existingUserByEmail= await _repository.GetByEmail(user.Email);
			if(existingUserByEmail != null)
			{
				throw new ArgumentException("Email already exists");

			}
			return await _repository.Create(user);
		}
		public async Task<string> Login(LoginViewModel loginViewModel)
		{
			return await _repository.Login(loginViewModel);
		}

		public async Task<User?> GetUserById(int userId)
		{
			User? user=await _repository.GetById(userId);
			return user;
		}
	}
}

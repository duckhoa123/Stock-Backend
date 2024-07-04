using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StockAppWebAPI.Filters
{
	public class JwtAuthorizeFilter : IAuthorizationFilter
	{
		private readonly IConfiguration _configuration;
		public JwtAuthorizeFilter(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
			if (token == null)
			{
				context.Result = new UnauthorizedResult();
				return;
			}
			var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:SecretKey") ?? "");
			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);
				var jwtToken = (JwtSecurityToken)validatedToken;
				if (jwtToken.ValidTo < DateTime.UtcNow)
				{
					context.Result = new UnauthorizedResult();
					return;
				}
				var userId = int.Parse(jwtToken.Claims.First().Value);
				context.HttpContext.Items["UserId"] = userId;


			}
			catch (Exception)
			{
				context.Result = new UnauthorizedResult();
				return;
			}


		}
	}
}

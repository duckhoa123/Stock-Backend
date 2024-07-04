using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Services
{
	public interface IUserService
	{
		Task<User?> Register(RegisterViewModel registerViewModel);
		Task<string> Login(LoginViewModel loginViewModel);
		Task<User?> GetUserById(int userId);
	}
}

using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Repositories
{
	public interface IUserRepository
	{
		Task<User?> GetById(int id);
		Task<User?> GetByUsername(string username);
		Task<User?> GetByEmail(string email);
		Task<User?> Create(RegisterViewModel user);
		Task<string> Login(LoginViewModel loginViewModel);

	}
}

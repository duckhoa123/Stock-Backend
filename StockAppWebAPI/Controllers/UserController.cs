using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI.Models;
using StockAppWebAPI.Services;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterViewModel user)
		{
			try
			{
				User? users = await _userService.Register(user);
				return Ok(users);
			}
			catch(ArgumentException ex)
			{
				return BadRequest(new {Message=ex.Message});
			}
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			try
			{
				string jwtToken = await _userService.Login(loginViewModel);
				return Ok(new {jwtToken});
			}
			catch (ArgumentException ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}
	}
}

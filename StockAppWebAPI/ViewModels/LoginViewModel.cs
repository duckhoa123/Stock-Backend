using System.ComponentModel.DataAnnotations;

namespace StockAppWebAPI.ViewModels
{
	public class LoginViewModel
	{
		public string? Username {  get; set; }
		[Required(ErrorMessage="Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; } = "";


	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockAppWebAPI.Attributes;
using StockAppWebAPI.Extensions;
using StockAppWebAPI.Filters;
using StockAppWebAPI.Repositories;
using StockAppWebAPI.Services;
using System.Security.Claims;

namespace StockAppWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WatchListController:ControllerBase
	{
		private readonly IWatchListService _watchlistService;
		private readonly IUserService _userService;
		private readonly IStockService _stockService;

	
		public WatchListController(IWatchListService watchlistService, IUserService userService, IStockService stockService)
		{
		     _watchlistService = watchlistService;
			
			_userService = userService;
			_stockService = stockService;
		}
		[HttpPost("AddStockToWatchList/{stockId}")]
		[JwtAuthorize]
		public async Task<IActionResult> AddStockToWatchList(int stockId)
		{
			int	userId=HttpContext.GetUserId();
			Console.WriteLine("khoa");
			var user=await _userService.GetUserById(userId);
			var stock=await _stockService.GetStockById(stockId);
			if (user == null) { return  NotFound("User not found"); }
			if (stock == null) { return NotFound("Stock not found"); }
			var existingWatchlistItem = await _watchlistService.GetWatchlistItem(userId, stockId);
			if (existingWatchlistItem != null)
			{
				return BadRequest("Stock is already in watchlist");
			}
			await _watchlistService.AddStockToWatchList(userId,stockId);
			return Ok();
		}
	}
}

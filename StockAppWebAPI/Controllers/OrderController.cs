﻿
using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI.Attributes;
using StockAppWebAPI.Extensions;
using StockAppWebAPI.Services;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class OrderController:ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly IUserService _userService;
		public OrderController(IOrderService orderService, IUserService userService)
		{
			_orderService = orderService;
			_userService = userService;
		}
		[HttpPost("place_order")]
		[JwtAuthorize]
		public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel )
		{
			int userId = HttpContext.GetUserId();
			var user = await _userService.GetUserById(userId);
			if (user == null)
			{
				return NotFound("User not found");
			}
			orderViewModel.UserId = userId;
			var createdOrder=await _orderService.PlaceOrder(orderViewModel);
			return Ok(createdOrder);
		}


	}
}

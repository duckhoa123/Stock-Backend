using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Services
{
	public interface IOrderService
	{
		Task<Order> PlaceOrder(OrderViewModel orderViewModel);
	}
}

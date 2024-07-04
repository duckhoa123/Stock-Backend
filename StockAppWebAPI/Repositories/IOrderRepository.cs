using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Repositories
{
	public interface IOrderRepository
	{
		Task<Order> CreateOrder(OrderViewModel orderViewModel);
	}
}

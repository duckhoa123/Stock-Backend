using StockAppWebAPI.Models;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly StockAppContext _context;
		public OrderRepository(StockAppContext context)
		{ _context = context; }
		public async Task<Order> CreateOrder(OrderViewModel orderViewModel)
		{
			Order order = new Order()
			{
				UserId = orderViewModel.UserId,
				StockId = orderViewModel.StockId,
				OrderType = orderViewModel.OrderType,
				Direction = orderViewModel.Direction,
				Quantity = orderViewModel.Quantity,
				Price = orderViewModel.Price,
				Status = orderViewModel.Status,
				OrderDate = DateTime.Now,

			};
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();
			return order;

		}
	}
}

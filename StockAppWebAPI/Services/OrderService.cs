using StockAppWebAPI.Models;
using StockAppWebAPI.Repositories;
using StockAppWebAPI.ViewModels;

namespace StockAppWebAPI.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		public OrderService(IOrderRepository repository)
		{
			_repository = repository;
		}
		public async Task<Order> PlaceOrder(OrderViewModel orderViewModel)
		{
			if(orderViewModel.Quantity<=0)
			{
				throw new ArgumentException("Quantity must be greater than 0");

			}
			return await _repository.CreateOrder(orderViewModel);


		}
	}
}

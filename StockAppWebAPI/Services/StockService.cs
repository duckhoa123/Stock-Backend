using StockAppWebAPI.Models;
using StockAppWebAPI.Repositories;

namespace StockAppWebAPI.Services
{
	public class StockService : IStockService
	{
		private readonly IStockRepository _repository;
		public StockService(IStockRepository repository)
		{
			_repository = repository;
		}
		public async Task<Stock?> GetStockById(int stockId)
		{
			Stock? stock = await _repository.GetById(stockId);
			return stock;
		}
	}
}

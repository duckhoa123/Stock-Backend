using StockAppWebAPI.Models;
using StockAppWebAPI.Repositories;

namespace StockAppWebAPI.Services
{
	public class WatchListService:IWatchListService
	{
		private readonly IWatchListRepository _repository;
			public WatchListService(IWatchListRepository repository)
		{
			_repository = repository;
		}
		public async Task AddStockToWatchList(int userId,int stockId)
		{
			await _repository.AddStockToWatchList(userId, stockId);
		}

		public async Task<WatchList?> GetWatchlistItem(int userId, int stockId)
		{
			return await _repository.GetWatchList(userId, stockId);
		}
	}
}

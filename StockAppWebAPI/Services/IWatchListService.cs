using StockAppWebAPI.Models;

namespace StockAppWebAPI.Services
{
	public interface IWatchListService
	{
		 Task AddStockToWatchList(int userId, int stockId);
		Task<WatchList?> GetWatchlistItem(int userId, int stockId);
	}
}

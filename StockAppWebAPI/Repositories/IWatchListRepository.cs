using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public interface IWatchListRepository
	{
		Task AddStockToWatchList(int userId, int stockId);
		Task<WatchList?> GetWatchList(int userId,int stockId);
	}
}

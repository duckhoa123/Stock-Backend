using Microsoft.EntityFrameworkCore;
using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public class WatchListRepository :IWatchListRepository
	{
		private readonly StockAppContext _stockAppContext;
		private readonly IConfiguration _configuration;
		public WatchListRepository(StockAppContext stockAppContext, IConfiguration configuration)
		{
			_stockAppContext = stockAppContext;
			_configuration = configuration;
		}
		public async Task AddStockToWatchList(int userId,int stockId)
		{
			var wathlist=await _stockAppContext.WatchLists.FindAsync(userId, stockId);
			if (wathlist == null)
			{
				wathlist = new WatchList
				{
					UserId = userId,
					StockId = stockId
				};
				_stockAppContext.WatchLists.Add(wathlist);
				await _stockAppContext.SaveChangesAsync();

			}

		}

		public async Task<WatchList?> GetWatchList(int userId, int stockId)
		{
			return await _stockAppContext.WatchLists.FirstOrDefaultAsync(w=>w.UserId==userId&&w.StockId==stockId);

		}
	}
}

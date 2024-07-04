using StockAppWebAPI.Models;

namespace StockAppWebAPI.Services
{
	public interface IStockService
	{
		Task<Stock?> GetStockById(int stockId);
	}
}

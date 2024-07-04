using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public interface IStockRepository
	{
		Task<Stock?> GetById(int id);
	}
}

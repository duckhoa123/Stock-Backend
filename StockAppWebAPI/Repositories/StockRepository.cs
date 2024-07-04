using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public class StockRepository:IStockRepository
	{
		private readonly StockAppContext _stockAppContext;
		private readonly IConfiguration _configuration;
		public StockRepository(StockAppContext stockAppContext, IConfiguration configuration)
		{
			_stockAppContext = stockAppContext;
			_configuration = configuration;
		}
		public async Task<Stock?> GetById(int id)
		{
			return await _stockAppContext.Stocks.FindAsync(id);
		}
	}
}

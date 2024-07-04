using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public interface IQuoteRepository
	{
		Task<List<RealtimeQuote>?> GetRealtimeQuotes(int page, int limit, string sector, string industry);
		Task<List<Quote>> GetHistoricalQuotes(int days,int stockId);
	}
}

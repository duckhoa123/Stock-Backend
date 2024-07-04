using StockAppWebAPI.Models;
using StockAppWebAPI.Repositories;

namespace StockAppWebAPI.Services
{
	public class QuoteService : IQuoteService
	{
		private readonly IQuoteRepository _repository;
		public QuoteService(IQuoteRepository repository)
		{
			_repository = repository;
		}

		public async  Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
		{
			return await _repository.GetHistoricalQuotes(days, stockId);
		}

		public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(int page, int limit, string sector, string industry)
		{
			return await _repository.GetRealtimeQuotes(page, limit, sector, industry);
			

	}
	}
}

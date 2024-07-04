using Microsoft.EntityFrameworkCore;
using StockAppWebAPI.Models;

namespace StockAppWebAPI.Repositories
{
	public class QuoteRepository : IQuoteRepository
	{   private readonly StockAppContext _context;
		public QuoteRepository(StockAppContext context)
		{  _context = context; }

		public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
		{
			var fromDate=DateTime.Now.Date.AddDays(-days);
			var toDate = DateTime.Now.Date;
			var historicalQuotes = await _context.Quotes
				.Where(q => q.TimeStamp >= fromDate && q.TimeStamp <= toDate
				&& q.StockId == stockId)
				.GroupBy(q => q.TimeStamp.Date)
				.Select(g => new Quote
				{
					TimeStamp = g.Key,
					Price = g.Average(q => q.Price),
				})
				.OrderBy(q => q.TimeStamp)
				.ToListAsync();
			return historicalQuotes;
		}

		public async Task<List<RealtimeQuote>?> GetRealtimeQuotes(int page, int limit, string sector, string industry)
		{
			var query = _context.RealtimeQuotes.Skip((page - 1) * limit).Take(limit);
			if (!string.IsNullOrEmpty(sector))
			{
				query = query.Where(x => (x.Sector ?? "").ToLower().Equals(sector.ToLower()));
			}
			if (!string.IsNullOrEmpty(industry))
			{
				query = query.Where(x => (x.Industry ?? "").ToLower().Equals(industry.ToLower()));
			}
			var quotes = await query.ToListAsync();
			return quotes;
			

		}
	}
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebAPI.Models
{
	[Table("view_quotes_realtime")]
	[Keyless]
	public class RealtimeQuote
	{
		[Column("quote_id")]
		public int Quoteid { get; set; }

		[Column("company_name")]
		public string? Companyname { get; set; }

		[Column("market_cap")]
		public string? Marketcap { get; set; }
		[Column("sector_en")]
		public string? SectorEn { get; set; }
		[Column("industry_en")]
		public string? IndustryEn { get; set; }
		[Column("sector")]
		public string? Sector { get; set; }
		[Column("industry")]
		public string? Industry { get; set; }
		[Column("stock_type")]
		public string? StockType { get; set; }

		[Column("price")]
		public decimal Price { get; set; }
		[Column("change")]
		public decimal Change { get; set; }
		[Column("percent_change")]
		public decimal PercentChange { get; set; }
		[Column("volume")]
		public int volume { get; set; }
		[Column("time_stamp")]
		public DateTime TimeStamp { get; set; }



	}
}

using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI.Models;
using StockAppWebAPI.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace StockAppWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class QuoteController : ControllerBase
	{
		private readonly IQuoteService _quoteService;
		public QuoteController(IQuoteService quoteService)
		{
			_quoteService = quoteService;
		}
		[HttpGet("ws")]
		 public async Task GetRealtimeQuotes(int page=1,int limit=10,string sector="",string industry="")
		{
			if (HttpContext.WebSockets.IsWebSocketRequest)
			{
				using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
				
				while (webSocket.State == WebSocketState.Open)
				{	List<RealtimeQuote>? quotes=await _quoteService.GetRealtimeQuotes(page,limit, sector, industry);
					string jsonString=JsonSerializer.Serialize(quotes);
					var buffer=Encoding.UTF8.GetBytes(jsonString);
					await webSocket.SendAsync(new ArraySegment<byte>(buffer),WebSocketMessageType.Text,true,CancellationToken.None);
					await Task.Delay(2000);

				}
				await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by server", CancellationToken.None);
			}
			else
			{
				HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
			}
		}
		[HttpGet("historical")]
		public async Task<IActionResult>GetHistoricalQuotes(int days,int stockId)
		{
			var historicalQuotes = await _quoteService.GetHistoricalQuotes(days, stockId);
			return Ok(historicalQuotes);
		}
 
	}
}

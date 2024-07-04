using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace StockAppWebAPI.Controllers
{
	[Route("api/ws")]
	public class WebSocketController : ControllerBase
	{
		[HttpGet]
		public async Task Get()
		{
			if (HttpContext.WebSockets.IsWebSocketRequest)
			{
				using var webSocket=await HttpContext.WebSockets.AcceptWebSocketAsync();
				var random=new Random();
				while(webSocket.State==WebSocketState.Open)
				{
					int x=random.Next(1,100);
					int y = random.Next(1, 100);
					var buffer = Encoding.UTF8.GetBytes($"{{ \"x\":{x},\"y\":{y} }}");
					Console.WriteLine($"x:{x},y:{y}");
					await webSocket.SendAsync(new ArraySegment<byte>(buffer),
						WebSocketMessageType.Text,true,CancellationToken.None);
					await Task.Delay(2000); 

				}
				await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by server", CancellationToken.None);
			}
			else
			{
				HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
			}
		}
	}
}

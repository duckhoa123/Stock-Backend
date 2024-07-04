using Microsoft.AspNetCore.Mvc;
using StockAppWebAPI.Filters;

namespace StockAppWebAPI.Attributes
{
	public class JwtAuthorizeAttribute: TypeFilterAttribute
	{
		public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
		{

		}
	}
}

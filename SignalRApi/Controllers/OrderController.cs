using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public IActionResult GetTotalOrderCount()
		{
		    return Ok(_orderService.TGetTotalOrderCount());
		}

		[HttpGet("GetActiveOrderCount")]
		public IActionResult GetActiveOrderCount()
		{
			return Ok(_orderService.TGetActiveOrderCount());
		}

		[HttpGet("GetLastOrderPrice")]
		public IActionResult GetLastOrderPrice()
		{
			return Ok(_orderService.TGetLastOrderPrice());
		}

		[HttpGet("GetTodayTotalProfit")]
		public IActionResult GetTodayTotalProfit()
		{
			return Ok(_orderService.TGetTodayTotalProfit());
		}
	}
}

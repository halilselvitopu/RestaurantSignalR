using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CashRegisterController : ControllerBase
	{
		private readonly ICashRegisterService _cashRegisterService;

		public CashRegisterController(ICashRegisterService cashRegisterService)
		{
			_cashRegisterService = cashRegisterService;
		}

		[HttpGet]
		public IActionResult GetTotalPriceCashRegister()
		{
			return Ok(_cashRegisterService.TGetTotalPriceCashRegister());
		}


	}

	
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class DiscountProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DiscountProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7073/api/DiscountProduct");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDiscountProductDto>>(jsonData);
				return View(values);

			}

			return View();
		}

		[HttpGet]
		public IActionResult AddDiscountProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddDiscountProduct(CreateDiscountProductDto createDiscountProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7073/api/DiscountProduct", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		public async Task<IActionResult> DeleteDiscountProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7073/api/DiscountProduct/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> UpdateDiscountProduct(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7073/api/DiscountProduct/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDiscountProductDto>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDiscountProduct(UpdateDiscountProductDto updateDiscountProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7073/api/DiscountProduct/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}

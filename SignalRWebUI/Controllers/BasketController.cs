using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "https://localhost:7073/api/Basket";

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"{_apiBaseUrl}/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                    return View(values ?? new List<ResultBasketDto>());
                }

                TempData["Error"] = "Sepet bilgileri alınamadı";
                return View(new List<ResultBasketDto>());
            }
            catch (Exception ex)
            {
                
                TempData["Error"] = "Bir hata oluştu";
                return View(new List<ResultBasketDto>());
            }
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/{id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Ürün sepetten silindi";
                    return RedirectToAction("Index");
                }

                TempData["Error"] = "Ürün silinemedi";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                TempData["Error"] = "Bir hata oluştu";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int basketId, int quantity)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(
                    JsonConvert.SerializeObject(quantity),
                    Encoding.UTF8,
                    "application/json");

                var responseMessage = await client.PutAsync(
                    $"{_apiBaseUrl}/UpdateQuantity/{basketId}",
                    content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Miktar güncellenemedi" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu" });
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountProductDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class DefaultOfferComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultOfferComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/DiscountProduct/GetDiscountProductsByStatus");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountProductDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}

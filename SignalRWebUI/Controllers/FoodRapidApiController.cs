using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;
using X.PagedList;
using X.PagedList.Extensions;

namespace SignalRWebUI.Controllers
{
    public class FoodRapidApiController : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 8)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
                Headers =
                {
                    { "x-rapidapi-key", "4034e659c0msh83d8f6ae7d77004p134fffjsnf5fb44dbe656" },
                    { "x-rapidapi-host", "tasty.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;

                var paginatedValues = values.ToPagedList(page, pageSize);
                return View(paginatedValues);
            }
        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.MessageDtos;
using System.Text;
using System.Text.Json.Nodes;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("https://localhost:7073/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.Location = value;
			return View();
		}


        [HttpGet]
        public async Task<PartialViewResult> SendMessage()
        {
           
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7073/api/Message", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); 
            }

           
            return View("Index", "Default");
        }

    }
}

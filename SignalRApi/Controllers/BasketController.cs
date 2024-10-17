using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService, IMapper mapper)
        {
            _basketService = basketService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByTableNumber(int id)
        {
           return Ok(_basketService.TGetBasketByTableNumber(id)); 
        }

        [HttpPost]
        public IActionResult AddBasket(CreateBasketDto createBasketDto)
        {
            var product = _productService.TGetById(createBasketDto.ProductId);
            var newBasket = _mapper.Map<Basket>(createBasketDto);
            newBasket.ProductCount = 1;
            newBasket.Price = product.Price;
            newBasket.TableId = 4;          
            _basketService.TAdd(newBasket);
            return Ok("Sepete Ürün Eklendi");

        }

    }
}

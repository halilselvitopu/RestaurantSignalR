using AutoMapper;
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

        [HttpGet("{tableId}")]
        public ActionResult<IEnumerable<ResultBasketDto>> GetBasketByTableNumber(int tableId)
        {
            var basket = _basketService.TGetBasketByTableNumber(tableId);
            if (basket == null || !basket.Any())
            {
                return NotFound($"No basket found for table {tableId}");
            }
            return Ok(basket);
        }

        [HttpPost]
        public ActionResult<string> AddBasket(CreateBasketDto createBasketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productService.TGetById(createBasketDto.ProductId);
            if (product == null)
            {
                return NotFound($"Product with ID {createBasketDto.ProductId} not found");
            }

           
            var existingBasket = _basketService.TGetBasketByTableNumber(createBasketDto.TableId)
                .FirstOrDefault(b => b.ProductId == createBasketDto.ProductId);

            if (existingBasket != null)
            {
                
                existingBasket.ProductCount++;
                existingBasket.TotalPrice = product.Price * existingBasket.ProductCount;
                _basketService.TUpdate(existingBasket);
                return Ok("Ürün sayısı sepette güncellendi");
            }

            
            var newBasket = _mapper.Map<Basket>(createBasketDto);
            newBasket.TableId = createBasketDto.TableId;
            newBasket.ProductCount = 1;
            newBasket.Price = product.Price;
            newBasket.TotalPrice = product.Price;

            _basketService.TAdd(newBasket);
            return Ok("Sepete ürün eklendi");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBasket(int id)
        {
            try
            {
                var basket = _basketService.TGetById(id);
                if (basket == null)
                {
                    return NotFound($"Basket with ID {id} not found");
                }

               
                var tableId = basket.TableId;

                
                _basketService.TDelete(basket);

                
                var remainingBasketItems = _basketService.TGetBasketByTableNumber(tableId);
                return Ok(new
                {
                    message = "Ürün sepetten silindi",
                    remainingItems = remainingBasketItems
                });
            }
            catch (Exception ex)
            {
                return BadRequest("Silme işlemi sırasında bir hata oluştu");
            }
        }

        [HttpPut("UpdateQuantity/{basketId}")]
        public ActionResult UpdateBasketQuantity(int basketId, [FromBody] int quantity)
        {
            if (quantity < 1)
            {
                return BadRequest("Quantity must be greater than 0");
            }

            var basket = _basketService.TGetById(basketId);
            if (basket == null)
            {
                return NotFound($"Basket with ID {basketId} not found");
            }

            var product = _productService.TGetById(basket.ProductId);
            basket.ProductCount = quantity;
            basket.TotalPrice = product.Price * quantity;

            _basketService.TUpdate(basket);
            return Ok("Ürün miktarı güncellendi");
        }
    }
}
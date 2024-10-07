using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.DiscountProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountProductController : ControllerBase
    {
        private readonly IDiscountProductService _discountProductService;
        private readonly IMapper _mapper;

        public DiscountProductController(IDiscountProductService discountProductService, IMapper mapper)
        {
            _discountProductService = discountProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountProductList()
        {
            var values = _discountProductService.TGetAll();
            return Ok(_mapper.Map<List<ResultDiscountProductDto>>(values));
        }

        [HttpPost]
        public IActionResult AddDiscountProduct(CreateDiscountProductDto createDiscountProductDto)
        {
            var value = _mapper.Map<DiscountProduct>(createDiscountProductDto);
            _discountProductService.TAdd(value);
            return Ok("Başarıyla eklendi.");

        }

        [HttpDelete]
        public IActionResult DeleteDiscountProduct(int id)
        {
            var value = _discountProductService.TGetById(id);
            _discountProductService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateDiscountProduct(UpdateDiscountProductDto updateDiscountProductDto)
        {
            var value = _mapper.Map<DiscountProduct>(updateDiscountProductDto);
            _discountProductService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("GetDiscountProductById")]
        public IActionResult GetDiscountProductById(int id)
        {
            var value = _discountProductService.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));

        }
    }
}

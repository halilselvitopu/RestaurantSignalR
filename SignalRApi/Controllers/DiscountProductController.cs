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


        [HttpGet("GetDiscountProductsByStatus")]
        public IActionResult GetDiscountProductsByStatus()
        {
            return Ok(_discountProductService.TGetDiscountProductByStatus());
        }

        [HttpPost]
        public IActionResult AddDiscountProduct(CreateDiscountProductDto createDiscountProductDto)
        {
            createDiscountProductDto.Status = false;
            var value = _mapper.Map<DiscountProduct>(createDiscountProductDto);
            _discountProductService.TAdd(value);
            return Ok("Başarıyla eklendi.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscountProduct(int id)
        {
            var value = _discountProductService.TGetById(id);
            _discountProductService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateDiscountProduct(UpdateDiscountProductDto updateDiscountProductDto)
        {
            updateDiscountProductDto.Status = false;
            var value = _mapper.Map<DiscountProduct>(updateDiscountProductDto);
            _discountProductService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
		public IActionResult GetDiscountProductById(int id)
        {
            var value = _discountProductService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountProductDto>(value));

        }

		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			 _discountProductService.TChangeStatusToTrue(id);
			return Ok("Ürün indirimi aktif hale geltirildi.");

		}

		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountProductService.TChangeStatusToFalse(id);
			return Ok("Ürün indirimi pasif hale geltirildi.");

		}
	}
}

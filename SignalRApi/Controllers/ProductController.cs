using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System.Xml.Linq;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

		[HttpGet("GetProductCount")]
		public IActionResult GetProductCount()
		{
			return Ok(_productService.TGetProductCount());
		}

		[HttpGet("GetAverageProductPrice")]
		public IActionResult GetAverageProductPrice()
		{
			return Ok(_productService.TGetAverageProductPrice());
		}

		[HttpGet("GetAverageHamburgerPrice")]
		public IActionResult GetAverageHamburgerPrice()
		{
			return Ok(_productService.TGetAverageHamburgerPrice());
		}

		[HttpGet("GetMostExpensiveProductNames")]
		public IActionResult GetMostExpensiveProductNames()
		{
			return Ok(_productService.TGetMostExpensiveProductNames());
		}

		[HttpGet("GetCheapestProductNames")]
		public IActionResult GetCheapestProductNames()
		{
			return Ok(_productService.TGetCheapestProductNames());
		}

		[HttpGet("GetProductCountByCategoryNameDrink")]
		public IActionResult GetProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TGetProductCountByCategoryNameDrink());
		}

		[HttpGet("GetProductCountByCategoryHamburger")]
		public IActionResult GetProductCountByCategoryHamburger()
		{
			return Ok(_productService.TGetProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _productService.TGetProductsWithCategories();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
			createProductDto.Status = true;
			var value = _mapper.Map<Product>(createProductDto);
			createProductDto.CategoryId = value.CategoryId;
			_productService.TAdd(value);
			return Ok("Başarıyla eklendi.");
		}

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
			updateProductDto.Status = true;
			var value = _mapper.Map<Product>(updateProductDto);
            updateProductDto.CategoryId = value.CategoryId;
            _productService.TUpdate(value);
            return Ok("Başarıyla güncelledi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));

        }
    }
}

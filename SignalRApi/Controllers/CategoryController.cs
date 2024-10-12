using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(values));
        }

		[HttpGet("GetCategoryCount")]
		public IActionResult GetCategoryCount()
		{			
			return Ok(_categoryService.TGetCategoryCount());
		}

		[HttpGet("GetActiveCategoryCount")]
		public IActionResult GetActiveCategoryCount()
		{
			return Ok(_categoryService.TGetActiveCategoryCount());
		}

		[HttpGet("GetPassiveCategoryCount")]
		public IActionResult GetPassiveCategoryCount()
		{
			return Ok(_categoryService.TGetPassiveCategoryCount());
		}

		[HttpPost]
        public IActionResult AddCategory(CreateCategorytDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
			updateCategoryDto.Status = true;
			var value = _mapper.Map<Category>(updateCategoryDto);
			_categoryService.TUpdate(value);
			return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));
        }
    }
}

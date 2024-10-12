using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.FeatureProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureProductController : ControllerBase
    {
        private readonly IFeatureProductService _featureProductService;
        private readonly IMapper _mapper;

        public FeatureProductController(IFeatureProductService featureProductService, IMapper mapper)
        {
            _featureProductService = featureProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureProductList()
        {
            var values = _featureProductService.TGetAll();
            return Ok(_mapper.Map<List<ResultFeatureProductDto>>(values));
        }

        [HttpPost]
        public IActionResult AddFeatureProduct(CreateFeatureProductDto createFeatureProductDto)
        {
            var value = _mapper.Map<FeatureProduct>(createFeatureProductDto);
            _featureProductService.TAdd(value);
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeatureProduct(int id)
        {
             var value = _featureProductService.TGetById(id);
            _featureProductService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateFeatureProduct(UpdateFeatureProductDto updateFeatureProductDto)
        {
            var value = _mapper.Map<FeatureProduct>(updateFeatureProductDto);
            _featureProductService.TUpdate(value);
            return Ok("Başarıyla güncelledi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetFatureProductById(int id)
        {
            var value = _featureProductService.TGetById(id);
            return Ok(_mapper.Map<GetFeatureProductDto>(value));

        }
    }
}

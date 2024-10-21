using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
			_sliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _sliderService.TGetAll();
            return Ok(_mapper.Map<List<ResultSliderDto>>(values));
        }

        [HttpPost]
        public IActionResult AddSlider(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
             var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var value = _mapper.Map<Slider>(updateSliderDto);
			_sliderService.TUpdate(value);
            return Ok("Başarıyla güncelledi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetSliderById(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(_mapper.Map<GetSliderDto>(value));

        }
    }
}

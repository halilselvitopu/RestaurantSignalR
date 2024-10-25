using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _createBookingValidator;
        private readonly IValidator<UpdateBookingDto> _updateBookingvalidator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> createBookingValidator, IValidator<UpdateBookingDto> updateBookingvalidator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _createBookingValidator = createBookingValidator;
            _updateBookingvalidator = updateBookingvalidator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult AddBooking(CreateBookingDto createBookingDto)
        {
            var validationResult = _createBookingValidator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            createBookingDto.Description = "Rezervasyon Alındı";
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }


        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {

            var validationResult = _updateBookingvalidator.Validate(updateBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("ChangeBookingStatusToApproved/{id}")]
        public IActionResult ChangeBookingStatusToApproved(int id)
        {
            _bookingService.TChangeBookingStatusToApproved(id);
            return Ok("Rezervasyon durumu başarıyla değiştirildi.");
        }

        [HttpGet("ChangeBookingStatusToCancelled/{id}")]
        public IActionResult ChangeBookingStatusToCancelled(int id)
        {
            _bookingService.TChangeBookingStatusToCancelled(id);
            return Ok("Rezervasyon durumu başarıyla değiştirildi.");
        }

        [HttpGet("GetTotalBookingCount")]
        public IActionResult GetTotalBookingCount()
        {
            return Ok(_bookingService.TGetTotalBookingCount());
        }

    }
}

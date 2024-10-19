using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));

		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNorificationByStatusFalse")]
		public IActionResult GetAllNorificationByStatusFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByStatusFalse());
		}

		[HttpGet("ChangeNotificationStatusToFalse/{id}")]
		public IActionResult ChangeNotificationStatusToFalse(int id)
		{
			_notificationService.TChangeNotificationStatusToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}

		[HttpGet("ChangeNotificationStatusToTrue/{id}")]
		public IActionResult ChangeNotificationStatusToTrue(int id)
		{
			_notificationService.TChangeNotificationStatusToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}

		[HttpPost]
		public IActionResult AddNotification(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			createNotificationDto.Status = false;
			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);
			return Ok("Başarıyla Eklendi");

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Başarıyla Silindi");
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			updateNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			updateNotificationDto.Status = false;
			var value = _mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(value);
			return Ok("Başarıyla güncellendi.");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotificationById(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(_mapper.Map<GetNotificationDto>(value));
		}
	}
}

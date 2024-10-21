using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;


        public MessageController(IMessageService MessageService, IMapper mapper)
        {
           _messageService= MessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult AddMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetById(id);
            _messageService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDto>(value));
        }
    }
}

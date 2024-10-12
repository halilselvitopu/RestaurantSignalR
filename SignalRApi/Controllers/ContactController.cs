using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _contactService.TGetAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(value));

        }

        [HttpPost]
        public IActionResult AddContact(CreateContactDto createContactDto)
        {
             
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("Başarıyla eklendi.");

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}

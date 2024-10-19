using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        IMapper _mapper;

        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet("GetTotalTableCount")]
        public IActionResult GetTotalTableCount()
        {
            return Ok(_tableService.TGetTotalTableCount());
        }

        [HttpGet]
        public IActionResult TableList()
        {
            var values = _tableService.TGetAll();
            return Ok(_mapper.Map<List<ResultTableDto>>(values));
        }

        [HttpPost]
        public IActionResult AddTable(CreateTableDto createTableDto)
        {
            createTableDto.Status = false;
            var value = _mapper.Map<Table>(createTableDto);
            _tableService.TAdd(value);
            return Ok("Başarıyla bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var value = _tableService.TGetById(id);
            _tableService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDto updateTableDto)
        {
            var value = _mapper.Map<Table>(updateTableDto);
            _tableService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetTableById(int id)
        {
            var value = _tableService.TGetById(id);
            return Ok(_mapper.Map<GetTableDto>(value));
        }

    }
}

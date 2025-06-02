using Microsoft.AspNetCore.Mvc;
using CoworkingBooking.API.Models.Dto;
using System.Collections.Generic;

namespace CoworkingBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ZoneDto>> GetAll() => Ok(new List<ZoneDto>());
        [HttpGet("{id}")]
        public ActionResult<ZoneDto> Get(int id) => Ok(new ZoneDto());
        [HttpPost]
        public IActionResult Create([FromBody] ZoneDto dto) => CreatedAtAction(nameof(Get), new { id = 1 }, dto);
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ZoneDto dto) => NoContent();
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using CoworkingBooking.API.Models.Dto;
using System.Collections.Generic;

namespace CoworkingBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BookingDto>> GetAll() => Ok(new List<BookingDto>());
        
        [HttpGet("{id}")]
        public ActionResult<BookingDto> Get(int id) => Ok(new BookingDto());
        
        [HttpPost]
        public IActionResult Create([FromBody] BookingDto dto) => CreatedAtAction(nameof(Get), new { id = 1 }, dto);
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BookingDto dto) => NoContent();
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using CoworkingBooking.API.Models.Dto;
using CoworkingBooking.API.Services;

namespace CoworkingBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspacesController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;
        
        public WorkspacesController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<WorkspaceDto>> GetAll() 
            => Ok(_workspaceService.GetAll());
            
        [HttpGet("{id}")]
        public ActionResult<WorkspaceDto> Get(int id) 
            => Ok(_workspaceService.GetById(id));
            
        [HttpPost]
        public IActionResult Create([FromBody] WorkspaceDto dto)
            => CreatedAtAction(nameof(Get), new { id = 1 }, _workspaceService.Create(dto));
            
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WorkspaceDto dto)
        {
            _workspaceService.Update(id, dto);
            return NoContent();
        }
            
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _workspaceService.Delete(id);
            return NoContent();
        }
    }
}
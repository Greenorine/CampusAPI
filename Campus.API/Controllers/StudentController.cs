using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentInfoController : ControllerBase
{
    private readonly IMediator mediator;

    public StudentInfoController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost("get_info/{id}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<StudentInfo>(id)));
    }

    [HttpPost("add_info")]
    public async Task<IActionResult> AddInfo([FromBody] StudentInfo info)
    {
        return Ok(await mediator.Send(new UpsertEntity<StudentInfo>(info)));
    }
    
    [HttpGet("remove_info/{id}")]
    public async Task<IActionResult> RemoveInfo(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<StudentInfo>(id)));
    }
    
    [HttpPost("update_info")]
    public async Task<IActionResult> UpdateInfo([FromBody] StudentInfo info)
    {
        return Ok(await mediator.Send(new UpdateEntity<StudentInfo>(info)));
    }
}
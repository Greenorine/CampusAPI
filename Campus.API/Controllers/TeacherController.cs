using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TeacherInfoController : ControllerBase
{
    private readonly IMediator mediator;

    public TeacherInfoController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost("get_info/{id}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<TeacherInfo>(id)));
    }

    [HttpPost("add_info")]
    public async Task<IActionResult> AddInfo([FromBody] TeacherInfo info)
    {
        return Ok(await mediator.Send(new UpsertEntity<TeacherInfo>(info)));
    }
    
    [HttpGet("remove_info/{id}")]
    public async Task<IActionResult> RemoveInfo(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<TeacherInfo>(id)));
    }
    
    [HttpPost("update_info")]
    public async Task<IActionResult> UpdateInfo([FromBody] TeacherInfo info)
    {
        return Ok(await mediator.Send(new UpdateEntity<TeacherInfo>(info)));
    }
}
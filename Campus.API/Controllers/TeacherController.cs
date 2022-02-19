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
    
    [HttpGet("get_info/{id}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<TeacherInfo>(id)));
    }

    [HttpGet("get_all_info")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<TeacherInfo>()));
    }

    [HttpPost("save_info")]
    public async Task<IActionResult> SaveInfo(TeacherInfo info)
    {
        return Ok(await mediator.Send(new SaveEntity<TeacherInfo>(info)));
    }
    
    [HttpDelete("remove_info/{id}")]
    public async Task<IActionResult> RemoveInfo(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<TeacherInfo>(id)));
    }
}
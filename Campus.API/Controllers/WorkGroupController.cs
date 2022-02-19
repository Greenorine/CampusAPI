using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WorkGroupController : ControllerBase
{
    private readonly IMediator mediator;

    public WorkGroupController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("get_group/{id}")]
    public async Task<IActionResult> GetGroup(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<WorkGroup>(id)));
    }

    [HttpGet("get_all_group")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<WorkGroup>()));
    }

    [HttpPost("save_group")]
    public async Task<IActionResult> SaveGroup(WorkGroup group)
    {
        return Ok(await mediator.Send(new SaveEntity<WorkGroup>(group)));
    }

    [HttpDelete("remove_group/{id}")]
    public async Task<IActionResult> RemoveGroup(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<WorkGroup>(id)));
    }
}
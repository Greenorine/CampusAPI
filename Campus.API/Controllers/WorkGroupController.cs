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

    [HttpPost("get_group/{id}")]
    public async Task<IActionResult> Getgroup(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<WorkGroup>(id)));
    }

    [HttpPost("add_group")]
    public async Task<IActionResult> Addgroup([FromBody] WorkGroup group)
    {
        return Ok(await mediator.Send(new UpsertEntity<WorkGroup>(group)));
    }

    [HttpGet("remove_group/{id}")]
    public async Task<IActionResult> Removegroup(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<WorkGroup>(id)));
    }

    [HttpPost("update_group")]
    public async Task<IActionResult> Updategroup([FromBody] WorkGroup group)
    {
        return Ok(await mediator.Send(new UpdateEntity<WorkGroup>(group)));
    }
}
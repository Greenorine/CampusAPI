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
    public async Task<IActionResult> Getgroup(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<WorkGroup>(id)));
    }

    [HttpGet("get_all_group")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<WorkGroup>()));
    }

    [HttpPost("add_group")]
    public async Task<IActionResult> Addgroup([FromBody] WorkGroup group)
    {
        return Ok(await mediator.Send(new UpsertEntity<WorkGroup>(group)));
    }

    [HttpDelete("remove_group/{id}")]
    public async Task<IActionResult> Removegroup(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<WorkGroup>(id)));
    }

    [HttpPut("update_group")]
    public async Task<IActionResult> Updategroup([FromBody] WorkGroup group)
    {
        return Ok(await mediator.Send(new UpdateEntity<WorkGroup>(group)));
    }
}
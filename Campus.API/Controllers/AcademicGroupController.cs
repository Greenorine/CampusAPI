using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AcademicGroupController : ControllerBase
{
    private readonly IMediator mediator;

    public AcademicGroupController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("get_group/{id}")]
    public async Task<IActionResult> GetGroup(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<AcademicGroup>(id)));
    }

    [HttpGet("get_all_group")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<AcademicGroup>()));
    }

    [HttpPost("add_group")]
    public async Task<IActionResult> AddGroup([FromBody] AcademicGroup group)
    {
        return Ok(await mediator.Send(new UpsertEntity<AcademicGroup>(group)));
    }

    [HttpDelete("remove_group/{id}")]
    public async Task<IActionResult> RemoveGroup(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<AcademicGroup>(id)));
    }

    [HttpPut("update_group")]
    public async Task<IActionResult> UpdateGroup([FromBody] AcademicGroup group)
    {
        return Ok(await mediator.Send(new UpdateEntity<AcademicGroup>(group)));
    }
}
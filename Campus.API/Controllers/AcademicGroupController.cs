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

    [HttpPost("get_group/{id}")]
    public async Task<IActionResult> Getgroup(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<AcademicGroup>(id)));
    }

    [HttpPost("add_group")]
    public async Task<IActionResult> Addgroup([FromBody] AcademicGroup group)
    {
        return Ok(await mediator.Send(new UpsertEntity<AcademicGroup>(group)));
    }

    [HttpGet("remove_group/{id}")]
    public async Task<IActionResult> Removegroup(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<AcademicGroup>(id)));
    }

    [HttpPost("update_group")]
    public async Task<IActionResult> Updategroup([FromBody] AcademicGroup group)
    {
        return Ok(await mediator.Send(new UpdateEntity<AcademicGroup>(group)));
    }
}
using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMediator mediator;

    public ActivityController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost("get_activity/{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<Activity>(id)));
    }

    [HttpPost("add_activity")]
    public async Task<IActionResult> AddActivity([FromBody] Activity activity)
    {
        return Ok(await mediator.Send(new UpsertEntity<Activity>(activity)));
    }
    
    [HttpGet("remove_activity/{id}")]
    public async Task<IActionResult> RemoveActivity(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<Activity>(id)));
    }
    
    [HttpPost("update_activity")]
    public async Task<IActionResult> UpdateActivity([FromBody] Activity activity)
    {
        return Ok(await mediator.Send(new UpdateEntity<Activity>(activity)));
    }
}
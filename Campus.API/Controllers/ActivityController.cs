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
    
    [HttpGet("get_activity/{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<Activity>(id)));
    }

    [HttpGet("get_all_activity")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<Activity>()));
    }

    [HttpPost("save_activity")]
    public async Task<IActionResult> SaveActivity(Activity activity)
    {
        return Ok(await mediator.Send(new SaveEntity<Activity>(activity)));
    }
    
    [HttpDelete("remove_activity/{id}")]
    public async Task<IActionResult> RemoveActivity(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<Activity>(id)));
    }
}
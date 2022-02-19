using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet("get_user/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<User>(id)));
    }

    [HttpGet("get_all_user")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<User>()));
    }

    [HttpPost("save_user")]
    public async Task<IActionResult> SaveUser(User user)
    {
        return Ok(await mediator.Send(new SaveEntity<User>(user)));
    }
    
    [HttpDelete("remove_user/{id}")]
    public async Task<IActionResult> RemoveUser(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<User>(id)));
    }
}
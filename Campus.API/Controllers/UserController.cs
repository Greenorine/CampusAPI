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
    
    [HttpPost("get_user/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<User>(id)));
    }

    [HttpPost("add_user")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        return Ok(await mediator.Send(new UpsertEntity<User>(user)));
    }
    
    [HttpGet("remove_user/{id}")]
    public async Task<IActionResult> RemoveUser(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<User>(id)));
    }
    
    [HttpPost("update_user")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        return Ok(await mediator.Send(new UpdateEntity<User>(user)));
    }
}
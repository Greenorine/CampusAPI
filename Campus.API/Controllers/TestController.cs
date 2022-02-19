using Campus.Db.Entities;
using Campus.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly ILogger<TestController> logger;

    public TestController(ILogger<TestController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        return Ok(await mediator.Send(new UpsertEntity<User>(user)));
    }
    
    [HttpGet("get1")]
    public async Task<IActionResult> Get1(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<User>(id)));
    }
    
    [HttpGet("Get2")]
    public async Task<IActionResult> Get2(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<User>(id)));
    }
}
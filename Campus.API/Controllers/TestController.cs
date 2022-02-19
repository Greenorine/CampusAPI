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

    [HttpGet(Name = "test")]
    public async Task<IActionResult> Get()
    {
        return Ok(await mediator.Send(new GetAllEntities<User>()));
    }
}
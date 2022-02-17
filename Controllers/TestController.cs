using CampusAPI.Db.Entities;
using CampusAPI.Model.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CampusAPI.Controllers;

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
        return Ok(await mediator.Send(new GetEntityById<Client>(Guid.Parse("7935d8d8-e3e7-48ec-b4e0-fd5caad63669"))));
    }
}
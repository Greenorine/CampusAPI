using Microsoft.AspNetCore.Mvc;

namespace CampusAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> logger;

    public TestController(ILogger<TestController> logger)
    {
        this.logger = logger;
    }

    [HttpGet(Name = "test")]
    public string Get()
    {
        return "Test controller works!";
    }
}
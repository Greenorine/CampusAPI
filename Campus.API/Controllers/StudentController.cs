using Campus.Db.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Campus.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentInfoController : ControllerBase
{
    private readonly IMediator mediator;

    public StudentInfoController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet("get_info/{id}")]
    public async Task<IActionResult> GetInfo(Guid id)
    {
        return Ok(await mediator.Send(new GetEntityById<StudentInfo>(id)));
    }

    [HttpGet("get_all_info")]
    public async Task<IActionResult> GetAllGroup()
    {
        return Ok(await mediator.Send(new GetAllEntities<StudentInfo>()));
    }

    [HttpPost("save_info")]
    public async Task<IActionResult> SaveInfo(StudentInfo info)
    {
        var studentInfo = new StudentInfo();
        return Ok(await mediator.Send(new SaveEntity<StudentInfo>(info)));
    }
    
    [HttpDelete("remove_info/{id}")]
    public async Task<IActionResult> RemoveInfo(Guid id)
    {
        return Ok(await mediator.Send(new DeleteEntityById<StudentInfo>(id)));
    }
}
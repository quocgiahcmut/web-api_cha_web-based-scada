namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTagCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}

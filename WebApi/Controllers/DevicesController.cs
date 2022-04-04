namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DevicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DevicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDeviceCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}

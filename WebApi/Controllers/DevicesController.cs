﻿namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DevicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DevicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDevices()
    {
        var result = await _mediator.Send(new GetAllDevicesQuery());

        return Ok(result);
    }

    [HttpGet("{deviceId}")]
    public async Task<IActionResult> GetById(string deviceId)
    {
        var query = new GetDeviceByIdQuery(deviceId);

        var result = await _mediator.Send(query);

        return Ok(result);
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

    [HttpDelete("{deviceId}")]
    public async Task<IActionResult> Delete(string deviceId)
    {
        var command = new DeleteDeviceCommand(deviceId);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}

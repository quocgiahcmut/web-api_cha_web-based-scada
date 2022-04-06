﻿namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NodesController : ControllerBase
{
    private readonly IMediator _mediator;

    public NodesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateNodeCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{eonNodeId}")]
    public async Task<IActionResult> Delete(string eonNodeId)
    {
        var command = new DeleteNodeCommand(eonNodeId);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }

}

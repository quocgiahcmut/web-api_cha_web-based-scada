﻿namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly SparkplugDataAdapter _sparkplugDataAdapter;

    public TagsController(IMediator mediator, SparkplugDataAdapter sparkplugDataAdapter)
    {
        _mediator = mediator;
        _sparkplugDataAdapter = sparkplugDataAdapter;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var result = await _mediator.Send(new GetAllTagsQuery());

        return Ok(result);
    }

    [HttpGet("{tagName}")]
    public async Task<IActionResult> GetById(string tagName)
    {
        var query = new GetTagByTagNameQuery(tagName);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTagCommand command)
    {
        var result = await _mediator.Send(command);

        if(!result)
        {
            return BadRequest();
        }

        _sparkplugDataAdapter.AddKnownMetric(command.TagName, command.DataType);

        return Ok();
    }

    [HttpDelete("{tagName}")]
    public async Task<IActionResult> Detele(string tagName)
    {
        var command = new DeleteTagCommand(tagName);

        var result = await _mediator.Send(command);

        if (!result)
        {
            return BadRequest();
        }

        return Ok();
    }
}

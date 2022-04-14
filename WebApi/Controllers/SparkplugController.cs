using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SparkplugController : ControllerBase
{
    private readonly SparkplugDataAdapter _sparkplugDataAdapter;
    private readonly IMediator _mediator;

    public SparkplugController(SparkplugDataAdapter sparkplugDataAdapter, IMediator mediator)
    {
        _sparkplugDataAdapter = sparkplugDataAdapter;
        _mediator = mediator;
    }

    [HttpGet("start-application")]
    public async Task<IActionResult> StartSparkplugApplication()
    {
        try
        {
            await _sparkplugDataAdapter.StartApplicationAsync();

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("stop-application")]
    public async Task<IActionResult> StopSparkplugApplication()
    {
        try
        {
            await _sparkplugDataAdapter.StopApplicationAsync();

            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("knownmetrics")]
    public IActionResult GetKnownMetrics()
    {
        return Ok(_sparkplugDataAdapter.KnownMetrics());
    }

    [HttpGet("loadknownmetrics")]
    public async Task<IActionResult> LoadKnownMetrics()
    {
        var result = await _mediator.Send(new GetAllTagsQuery());

        foreach(Tag tag in result)
        {
            _sparkplugDataAdapter.AddKnownMetric(tag.Name, tag.DataType);
        }

        return Ok(_sparkplugDataAdapter.KnownMetrics());
    }
}

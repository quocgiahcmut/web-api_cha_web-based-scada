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
        var result = _sparkplugDataAdapter.KnownMetrics();

        List<string> listName = result.Select(r => r.Name).ToList();

        return Ok(listName);
    }

    [HttpGet("loadknownmetrics")]
    public async Task<IActionResult> LoadKnownMetrics()
    {
        var result = await _mediator.Send(new GetAllTagsQuery());

        List<string> listName = _sparkplugDataAdapter.KnownMetrics().Select(r => r.Name).ToList();

        foreach(Tag tag in result)
        {
            int index = listName.IndexOf(tag.Name);

            if (index == -1)
            {
                _sparkplugDataAdapter.AddKnownMetric(tag.Name, tag.DataType);
            }           
        }

        listName = _sparkplugDataAdapter.KnownMetrics().Select(r => r.Name).ToList();

        return Ok(listName);
    }
}

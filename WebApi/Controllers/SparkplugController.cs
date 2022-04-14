using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SparkplugController : ControllerBase
{
    private readonly SparkplugDataAdapter _sparkplugDataAdapter;

    public SparkplugController(SparkplugDataAdapter sparkplugDataAdapter)
    {
        _sparkplugDataAdapter = sparkplugDataAdapter;
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
}

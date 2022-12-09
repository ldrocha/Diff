using Microsoft.AspNetCore.Mvc;

namespace Diff.Api.Controllers;

[ApiController]
[Route("/v{version:apiVersion}/[controller]/{Id}")]
public class DiffController : ControllerBase
{

    private readonly ILogger<DiffController> _logger;

    public DiffController(ILogger<DiffController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public object Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
        })
        .ToArray();
    }

    [HttpPut("left")]
    public object PutLeft()
    {
        return Results.Created("string", new object());
    }

    [HttpPut("right")]
    public object PutRight()
    {
        return Results.Created("string", new object());
    }
}


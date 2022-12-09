using Microsoft.AspNetCore.Mvc;

namespace Diff.Api.Controllers;

[ApiController]
[Route("/v{version:apiVersion}/[controller]/{id}")]
public class DiffController : ControllerBase
{

    private readonly ILogger<DiffController> _logger;

    public DiffController(ILogger<DiffController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new OkObjectResult("");
    }

    [HttpGet ("left", Name = nameof(GetLeft))]
    public IActionResult GetLeft()
    {
        return new OkObjectResult("");
    }

    [HttpGet("right")]
    public IActionResult GetRight([FromRoute] string id)
    {
        return new OkObjectResult("");
    }

    [HttpPut("left")]
    public IActionResult PutLeft()
    {
        return new CreatedAtRouteResult(nameof(GetLeft), "teesste");  
    }

    [HttpPut("right")]
    public IActionResult PutRight([FromRoute] string id)
    {

        var createdResource = new { Id = id, Version = "1" };
        var actionName = nameof(GetRight);
        var routeValues = new { id = createdResource.Id, version = createdResource.Version };
        return CreatedAtAction(actionName, routeValues, createdResource);
    }
}


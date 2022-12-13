using System;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Diff.Api.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("/v{version:apiVersion}/diff/{id}")]
public class DiffController : ControllerBase
{

    private readonly ILogger<DiffController> _logger;

    public DiffController(ILogger<DiffController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get the difference status between left and right from an especific Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET 123
    ///
    /// </remarks>
    /// <response code="200">Returns the differece status</response>
    [HttpGet]
    public ActionResult<DifferenceResponse> Get([FromRoute] string id)
    {
        return new OkObjectResult(new DifferenceResponse());
    }

    /// <summary>
    /// Get a Left Base64 Encoded Binary Data
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET 123/left
    ///
    /// </remarks>
    /// <response code="200">Returns the item</response>
    [HttpGet ("left")]
    public ActionResult<LeftBase64EncodedBinaryResponse> GetLeft([FromRoute] string id)
    {
        return new LeftBase64EncodedBinaryResponse();

        //return NotFound();
    }

    /// <summary>
    /// Get a Right Base64 Encoded Binary Data
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET 123/right
    ///
    /// </remarks>
    /// <response code="200">Returns the item</response>
    [HttpGet("right")]
    public ActionResult<RightBase64EncodedBinaryResponse> GetRight([FromRoute] string id)
    {
        return new RightBase64EncodedBinaryResponse();
    }

    /// <summary>
    /// Create or Update a Left Base64 Encoded Binary Data
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT 123/left
    ///     {
    ///        "data": "aGVsbG8gd29ybGQgISEh",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly item</response>
    [HttpPut("left")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<LeftBase64EncodedBinaryResponse> PutLeft(
        [FromRoute] string version,
        [FromRoute] string id,
        [FromBody] LeftBase64EncodedBinaryRequest leftBase64EncodedBinaryRequest)
    {
        leftBase64EncodedBinaryRequest.Id = id;
        var createdResource = new  LeftBase64EncodedBinaryResponse{ Id = id, Data = "hihi" };
        var actionName = nameof(GetLeft);
        var routeValues = new { id = createdResource.Id, version = version };
        return CreatedAtAction(actionName, routeValues, createdResource);
    }

    /// <summary>
    /// Create or Update a Right Base64 Encoded Binary Data
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT 123/right
    ///     {
    ///        "data": "aGVsbG8gd29ybGQgISEh",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly item</response>
    [HttpPut("right")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<RightBase64EncodedBinaryResponse> PutRight(
        [FromRoute] string version,
        [FromRoute] string id,
        [FromBody] RightBase64EncodedBinaryRequest rightBase64EncodedBinaryRequest)
    {
        rightBase64EncodedBinaryRequest.Id = id;
        var createdResource = new RightBase64EncodedBinaryResponse { Id = id, Data = "hijhhi" };
        var actionName = nameof(GetRight);
        var routeValues = new { id = createdResource.Id, version = version };
        return CreatedAtAction(actionName, routeValues, createdResource);
    }
}


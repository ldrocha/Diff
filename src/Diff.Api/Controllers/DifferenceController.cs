using System;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Requests;
using Diff.ApplicationCore.Responses;
using Diff.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Diff.Api.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("/v{version:apiVersion}/diff/{id}")]
public class DiffController : ControllerBase
{
    public ILogger<DiffController> Logger { get; }
    public IDifferenceService DifferenceService { get; }
    public ILeftBase64EncodedBinaryService LeftBase64EncodedBinaryService  { get;}
    public IRightBase64EncodedBinaryService RightBase64EncodedBinaryService { get; }

    public DiffController(
        ILogger<DiffController> logger,
        IDifferenceService differenceService,
        ILeftBase64EncodedBinaryService leftBase64EncodedBinaryService,
        IRightBase64EncodedBinaryService rightBase64EncodedBinaryService)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        DifferenceService = differenceService ?? throw new ArgumentNullException(nameof(differenceService));
        LeftBase64EncodedBinaryService = leftBase64EncodedBinaryService ?? throw new ArgumentNullException(nameof(leftBase64EncodedBinaryService));
        RightBase64EncodedBinaryService = rightBase64EncodedBinaryService ?? throw new ArgumentNullException(nameof(rightBase64EncodedBinaryService));
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
    /// <response code="404">If one or both items compared do not exist the answer will be not found</response>
    [HttpGet]
    public async Task<ActionResult<DifferenceResponse>> Get([FromRoute] string id)
    {
        var response = await DifferenceService.Get(id);

        if (response == null)
            return NotFound();

        return new OkObjectResult(response);
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
    /// <response code="404"></response>
    [HttpGet ("left")]
    public async Task<ActionResult<LeftBase64EncodedBinaryResponse>> GetLeft([FromRoute] string id)
    {
        var response = await LeftBase64EncodedBinaryService.Get(id);

        if (response == null)
            return NotFound();

        return new OkObjectResult(response);
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
    /// <response code="404"></response>
    [HttpGet("right")]
    public async Task<ActionResult<RightBase64EncodedBinaryResponse>> GetRight([FromRoute] string id)
    {
        var response = await RightBase64EncodedBinaryService.Get(id);

        if (response == null)
            return NotFound();

        return new OkObjectResult(response);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<LeftBase64EncodedBinaryResponse>> PutLeft(
        [FromRoute] string version,
        [FromRoute] string id,
        [FromBody] LeftBase64EncodedBinaryRequest leftBase64EncodedBinaryRequest)
    {
        if (!IsBase64String(leftBase64EncodedBinaryRequest.Data))
            return BadRequest("Invalid base64 encoded binary");

        leftBase64EncodedBinaryRequest.Id = id;

        await LeftBase64EncodedBinaryService.AddOrUpdate(leftBase64EncodedBinaryRequest);

        var response = await LeftBase64EncodedBinaryService.Get(id);

        var actionName = nameof(GetLeft);
        var routeValues = new { id = response.Id, version = version };
        return CreatedAtAction(actionName, routeValues, response);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<RightBase64EncodedBinaryResponse>> PutRight(
        [FromRoute] string version,
        [FromRoute] string id,
        [FromBody] RightBase64EncodedBinaryRequest rightBase64EncodedBinaryRequest)
    {
        if (!IsBase64String(rightBase64EncodedBinaryRequest.Data))
            return BadRequest("Invalid base64 encoded binary");

        rightBase64EncodedBinaryRequest.Id = id;

        await RightBase64EncodedBinaryService.AddOrUpdate(rightBase64EncodedBinaryRequest);

        var response = await RightBase64EncodedBinaryService.Get(id);

        var actionName = nameof(GetRight);
        var routeValues = new { id = response.Id, version = version };
        return CreatedAtAction(actionName, routeValues, response);
    }

    public static bool IsBase64String(string base64)
    {
        Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
        return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
    }
}
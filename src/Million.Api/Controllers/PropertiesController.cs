

using Million.Application.Dto;

namespace Million.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PropertiesController> _logger;

    public PropertiesController(IMediator mediator, ILogger<PropertiesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPropertiesQuery query)
    {
        _logger.LogInformation($"Call GET whith filter: {@query}");
        var result = await _mediator.Send(query);
        return Ok(ApiResponse<List<PropertyDto>>.SuccessResponse(result));
    }
}

using Microsoft.AspNetCore.Mvc;

namespace UFO.ProfileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(ILogger<UsersController> logger) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Get Values");
        return Ok(new Dictionary<string, string> { { "key", "value" } });
    }
}
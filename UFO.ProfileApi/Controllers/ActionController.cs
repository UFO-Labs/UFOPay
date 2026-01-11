using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UFO.ProfileApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public class ActionController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return Ok("test.");
    }
}

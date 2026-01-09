using Microsoft.AspNetCore.Mvc;
using UFO.ProfileApi.DTOs;

namespace UFO.ProfileApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult SignUp(UserDTO userDTO)
    {
        return Ok(new Dictionary<string, string> { { "key", "value" } });
    }
}

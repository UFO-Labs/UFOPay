using Microsoft.AspNetCore.Mvc;
using UFO.ProfileApi.DTOs;
using UFO.ProfileApi.Services.Interfaces;
using UFO.ProfileApi.Shared.Exceptions;

namespace UFO.ProfileApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="userDTO"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp(UserDTO userDTO)
    {
        if (await _userService.CreateAsync(userDTO))
        {
            return Ok(new SuccessResponse(200, "User successfully created"));
        }

        return BadRequest(new ErrorResponse(400, "Error creating!"));
    }
}

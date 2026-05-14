using Microsoft.AspNetCore.Mvc;
using src.Users.DTOs;
using src.Users.Services;

namespace src.Users;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<UserResponseDto>> Create([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var created = await _userService.CreateAsync(dto, cancellationToken);
            return Created($"/api/users/{created.Id}", created);
        }
        catch (DuplicateEmailException)
        {
            return Conflict(new { message = "Email already registered." });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<UserResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<UserResponseDto>>> GetAll(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        return Ok(users);
    }
}

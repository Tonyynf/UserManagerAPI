using Microsoft.AspNetCore.Mvc;
using UserManagerAPI.Models;
using UserManagerAPI.Services;

namespace UserManagerAPI.Controllers;

[ApiController]
[Route("api/users")] 
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        var createdUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound(new { message = "Usuário não encontrado!" });

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var updatedUser = _userService.UpdateUser(id, user);
        if (updatedUser == null)
            return NotFound(new { message = "Usuário não encontrado!" });

        return Ok(updatedUser);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var deleted = _userService.DeleteUser(id);
        if (!deleted)
            return NotFound(new { message = "Usuário não encontrado!" });

        return NoContent();
    }
}

using UserManagerAPI.Models;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase{
    private readonly UserService _userService;

    public UserController(UserService userService){
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user){
        var createdUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUser), new{ id = createdUser.Id}, createdUserUser);
    }
}
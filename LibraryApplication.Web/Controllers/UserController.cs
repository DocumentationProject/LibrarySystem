using LibraryApplication.Attributes;
using LibraryApplication.Data.Interfaces.Services;
using LibraryApplication.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthModel authModel)
    {
        var id = await this.userService.Authenticate(authModel.Login, authModel.Password);
        return id is null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(id);
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<UserModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await this.userService.GetAll());
    }

    [HttpGet("{id:int}")]
    [ExistingUser]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await this.userService.GetById(id));
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] UserModel userModel)
    {
        var id = await this.userService.Create(userModel);
        return Ok(id);
    }

    [HttpPut("{id:int}/edit")]
    [ExistingUser]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(int id, [FromBody] UserModel userModel)
    {
        var updated = await this.userService.Update(id, userModel);
        return Ok(updated);
    }
    
    [HttpDelete("{id:int}/delete")]
    [ExistingUser]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await this.userService.Delete(id);
        return Ok(deleted);
    }

    [HttpGet("{id:int}/fines")]
    [ExistingUser]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckIfUserHasFines(int id)
    {
        return Ok(await this.userService.HasFines(id));
    }
    
    [HttpPost("process-fine")]
    [ExistingUser]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ProcessUserFine([FromBody] int userId, int bookId)
    {
        return Ok(await this.userService.TryProcessFinePayment(userId, bookId));
    }
}
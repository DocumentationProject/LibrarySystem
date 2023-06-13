using AutoMapper;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;
using LibraryApplication.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserController(IUserService userService, IUserRepository userRepository, IMapper mapper)
    {
        this.userService = userService;
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] string login, string password)
    {
        var id = await this.userService.Authenticate(login, password);
        return id is null ? StatusCode(StatusCodes.Status401Unauthorized) : Ok(id);
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<UserModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await this.userRepository.GetAll();
        return Ok(this.mapper.Map<List<UserModel>>(users));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await this.userRepository.GetById(id);
        return user is null ? StatusCode(StatusCodes.Status404NotFound) : Ok(this.mapper.Map<UserModel>(user));
    }

    [HttpGet("{id:int}/fines")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckIfUserHasFines(int id)
    {
        return Ok(await this.userService.HasFines(id));
    }
    
    [HttpPost("process-fine")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ProcessUserFine([FromBody] int userId, int bookId)
    {
        return Ok(await this.userService.TryProcessFinePayment(userId, bookId));
    }
}
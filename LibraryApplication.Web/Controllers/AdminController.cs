using LibraryApplication.Data.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAdminService adminService;

    public AdminController(IAdminService adminService)
    {
        this.adminService = adminService;
    }

    [HttpPost("generate-past-fines")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GenerateFines([FromBody] int amount)
    {
        await this.adminService.GenerateFinesPastDueDate(amount);
        return Ok();
    }

    [HttpPost("generate-damage-fines")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GenerateFineForBookDamage([FromBody] int bookId, int amount)
    {
        await this.adminService.GenerateFineForBookDamage(bookId, amount);
        return Ok();
    }
}
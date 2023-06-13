using AutoMapper;
using LibraryApplication.Data.Interfaces.Repositories;
using LibraryApplication.Data.Interfaces.Services;
using LibraryApplication.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository bookRepository;
    private readonly IBookService bookService;
    private readonly IMapper mapper;

    public BookController(IBookRepository bookRepository, IBookService bookService, IMapper mapper)
    {
        this.bookRepository = bookRepository;
        this.bookService = bookService;
        this.mapper = mapper;
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<BookModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await this.bookRepository.GetAll();
        return Ok(this.mapper.Map<List<BookModel>>(users));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await this.bookRepository.GetById(id);
        return user is null ? StatusCode(StatusCodes.Status404NotFound) : Ok(this.mapper.Map<BookModel>(user));
    }

    [HttpPost("{id:int}/borrow")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BorrowBook([FromBody] int id, int userId, int? discountId, int rentInDays)
    {
        return Ok(await this.bookService.TryBorrowBook(id, userId, discountId, rentInDays));
    }
    
    [HttpPost("{id:int}/return")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ReturnBook([FromBody] int id, int userId)
    {
        return Ok(await this.bookService.TryReturnBook(id, userId));
    }
}
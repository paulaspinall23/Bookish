using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers;

[Route("books")]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly BookishDbContext _context;

    public BookController
    (
        ILogger<BookController> logger,
        BookishDbContext context
    ){
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult Book([FromRoute] int id)
    {
        var books = _context.Books.Include(b => b.Author);
        var book= books.Single(b => b.Id == id);

        return View(book);
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var books = _context.Books
            .Include(b => b.Author)
            .ToList();

        return View(books);
    }
}

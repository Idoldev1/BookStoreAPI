using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;


[Route("api/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IServices _services;

    public BookController(IServices services)
    {
        _services = services;
    }


    [HttpGet]
    [ProducesResponseType(200)]
    public IActionResult GetBooks()
    {
        var books = _services.BookServices.GetAllBook(trackChanges: false);
        return Ok(books);
    }


    [HttpGet("{Id}")]
    [ProducesResponseType(200, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public IActionResult GetBookById(string Id)
    {
        var book = _services.BookServices.GetBook(Id, trackChanges: false);

        return Ok(book);
    }


    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult AddBook([FromBody]BookInputDto createBook)
    {
        if (createBook is null)
                return BadRequest("Invalid details for creating book");
        var createdBook = _services.BookServices.AddBook(createBook);

        return CreatedAtRoute("BookById", new { id = createdBook.Id }, createdBook);

    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBook(string bookId)
    {
        _services.BookServices.DeleteBook(bookId, trackChanges: false);
        
        return NoContent();
    }


    [HttpPut("{id:guid}")]
    public IActionResult UpdateBook(string Id, [FromBody] BookInputDto book)
    {
        if (book is null)
                return BadRequest("Detail requested for doesn't exist");
        _services.BookServices.UpdateBook(Id, book, trackChanges : false);

        return NoContent();
    }
}
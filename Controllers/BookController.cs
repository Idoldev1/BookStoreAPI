using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Sevices;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookServices _services;

    public BookController(BookServices services)
    {
        _services = services;
    }



    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _services.GetAllBook(trackChanges: false);
        return Ok(books);
    }


    [HttpPost]
    [Route("AddBook")]
    public IActionResult AddNewBook(AddBookDto book)
    {
        var addBook = _services.AddBook(book);

        return Ok(addBook);
    }


    [HttpGet]
    [Route("get_by_Id")]
    public IActionResult GetABookById(int Id)
    {
        var bookId = _services.GetBookById(Id, trackChanges: false);

        return Ok(bookId);
    }


    [HttpGet]
    [Route("get_by_title")]
    public IActionResult GetABookByTitle(string title)
    {
        var titleBook = _services.GetBookByTitle(title);

        return Ok(titleBook);
    }


    [HttpDelete]
    [Route("deleteBook")]
    public IActionResult DeleteBook(int Id, bool trackChanges)
    {
        _services.Delete(Id, trackChanges: false);

        return Ok();
    }


    [HttpPut]
    [Route("updateBook")]
    public IActionResult UpdateBook(int Id, Book bookInputDto, bool trackChanges)
    {
        _services.UpdateBook(Id, bookInputDto, trackChanges: false);

        return Ok();
    }
}
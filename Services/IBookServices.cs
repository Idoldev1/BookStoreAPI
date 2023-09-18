using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services;

public interface IBookServices
{
    IEnumerable<Book> GetAllBook(bool trackChanges);
    BookDto GetBook(string Id, bool trackChanges);
    BookDto AddBook(BookInputDto book);
    void DeleteBook(string Id, bool trackChanges);
    void UpdateBook(string Id, BookInputDto bookInputDto, bool trackChanges);
}
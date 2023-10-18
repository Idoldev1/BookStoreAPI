using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repository; 

public interface IBookstoreRepository
{
    IEnumerable<Book> GetAllBook(bool trackChanges);
    Book GetBookTitle(string title);
    Book GetBookId(int Id, bool trackChanges);
    Book AddBook(AddBookDto book);
    void DeleteBook (int Id, bool trackChanges);
    void UpdateBook (int Id, Book newBook, bool trackChanges);
    bool SaveMethod();
}
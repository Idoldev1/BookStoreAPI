using System;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repository;

public interface IBookstoreRepository
{
    IEnumerable<Book> GetAllBook(bool trackChanges);
    Book GetBookTitle(string title);
    Book GetBookId(string Id, bool trackChanges);
    void AddBook (Book book);
    void DeleteBook (Book book);
    void UpdateBook (string Id, BookInputDto bookInputDto);
    bool SaveMethod();
}
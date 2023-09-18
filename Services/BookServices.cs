using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Exceptions;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using BookStoreAPI.Services;
using Microsoft.Extensions.Caching.Memory;

namespace BookStoreAPI.Sevices;


internal sealed class BookServices : IBookServices
{
    private readonly IRepositoryManager _bookstoreRepository;
    private readonly IMapper mapper;
    //private readonly ILogger logger;

    public BookServices(IRepositoryManager bookstoreRepository
                        ,IMapper mapper)
    {
        _bookstoreRepository = bookstoreRepository;
        this.mapper = mapper;
    }

    public BookDto AddBook(BookInputDto book)
    {
        var bookEntity = mapper.Map<Book>(book);

        _bookstoreRepository.BookstoreRepository.AddBook(bookEntity);
        _bookstoreRepository.Save();

        var bookReturn = mapper.Map<BookDto>(bookEntity);

        return bookReturn;
    }

    public void DeleteBook(string Id, bool trackChanges)
    {
        var book = _bookstoreRepository.BookstoreRepository.GetBookId(Id, trackChanges);

        if (book == null)
            throw new BookNotFoundException(Id);

        _bookstoreRepository.BookstoreRepository.DeleteBook(book);

        _bookstoreRepository.Save();
    }

    public IEnumerable<Book> GetAllBook(bool trackChanges)
    {
        var book = _bookstoreRepository.BookstoreRepository.GetAllBook(trackChanges);
        var bookDto = mapper.Map<IEnumerable<Book>>(book);

        return bookDto;
    }

    public BookDto GetBook(string Id, bool trackChanges)
    {
        //logger.LogInformation("Request Made For A Book");

        var book = _bookstoreRepository.BookstoreRepository.GetBookId(Id, trackChanges);

        //check if the book is null
        if (book is null)
                throw new BookNotFoundException(Id);

        var bookDto = mapper.Map<BookDto>(Id);
        return bookDto;
    }

    public void UpdateBook(string Id, BookInputDto bookInputDto, bool trackChanges)
    {
        var book = _bookstoreRepository.BookstoreRepository.GetBookId(Id, trackChanges);

        if (book == null)
            throw new BookNotFoundException(Id);
        
        mapper.Map(bookInputDto, book);
        _bookstoreRepository.Save();
    }
}
using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Exceptions;
using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BookStoreAPI.Sevices;


public class BookServices
{
    private readonly IBookstoreRepository bookstoreRepository;
    private readonly IMapper _mapper;

    public BookServices(IBookstoreRepository bookstoreRepository, IMapper mapper)
    {
        this.bookstoreRepository = bookstoreRepository;
        _mapper = mapper;
    }

    public GetBookDto AddBook([FromBody]AddBookDto book)
    {
        //create a var to map the incoming data to the original properties in your solution
        var addBook = bookstoreRepository.AddBook(book);
        var newBook = _mapper.Map<GetBookDto>(addBook);

        return newBook;
    }

    public void Delete(int Id, bool trackChanges)
    {
        bookstoreRepository.DeleteBook(Id, trackChanges);
    }

    public IEnumerable<GetBookDto> GetAllBook(bool trackChanges)
    {
        try
        {   
            var books = bookstoreRepository.GetAllBook(trackChanges);
            var getAllBooks = _mapper.Map<List<GetBookDto>>(books);

            return getAllBooks;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public GetBookDto GetBookById(int Id, bool trackChanges)
    {
        if (Id <= 0)
        {
            // Handles the case where the provided ID is invalid (e.g., less than or equal to 0)
            throw new ArgumentException("Please input a valid Id.");
        }

        var book = bookstoreRepository.GetBookId(Id, trackChanges);
        if (book == null)
        {
            // Handles the case where the book with the provided ID does not exist
            throw new NotFoundException("Book not found with the specified ID.");
        }
        var getBook = _mapper.Map<GetBookDto>(book);

        return getBook;
    }


    public GetBookDto GetBookByTitle(string title)
    {
        var book = bookstoreRepository.GetBookTitle(title);
        var bookTitle = _mapper.Map<GetBookDto>(book);

        return bookTitle;
    }

    public void UpdateBook(int Id, Book bookInputDto, bool trackChanges) 
    {
        //bookstoreRepository.UpdateBook(Id, bookInputDto, trackChanges);
        _mapper.Map<UpdateBookDto>(bookInputDto);
        bookstoreRepository.UpdateBook(Id, bookInputDto, trackChanges);
    }
    
}
using BookStoreAPI.DAL;
using BookStoreAPI.DTOs;
using BookStoreAPI.Exceptions;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repository;


public class BookstoreRepository : IBookstoreRepository
{
    private readonly BookStoreDbContext _context;

    public BookstoreRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public Book AddBook(AddBookDto book)
    {
        var newBook = new Book
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Publisher = book.Publisher,
            Description = book.Description,
            Category = book.Category,
            Price = book.Price
        };

        _context.Books.Add(newBook);
        SaveMethod();

        return newBook;
    }

    public void DeleteBook(int Id, bool trackChanges)
    {
        var book = _context.Books.Find(Id);

        if (book == null)
        {
            throw new BookNotFoundException(Id);
        }
        _context.Books.Remove(book);
        SaveMethod();
    }

    public IEnumerable<Book> GetAllBook(bool trackChanges)
    {
        return _context.Books.ToList();
    }

    public Book GetBookId(int Id, bool trackChanges)
    {
        var book = _context.Books.Where(b => b.Id == Id).SingleOrDefault();
        if (book is null)
        {
            throw new Exception($"Details for book with Id {Id} not found");
        }
        return book;
    }

    public Book GetBookTitle(string title)
    {
        var book = _context.Books.Where(b => b.Title == title).SingleOrDefault();
        if (book == null)
        {
            throw new Exception($"Detail for book with the title{title} not found");
        }
        return book;
    }

    public bool SaveMethod()
    {
        var saved =_context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public void UpdateBook(int Id, Book newBook, bool trackChanges)
    {
        var book = _context.Books.Find(Id);

        if(book != null)
        {
            /*book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Publisher = newBook.Publisher;
            book.Category = newBook.Category;
            book.Description = newBook.Description;
            book.Price = newBook.Price;
            book.Rating = newBook.Rating;*/

            _context.Books.Update(book);
            SaveMethod();
        }
        else
        {
            new BookNotFoundException(Id);
        }
        
    }
}
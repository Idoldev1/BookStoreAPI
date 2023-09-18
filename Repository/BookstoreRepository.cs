using BookStoreAPI.DAL;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repository;


public class BookstoreRepository : RepositoryBase<Book>, IBookstoreRepository
{
    public BookstoreRepository(BookStoreDbContext context) : base(context)
    {

    }

    public void AddBook(Book book) => Add(book);

    public void DeleteBook(Book book) => Delete(book);

    public IEnumerable<Book> GetAllBook(bool trackChanges)
    {
        return FindAll(trackChanges).OrderBy(b => b.Author).ToList();
    }

    public Book GetBookId(string Id, bool trackChanges)
    {
        return GetById(b => b.Id.Equals(Id), trackChanges).FirstOrDefault();
    }

    public Book GetBookTitle(string title)
    {
        return GetByTitle(b => b.Title.Equals(title)).FirstOrDefault();
    }

    public bool SaveMethod() => Save();

    public void UpdateBook(string Id, BookInputDto bookInputDto)
    {
        
    }
}
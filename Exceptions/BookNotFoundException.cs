namespace BookStoreAPI.Exceptions;


public sealed class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(int bookId) :base ($"The book with Id: {bookId} doesn't exist in the database.")
    {
        
    }
}
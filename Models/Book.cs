using BookStoreAPI.DAL.Enum;

namespace BookStoreAPI.Models;


public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
    public Genre Category { get; set; }
    public double Price { get; set; }
    public DateTime PublishDate { get; set; }
    public double Rating { get; set; }
}
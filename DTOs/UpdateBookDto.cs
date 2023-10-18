using BookStoreAPI.DAL.Enum;

namespace BookStoreAPI.DTOs;


public class UpdateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public Genre Category { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
}
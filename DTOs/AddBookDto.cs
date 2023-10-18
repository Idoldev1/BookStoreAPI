using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DAL.Enum;

namespace BookStoreAPI.DTOs;


public class AddBookDto
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
    public Genre Category { get; set; }
    public double Price { get; set; }
}
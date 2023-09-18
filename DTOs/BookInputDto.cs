using System.ComponentModel.DataAnnotations;
using BookStoreAPI.DAL.Enum;

namespace BookStoreAPI.DTOs;


public record BookInputDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Title cannot exceed 30 characters")]
    public string Title { get; set; }

    [Required]
    [MaxLength(30, ErrorMessage = "Author cannot exceed 30 characters")]
    public string Author { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Description cannot exceed 50 characters")]
    public string Description { get; set; }

    [Required]
    public Genre Category { get; set; }
}
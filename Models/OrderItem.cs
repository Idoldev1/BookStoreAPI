using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models;

public class OrderItem
{
    [Key]
    public int BookId { get; set; }
    public int Quantity { get; set; }
}
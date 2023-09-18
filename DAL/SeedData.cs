using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.DAL;


public static class SeedData
{
    public static void  Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzerald",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Enum.Genre.Horror,
                Price = 30,
                PublishDate = new DateTime(2007,10,15),
                Rating = 8.9
            },
            new Book
            {
                Id = Guid.NewGuid().ToString(),
                Title = "The Wrath of man",
                Author = "TMI",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Enum.Genre.Mystery,
                Price = 25,
                PublishDate = new DateTime(2002,04,19),
                Rating = 9.3
            }
        );
    }
}
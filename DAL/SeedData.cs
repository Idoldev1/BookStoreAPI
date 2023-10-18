using BookStoreAPI.DAL.Enum;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.DAL;


public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzerald",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Genre.Horror,
                Price = 30,
                PublishDate = new DateTime(2007,10,15),
                Rating = 8.9
            },
            new Book
            {
                Id = 2,
                Title = "The Wrath of man",
                Author = "TMI",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Genre.Mystery,
                Price = 25,
                PublishDate = new DateTime(2002,04,19),
                Rating = 9.3
            },
            new Book
            {
                Id = 3,
                Title = "Hand of God",
                Author = "Idoldev",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Genre.Mystery,
                Price = 25,
                PublishDate = new DateTime(2002,04,22),
                Rating = 8.0
            },
            new Book
            {
                Id = 4,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzerald",
                Publisher = "Micheal Oliver",
                Description = "",
                Category = Genre.Fiction,
                Price = 30,
                PublishDate = new DateTime(2007,10,15),
                Rating = 8.9
            }
        );
    }
}
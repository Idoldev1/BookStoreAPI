using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Category", "Description", "Price", "PublishDate", "Publisher", "Rating", "Title" },
                values: new object[] { 4, "F. Scott Fitzerald", 0, "", 30.0, new DateTime(2007, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micheal Oliver", 8.9000000000000004, "The Great Gatsby" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

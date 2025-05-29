using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BT6.Migrations
{
    /// <inheritdoc />
    public partial class Themdulieu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert data into Category table
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" }
                });

            // Insert data into Product table
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Description", "Price", "ImageUrl", "CategoryId" },
                values: new object[,]
                {
                    { 1, "Laptop", "Powerful laptop for work and gaming", 1200.00m, "https://example.com/laptop.jpg", 1 },
                    { 2, "Smartphone", "Latest model smartphone", 800.00m, "https://example.com/smartphone.jpg", 1 },
                    { 3, "The Lord of the Rings", "Fantasy novel series", 25.50m, "https://example.com/lotr.jpg", 2 },
                    { 4, "T-Shirt", "Comfortable cotton t-shirt", 15.99m, "https://example.com/tshirt.jpg", 3 }
                });

            // If you have ProductImages and want to link them, you would also insert here.
            // Example for ProductImage (assuming ProductId 1 has an image):
            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Url", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://example.com/laptop_detail_1.jpg", 1 },
                    { 2, "https://example.com/laptop_detail_2.jpg", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert the data insertion in reverse order
            // Delete data from ProductImage table
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2 } // Or specify a condition if needed
            );

            // Delete data from Product table
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 } // Or specify a condition if needed
            );

            // Delete data from Category table
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 } // Or specify a condition if needed
            );
        }
    }
}
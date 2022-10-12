using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce_1.Migrations
{
    public partial class q : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Shirts", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shirt icon.png", "Shirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Pants", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\pants icon.png", "Pants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "dresses", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\dress icon.png", "Dress" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Shoes", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shoe icon.png", "Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 3, "Balenciaga v-neck green dress", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Balenciaga dress.jpg", "Balenciaga Dress", "2000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 4, "Elegant brown business dress shoe", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\elegant business dress shoe.jpg", "Dress Shoes", "200" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 4, "Hermes black noir heel sandal", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\hermes black noir oasis heel sandal.jpg", "Hermes Noir Sandal", "500" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Louis Vuitton Destroyed Carpenter Denim Pants", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\Louis vuitton Destroyed Carpenter denim pants.jpg", "Louis Vuitton Denim Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 1, "Blue Gucci Shirt", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\men gucci shirt.jpg", "Gucci Shirt", "800" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 4, "Nike Winflo 8 Road Running shoes", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\nike winflo 8 mens road running shoes.jpg", "Nike Road Running shoes", "300" },
                    { 7, 1, "Gucci Brown Long Sleeve Shirt", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\women gucci shirt.jpg", "Gucci Long Sleeve Shirt", "300" },
                    { 8, 1, "Zara Greeb Long Sleeve Shirt", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Product Images\\zara shirt.jpg", "Zara Long Sleeve Shirt", "150" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Shoes", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shoe icon.png", "Shoes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Shirts", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\shirt icon.png", "Shirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "Pants", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\pants icon.png", "Pants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "dresses", "C:\\Users\\fatma.alsayegh\\source\\repos\\E-commerce-1\\E-commerce-1\\wwwroot\\Category Images\\dress icon.png", "Dress" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 1, "sport shoes", null, "Nike", "100" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 1, "sport shoes", null, "Adidas", "150" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 2, "zara shirt", null, "zara", "250" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Icon", "Name" },
                values: new object[] { "shirt", null, "H&M" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[] { 3, "pants", null, "H&M", "100" });
        }
    }
}

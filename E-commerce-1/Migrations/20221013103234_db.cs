using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce_1.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    ProductCount = table.Column<int>(nullable: false),
                    TotalCost = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Roles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_User_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Orders",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Orders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Product_Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "Shirts", "/Category Images/shirt icon.png", "Shirts" },
                    { 2, "Pants", "/Category Images/pants icon.png", "Pants" },
                    { 3, "dresses", "/Category Images/dress icon.png", "Dress" },
                    { 4, "Shoes", "/Category Images/shoe icon.png", "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sharjah" },
                    { 2, "Dubai" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Responsible for adding, editing, deleting of products and products’ categories", "Admin" },
                    { 2, "Can add products to their shopping carts and submit purchasing orders", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Icon", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 1, "Blue Gucci Shirt", "/Product Images/men gucci shirt.jpg", "Gucci Shirt", "800" },
                    { 7, 1, "Gucci Brown Long Sleeve Shirt", "/Product Images/women gucci shirt.jpg", "Gucci Long Sleeve Shirt", "300" },
                    { 8, 1, "Zara Greeb Long Sleeve Shirt", "/Product Images/zara shirt.jpg", "Zara Long Sleeve Shirt", "150" },
                    { 4, 2, "Louis Vuitton Destroyed Carpenter Denim Pants", "/Product Images/Louis vuitton Destroyed Carpenter denim pants.jpg", "Louis Vuitton Denim Pants", "60" },
                    { 1, 3, "Balenciaga v-neck green dress", "/Product Images/Balenciaga dress.jpg", "Balenciaga Dress", "2000" },
                    { 2, 4, "Elegant brown business dress shoe", "/Product Images/elegant business dress shoe.jpg", "Dress Shoes", "200" },
                    { 3, 4, "Hermes black noir heel sandal", "/Product Images/hermes black noir oasis heel sandal.jpg", "Hermes Noir Sandal", "500" },
                    { 6, 4, "Nike Winflo 8 Road Running shoes", "/Product Images/nike winflo 8 mens road running shoes.jpg", "Nike Road Running shoes", "300" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "LastName", "LocationId", "Mobile", "Password" },
                values: new object[,]
                {
                    { 1, 20, "admin@emaratech.ae", "Admin", "Admin", 1, "0501234567", "123" },
                    { 2, 22, "fatma@emaratech.ae", "Fatma", "AlSayegh", 2, "0501234567", "123" },
                    { 3, 22, "customer@emaratech.ae", "Customer", "Customer", 2, "0501234567", "123" }
                });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_OrderId",
                table: "Product_Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_RoleId",
                table: "User_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "User_Roles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}

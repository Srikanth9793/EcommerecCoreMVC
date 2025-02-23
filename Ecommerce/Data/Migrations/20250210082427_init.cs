using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductIngredients",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductIngredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Entree" },
                    { 3, "Side Dish" },
                    { 4, "Dessert" },
                    { 5, "Beverage" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 1, "Sweet onion Chicken" },
                    { 2, "Grilled Chicken" },
                    { 3, "Fish" },
                    { 4, "Roast Beef" },
                    { 5, "Potato" },
                    { 6, "Corn" },
                    { 7, "Lettuce" },
                    { 8, "Tomato" },
                    { 9, "Onions" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "A delicious Sweet Onion Teryaki Sandwich", "Sweet onion Chicken Sandwich", 13.25m, 100 },
                    { 2, 1, "Baked Chicken Wings. These supereasy baked chicken wings use just a few ingredients and four simple steps", "Baked Chicken", 10.25m, 150 },
                    { 3, 1, "Baked Chicken Wings. These supereasy baked chicken wings use just a few ingredients and four simple steps", "Baked Chicken", 10.25m, 150 },
                    { 4, 1, "Baked Roasted Beef. These supereasy baked Beef wings use just a few ingredients and four simple steps", "Roasted Beef", 10.25m, 150 },
                    { 5, 1, "A delicious chicken and Bacon", "Chicken and Bacon Sandwich", 14.05m, 70 },
                    { 6, 2, "A delicious Chicken Cheese Rice Bowl", "Chicken Cheese Rice Bowl", 9.58m, 40 },
                    { 7, 2, "A delicious Chicken Cheese Rice Bowl", "Chicken Cheese Rice Bowl", 9.58m, 40 },
                    { 8, 2, "A juicy beef patty with fresh lettuce, tomato, and cheese", "Classic Beef Burger", 8.99m, 50 },
                    { 9, 2, "A delicious pizza topped with fresh vegetables and mozzarella cheese", "Veggie Delight Pizza", 12.49m, 30 },
                    { 10, 2, "Crispy chicken wings tossed in a spicy buffalo sauce", "Spicy Chicken Wings", 7.99m, 25 },
                    { 11, 2, "Fresh romaine lettuce with Caesar dressing, parmesan, and croutons", "Caesar Salad", 6.99m, 35 },
                    { 12, 2, "A warm chocolate cake with a molten chocolate center", "Chocolate Lava Cake", 5.49m, 20 },
                    { 13, 2, "A creamy milkshake blended with fresh strawberries", "Strawberry Milkshake", 4.99m, 45 },
                    { 14, 2, "Grilled salmon fillet served with lemon butter sauce", "Grilled Salmon", 14.99m, 15 },
                    { 15, 2, "Crispy golden fries served with ketchup", "French Fries", 3.99m, 60 },
                    { 16, 2, "A refreshing smoothie made with ripe mangoes", "Mango Smoothie", 5.99m, 25 },
                    { 17, 3, "Crispy garlic-infused bread with melted butter and herbs", "Garlic Bread", 4.49m, 40 },
                    { 18, 3, "Crispy battered onion rings served with a tangy dipping sauce", "Onion Rings", 5.99m, 35 },
                    { 19, 3, "Deep-fried mozzarella cheese sticks with marinara sauce", "Cheesy Mozzarella Sticks", 6.49m, 30 },
                    { 20, 3, "Freshly shredded cabbage and carrots in a creamy dressing", "Coleslaw", 3.99m, 50 },
                    { 21, 3, "Creamy mashed potatoes with butter and a hint of garlic", "Mashed Potatoes", 4.99m, 45 },
                    { 22, 3, "Crispy potato skins topped with cheese, bacon, and sour cream", "Loaded Potato Skins", 7.49m, 25 },
                    { 23, 3, "A healthy mix of steamed seasonal vegetables", "Steamed Vegetables", 5.49m, 40 },
                    { 24, 3, "Grilled bread topped with fresh tomatoes, basil, and olive oil", "Bruschetta", 6.99m, 30 },
                    { 25, 3, "Mushroom caps stuffed with cheese, herbs, and breadcrumbs", "Stuffed Mushrooms", 7.99m, 20 },
                    { 26, 3, "Fresh corn on the cob served with melted butter", "Corn on the Cob", 3.49m, 60 },
                    { 27, 4, "A warm chocolate cake with a molten chocolate center", "Chocolate Lava Cake", 5.99m, 25 },
                    { 28, 4, "Classic creamy cheesecake with a graham cracker crust", "New York Cheesecake", 6.49m, 30 },
                    { 29, 4, "Layered Italian dessert with coffee-soaked ladyfingers and mascarpone cream", "Tiramisu", 7.99m, 20 },
                    { 30, 4, "Rich chocolate brownie topped with vanilla ice cream and chocolate syrup", "Brownie Sundae", 6.99m, 35 },
                    { 31, 4, "Classic apple pie with a flaky golden crust", "Apple Pie", 5.49m, 40 },
                    { 32, 4, "Silky Italian dessert topped with fresh berry sauce", "Panna Cotta", 6.79m, 28 },
                    { 33, 5, "Refreshing lemonade made with fresh lemons and a hint of mint", "Classic Lemonade", 3.99m, 50 },
                    { 34, 5, "Chilled brewed coffee served with milk and sweetener", "Iced Coffee", 4.49m, 40 },
                    { 35, 5, "Chilled brewed coffee served with milk and sweetener", "Iced Coffee shake", 4.49m, 40 }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredients",
                columns: new[] { "IngredientId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 2, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 6, 3 },
                    { 4, 4 },
                    { 7, 4 },
                    { 9, 4 },
                    { 2, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 2, 6 },
                    { 5, 6 },
                    { 4, 8 },
                    { 7, 8 },
                    { 8, 8 },
                    { 7, 9 },
                    { 8, 9 },
                    { 9, 9 },
                    { 2, 10 },
                    { 7, 11 },
                    { 3, 14 },
                    { 7, 14 },
                    { 5, 15 },
                    { 6, 17 },
                    { 9, 18 },
                    { 6, 19 },
                    { 5, 21 },
                    { 5, 22 },
                    { 6, 22 },
                    { 7, 23 },
                    { 8, 23 },
                    { 9, 23 },
                    { 6, 26 },
                    { 5, 27 },
                    { 6, 34 },
                    { 6, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredients_IngredientId",
                table: "ProductIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductIngredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

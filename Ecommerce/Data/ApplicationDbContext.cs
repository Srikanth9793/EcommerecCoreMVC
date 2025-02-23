using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppLocationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // In the below code we are creating Composite primary keys
            // If a table has two primary keys is called Composite Primary Keys
            builder.Entity<ProductIngredient>()
                .HasKey(p => new { p.ProductId, p.IngredientId });

            // Using the Fluent API in Entity Framework Core
            builder.Entity<ProductIngredient>()
                .HasOne(p => p.Product)
                .WithMany(pi => pi.ProductIngredients)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(p => p.Ingredient)
                .WithMany(x => x.ProductIngredients)
                .HasForeignKey(p => p.IngredientId);

            // Seed Data for the tables
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer" },
                new Category { CategoryId = 2, Name = "Entree"},
                new Category { CategoryId = 3, Name = "Side Dish" },
                new Category { CategoryId = 4, Name = "Dessert" },
                new Category { CategoryId = 5, Name = "Beverage" }
                );

            builder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Sweet onion Chicken"},
                new Ingredient { IngredientId = 2, Name = "Grilled Chicken" },
                new Ingredient { IngredientId = 3, Name = "Fish" },
                new Ingredient { IngredientId = 4, Name = "Roast Beef" },
                new Ingredient { IngredientId = 5, Name = "Potato" },
                new Ingredient { IngredientId = 6, Name = "Corn" },
                new Ingredient { IngredientId = 7, Name = "Lettuce" },
                new Ingredient { IngredientId = 8, Name = "Tomato" },
                new Ingredient { IngredientId = 9, Name = "Onions" }
                
                );

            builder.Entity<Product>().HasData(
                // Appetizer
                new Product
                {
                    ProductId = 1,
                    Name = "Sweet onion Chicken Sandwich",
                    Description = "A delicious Sweet Onion Teryaki Sandwich",
                    Price = 13.25m,
                    Stock = 100,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Baked Chicken",
                    Description = "Baked Chicken Wings. These supereasy baked chicken wings use just a few ingredients and four simple steps",
                    Price = 10.25m,
                    Stock = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Baked Chicken",
                    Description = "Baked Chicken Wings. These supereasy baked chicken wings use just a few ingredients and four simple steps",
                    Price = 10.25m,
                    Stock = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Roasted Beef",
                    Description = "Baked Roasted Beef. These supereasy baked Beef wings use just a few ingredients and four simple steps",
                    Price = 10.25m,
                    Stock = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Chicken and Bacon Sandwich",
                    Description = "A delicious chicken and Bacon",
                    Price = 14.05m,
                    Stock = 70,
                    CategoryId = 1
                },

                // Entries
                new Product
                {
                    ProductId = 6,
                    Name = "Chicken Cheese Rice Bowl",
                    Description = "A delicious Chicken Cheese Rice Bowl",
                    Price = 9.58m,
                    Stock = 40,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Chicken Biryani",
                    Description = "A delicious Chicken Biryani",
                    Price = 9.58m,
                    Stock = 40,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Classic Beef Burger",
                    Description = "A juicy beef patty with fresh lettuce, tomato, and cheese",
                    Price = 8.99m,
                    Stock = 50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Veggie Delight Pizza",
                    Description = "A delicious pizza topped with fresh vegetables and mozzarella cheese",
                    Price = 12.49m,
                    Stock = 30,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Spicy Chicken Wings",
                    Description = "Crispy chicken wings tossed in a spicy buffalo sauce",
                    Price = 7.99m,
                    Stock = 25,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Caesar Salad",
                    Description = "Fresh romaine lettuce with Caesar dressing, parmesan, and croutons",
                    Price = 6.99m,
                    Stock = 35,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Chocolate Lava Cake",
                    Description = "A warm chocolate cake with a molten chocolate center",
                    Price = 5.49m,
                    Stock = 20,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 13,
                    Name = "Strawberry Milkshake",
                    Description = "A creamy milkshake blended with fresh strawberries",
                    Price = 4.99m,
                    Stock = 45,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 14,
                    Name = "Grilled Salmon",
                    Description = "Grilled salmon fillet served with lemon butter sauce",
                    Price = 14.99m,
                    Stock = 15,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 15,
                    Name = "French Fries",
                    Description = "Crispy golden fries served with ketchup",
                    Price = 3.99m,
                    Stock = 60,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 16,
                    Name = "Mango Smoothie",
                    Description = "A refreshing smoothie made with ripe mangoes",
                    Price = 5.99m,
                    Stock = 25,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 17,
                    Name = "Garlic Bread",
                    Description = "Crispy garlic-infused bread with melted butter and herbs",
                    Price = 4.49m,
                    Stock = 40,
                    CategoryId = 3
                },
                // Side Dish
                new Product
                {
                    ProductId = 18,
                    Name = "Onion Rings",
                    Description = "Crispy battered onion rings served with a tangy dipping sauce",
                    Price = 5.99m,
                    Stock = 35,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 19,
                    Name = "Cheesy Mozzarella Sticks",
                    Description = "Deep-fried mozzarella cheese sticks with marinara sauce",
                    Price = 6.49m,
                    Stock = 30,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 20,
                    Name = "Coleslaw",
                    Description = "Freshly shredded cabbage and carrots in a creamy dressing",
                    Price = 3.99m,
                    Stock = 50,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 21,
                    Name = "Mashed Potatoes",
                    Description = "Creamy mashed potatoes with butter and a hint of garlic",
                    Price = 4.99m,
                    Stock = 45,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 22,
                    Name = "Loaded Potato Skins",
                    Description = "Crispy potato skins topped with cheese, bacon, and sour cream",
                    Price = 7.49m,
                    Stock = 25,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 23,
                    Name = "Steamed Vegetables",
                    Description = "A healthy mix of steamed seasonal vegetables",
                    Price = 5.49m,
                    Stock = 40,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 24,
                    Name = "Bruschetta",
                    Description = "Grilled bread topped with fresh tomatoes, basil, and olive oil",
                    Price = 6.99m,
                    Stock = 30,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 25,
                    Name = "Stuffed Mushrooms",
                    Description = "Mushroom caps stuffed with cheese, herbs, and breadcrumbs",
                    Price = 7.99m,
                    Stock = 20,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 26,
                    Name = "Corn on the Cob",
                    Description = "Fresh corn on the cob served with melted butter",
                    Price = 3.49m,
                    Stock = 60,
                    CategoryId = 3
                },
                // Dessert
                new Product
                {
                    ProductId = 27,
                    Name = "Chocolate Lava Cake",
                    Description = "A warm chocolate cake with a molten chocolate center",
                    Price = 5.99m,
                    Stock = 25,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 28,
                    Name = "New York Cheesecake",
                    Description = "Classic creamy cheesecake with a graham cracker crust",
                    Price = 6.49m,
                    Stock = 30,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 29,
                    Name = "Tiramisu",
                    Description = "Layered Italian dessert with coffee-soaked ladyfingers and mascarpone cream",
                    Price = 7.99m,
                    Stock = 20,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 30,
                    Name = "Brownie Sundae",
                    Description = "Rich chocolate brownie topped with vanilla ice cream and chocolate syrup",
                    Price = 6.99m,
                    Stock = 35,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 31,
                    Name = "Apple Pie",
                    Description = "Classic apple pie with a flaky golden crust",
                    Price = 5.49m,
                    Stock = 40,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 32,
                    Name = "Panna Cotta",
                    Description = "Silky Italian dessert topped with fresh berry sauce",
                    Price = 6.79m,
                    Stock = 28,
                    CategoryId = 4
                },
                // Beverges
                new Product
                {
                    ProductId = 33,
                    Name = "Classic Lemonade",
                    Description = "Refreshing lemonade made with fresh lemons and a hint of mint",
                    Price = 3.99m,
                    Stock = 50,
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 34,
                    Name = "Iced Coffee",
                    Description = "Chilled brewed coffee served with milk and sweetener",
                    Price = 4.49m,
                    Stock = 40,
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 35,
                    Name = "Iced Coffee shake",
                    Description = "Chilled brewed coffee served with milk and sweetener",
                    Price = 4.49m,
                    Stock = 40,
                    CategoryId = 5
                }

                );

            builder.Entity<ProductIngredient>().HasData(
                // Sweet onion Chicken Sandwich
                new ProductIngredient { ProductId = 1, IngredientId = 1 },
                new ProductIngredient { ProductId = 1, IngredientId = 7 },
                new ProductIngredient { ProductId = 1, IngredientId = 8 },
                new ProductIngredient { ProductId = 1, IngredientId = 9 },

                // Baked Chicken
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 7 },
                new ProductIngredient { ProductId = 2, IngredientId = 8 },

                // Mozzarella Sticks
                new ProductIngredient { ProductId = 3, IngredientId = 6 },

                // Roasted Beef
                new ProductIngredient { ProductId = 4, IngredientId = 4 },
                new ProductIngredient { ProductId = 4, IngredientId = 7 },
                new ProductIngredient { ProductId = 4, IngredientId = 9 },

                // Chicken and Bacon Sandwich
                new ProductIngredient { ProductId = 5, IngredientId = 2 },
                new ProductIngredient { ProductId = 5, IngredientId = 7 },
                new ProductIngredient { ProductId = 5, IngredientId = 8 },

                // Chicken Cheese Rice Bowl
                new ProductIngredient { ProductId = 6, IngredientId = 2 },
                new ProductIngredient { ProductId = 6, IngredientId = 5 },

                // Classic Beef Burger
                new ProductIngredient { ProductId = 8, IngredientId = 4 },
                new ProductIngredient { ProductId = 8, IngredientId = 7 },
                new ProductIngredient { ProductId = 8, IngredientId = 8 },

                // Veggie Delight Pizza
                new ProductIngredient { ProductId = 9, IngredientId = 7 },
                new ProductIngredient { ProductId = 9, IngredientId = 8 },
                new ProductIngredient { ProductId = 9, IngredientId = 9 },

                // Spicy Chicken Wings
                new ProductIngredient { ProductId = 10, IngredientId = 2 },

                // Caesar Salad
                new ProductIngredient { ProductId = 11, IngredientId = 7 },

                // French Fries
                new ProductIngredient { ProductId = 15, IngredientId = 5 },

                // Grilled Salmon
                new ProductIngredient { ProductId = 14, IngredientId = 3 },
                new ProductIngredient { ProductId = 14, IngredientId = 7 },

                // Garlic Bread
                new ProductIngredient { ProductId = 17, IngredientId = 6 },

                // Onion Rings
                new ProductIngredient { ProductId = 18, IngredientId = 9 },

                // Cheesy Mozzarella Sticks
                new ProductIngredient { ProductId = 19, IngredientId = 6 },

                // Mashed Potatoes
                new ProductIngredient { ProductId = 21, IngredientId = 5 },

                // Loaded Potato Skins
                new ProductIngredient { ProductId = 22, IngredientId = 5 },
                new ProductIngredient { ProductId = 22, IngredientId = 6 },

                // Steamed Vegetables
                new ProductIngredient { ProductId = 23, IngredientId = 7 },
                new ProductIngredient { ProductId = 23, IngredientId = 8 },
                new ProductIngredient { ProductId = 23, IngredientId = 9 },

                // Corn on the Cob
                new ProductIngredient { ProductId = 26, IngredientId = 6 },

                // Chocolate Lava Cake
                new ProductIngredient { ProductId = 27, IngredientId = 5 },


                new ProductIngredient { ProductId = 28, IngredientId = 4 },
                new ProductIngredient { ProductId = 29, IngredientId = 1 },
                new ProductIngredient { ProductId = 30, IngredientId = 2 },
                new ProductIngredient { ProductId = 31, IngredientId = 1 },
                new ProductIngredient { ProductId = 32, IngredientId = 4 },
                new ProductIngredient { ProductId = 33, IngredientId = 3 },
                new ProductIngredient { ProductId = 34, IngredientId = 6},
                new ProductIngredient { ProductId = 35, IngredientId = 4 }


                );


        }

    }
}

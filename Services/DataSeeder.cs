using EcommerceApp.Data;
using EcommerceApp.Models;

namespace EcommerceApp.Services;

public static class DataSeeder
{
    public static async Task SeedDataAsync(EcommerceContext context)
    {
        // Check if products already exist
        if (context.Products.Any())
        {
            return; // Data already seeded
        }

        var products = new List<Product>
        {
            new Product
            {
                Name = "Wireless Bluetooth Headphones",
                Description = "High-quality wireless headphones with noise cancellation and 30-hour battery life.",
                Price = 199.99m,
                StockQuantity = 50,
                Category = "Electronics",
                ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500"
            },
            new Product
            {
                Name = "Smart Fitness Watch",
                Description = "Advanced fitness tracking watch with heart rate monitor, GPS, and water resistance.",
                Price = 299.99m,
                StockQuantity = 30,
                Category = "Electronics",
                ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500"
            },
            new Product
            {
                Name = "Organic Cotton T-Shirt",
                Description = "Comfortable and sustainable organic cotton t-shirt in various colors.",
                Price = 29.99m,
                StockQuantity = 100,
                Category = "Clothing",
                ImageUrl = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?w=500"
            },
            new Product
            {
                Name = "Premium Coffee Beans",
                Description = "Artisan roasted coffee beans from Colombia, perfect for coffee enthusiasts.",
                Price = 24.99m,
                StockQuantity = 75,
                Category = "Food & Beverages",
                ImageUrl = "https://images.unsplash.com/photo-1559056199-641a0ac8b55e?w=500"
            },
            new Product
            {
                Name = "Yoga Mat Pro",
                Description = "Non-slip yoga mat with excellent cushioning and durability for all yoga practices.",
                Price = 79.99m,
                StockQuantity = 40,
                Category = "Sports & Fitness",
                ImageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?w=500"
            },
            new Product
            {
                Name = "Ceramic Dinner Set",
                Description = "Beautiful handcrafted ceramic dinner set for 4 people, dishwasher safe.",
                Price = 149.99m,
                StockQuantity = 20,
                Category = "Home & Kitchen",
                ImageUrl = "https://images.unsplash.com/photo-1586023492125-27b2c045efd7?w=500"
            },
            new Product
            {
                Name = "LED Desk Lamp",
                Description = "Adjustable LED desk lamp with multiple brightness levels and USB charging port.",
                Price = 89.99m,
                StockQuantity = 60,
                Category = "Home & Kitchen",
                ImageUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=500"
            },
            new Product
            {
                Name = "Running Shoes",
                Description = "Lightweight running shoes with excellent cushioning and breathable material.",
                Price = 129.99m,
                StockQuantity = 80,
                Category = "Sports & Fitness",
                ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500"
            },
            new Product
            {
                Name = "Wireless Phone Charger",
                Description = "Fast wireless charging pad compatible with all Qi-enabled devices.",
                Price = 39.99m,
                StockQuantity = 90,
                Category = "Electronics",
                ImageUrl = "https://images.unsplash.com/photo-1583394838336-acd977736f90?w=500"
            },
            new Product
            {
                Name = "Leather Wallet",
                Description = "Genuine leather wallet with RFID blocking technology and multiple card slots.",
                Price = 59.99m,
                StockQuantity = 45,
                Category = "Accessories",
                ImageUrl = "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=500"
            }
        };

        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }
}


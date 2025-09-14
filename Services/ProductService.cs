using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;
using EcommerceApp.DTOs;
using EcommerceApp.Models;

namespace EcommerceApp.Services;

public class ProductService : IProductService
{
    private readonly EcommerceContext _context;

    public ProductService(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products.Select(MapToResponse);
    }

    public async Task<ProductResponse?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product == null ? null : MapToResponse(product);
    }

    public async Task<ProductResponse> CreateProductAsync(ProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            StockQuantity = request.StockQuantity,
            ImageUrl = request.ImageUrl,
            Category = request.Category
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return MapToResponse(product);
    }

    public async Task<ProductResponse?> UpdateProductAsync(int id, ProductRequest request)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return null;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.ImageUrl = request.ImageUrl;
        product.Category = request.Category;
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return MapToResponse(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsByCategoryAsync(string category)
    {
        var products = await _context.Products
            .Where(p => p.Category != null && p.Category.ToLower() == category.ToLower())
            .ToListAsync();
        
        return products.Select(MapToResponse);
    }

    public async Task<IEnumerable<ProductResponse>> SearchProductsAsync(string searchTerm)
    {
        var products = await _context.Products
            .Where(p => p.Name.Contains(searchTerm) || 
                       (p.Description != null && p.Description.Contains(searchTerm)))
            .ToListAsync();
        
        return products.Select(MapToResponse);
    }

    private static ProductResponse MapToResponse(Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            Category = product.Category,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
}


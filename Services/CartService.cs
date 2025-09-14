using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;
using EcommerceApp.DTOs;
using EcommerceApp.Models;

namespace EcommerceApp.Services;

public class CartService : ICartService
{
    private readonly EcommerceContext _context;

    public CartService(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<CartResponse> GetCartAsync(int userId)
    {
        var cartItems = await _context.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.UserId == userId)
            .ToListAsync();

        var items = cartItems.Select(ci => MapToResponse(ci, ci.Product)).ToList();

        return new CartResponse
        {
            Items = items
        };
    }

    public async Task<CartItemResponse> AddToCartAsync(int userId, CartItemRequest request)
    {
        // Check if product exists and has enough stock
        var product = await _context.Products.FindAsync(request.ProductId);
        if (product == null)
            throw new InvalidOperationException("Product not found");

        if (product.StockQuantity < request.Quantity)
            throw new InvalidOperationException("Insufficient stock");

        // Check if item already exists in cart
        var existingCartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == request.ProductId);

        if (existingCartItem != null)
        {
            // Update quantity
            existingCartItem.Quantity += request.Quantity;
            await _context.SaveChangesAsync();
            return MapToResponse(existingCartItem, product);
        }
        else
        {
            // Add new item to cart
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return MapToResponse(cartItem, product);
        }
    }

    public async Task<CartItemResponse?> UpdateCartItemAsync(int userId, int cartItemId, int quantity)
    {
        var cartItem = await _context.CartItems
            .Include(ci => ci.Product)
            .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.UserId == userId);

        if (cartItem == null)
            return null;

        if (quantity <= 0)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return null;
        }

        // Check stock availability
        if (cartItem.Product.StockQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock");

        cartItem.Quantity = quantity;
        await _context.SaveChangesAsync();

        return MapToResponse(cartItem, cartItem.Product);
    }

    public async Task<bool> RemoveFromCartAsync(int userId, int cartItemId)
    {
        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.UserId == userId);

        if (cartItem == null)
            return false;

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ClearCartAsync(int userId)
    {
        var cartItems = await _context.CartItems
            .Where(ci => ci.UserId == userId)
            .ToListAsync();

        _context.CartItems.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
        return true;
    }

    private static CartItemResponse MapToResponse(CartItem cartItem, Product product)
    {
        return new CartItemResponse
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = product.Name,
            ProductPrice = product.Price,
            ProductImageUrl = product.ImageUrl,
            Quantity = cartItem.Quantity,
            AddedAt = cartItem.AddedAt
        };
    }
}

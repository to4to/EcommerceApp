using EcommerceApp.DTOs;

namespace EcommerceApp.Services;

public interface ICartService
{
    Task<CartResponse> GetCartAsync(int userId);
    Task<CartItemResponse> AddToCartAsync(int userId, CartItemRequest request);
    Task<CartItemResponse?> UpdateCartItemAsync(int userId, int cartItemId, int quantity);
    Task<bool> RemoveFromCartAsync(int userId, int cartItemId);
    Task<bool> ClearCartAsync(int userId);
}


using EcommerceApp.DTOs;

namespace EcommerceApp.Services;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(int userId, CreateOrderRequest request);
    Task<IEnumerable<OrderResponse>> GetUserOrdersAsync(int userId);
    Task<OrderResponse?> GetOrderByIdAsync(int orderId, int userId);
    Task<OrderResponse?> UpdateOrderStatusAsync(int orderId, string status);
    Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
}


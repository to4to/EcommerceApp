using Microsoft.EntityFrameworkCore;
using EcommerceApp.Data;
using EcommerceApp.DTOs;
using EcommerceApp.Models;

namespace EcommerceApp.Services;

public class OrderService : IOrderService
{
    private readonly EcommerceContext _context;

    public OrderService(EcommerceContext context)
    {
        _context = context;
    }

    public async Task<OrderResponse> CreateOrderAsync(int userId, CreateOrderRequest request)
    {
        // Get user's cart items
        var cartItems = await _context.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.UserId == userId)
            .ToListAsync();

        if (!cartItems.Any())
            throw new InvalidOperationException("Cart is empty");

        // Calculate total amount
        var totalAmount = cartItems.Sum(ci => ci.Quantity * ci.Product.Price);

        // Create order
        var order = new Order
        {
            UserId = userId,
            Status = "Pending",
            TotalAmount = totalAmount,
            ShippingAddress = request.ShippingAddress,
            BillingAddress = request.BillingAddress,
            Notes = request.Notes
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Create order items and update stock
        foreach (var cartItem in cartItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                UnitPrice = cartItem.Product.Price
            };

            _context.OrderItems.Add(orderItem);

            // Update product stock
            cartItem.Product.StockQuantity -= cartItem.Quantity;
            cartItem.Product.UpdatedAt = DateTime.UtcNow;
        }

        // Clear user's cart
        _context.CartItems.RemoveRange(cartItems);

        await _context.SaveChangesAsync();

        // Return the created order with items
        return await GetOrderByIdAsync(order.Id, userId) ?? throw new InvalidOperationException("Failed to create order");
    }

    public async Task<IEnumerable<OrderResponse>> GetUserOrdersAsync(int userId)
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return orders.Select(MapToResponse);
    }

    public async Task<OrderResponse?> GetOrderByIdAsync(int orderId, int userId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);

        return order == null ? null : MapToResponse(order);
    }

    public async Task<OrderResponse?> UpdateOrderStatusAsync(int orderId, string status)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null)
            return null;

        order.Status = status;
        await _context.SaveChangesAsync();

        return MapToResponse(order);
    }

    public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.User)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return orders.Select(MapToResponse);
    }

    private static OrderResponse MapToResponse(Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            ShippingAddress = order.ShippingAddress,
            BillingAddress = order.BillingAddress,
            Notes = order.Notes,
            OrderItems = order.OrderItems.Select(oi => new OrderItemResponse
            {
                Id = oi.Id,
                ProductId = oi.ProductId,
                ProductName = oi.Product.Name,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToList()
        };
    }
}


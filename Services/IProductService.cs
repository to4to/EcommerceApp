using EcommerceApp.DTOs;

namespace EcommerceApp.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
    Task<ProductResponse?> GetProductByIdAsync(int id);
    Task<ProductResponse> CreateProductAsync(ProductRequest request);
    Task<ProductResponse?> UpdateProductAsync(int id, ProductRequest request);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<ProductResponse>> GetProductsByCategoryAsync(string category);
    Task<IEnumerable<ProductResponse>> SearchProductsAsync(string searchTerm);
}


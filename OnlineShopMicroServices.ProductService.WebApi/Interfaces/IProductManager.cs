using OnlineShopMicroServices.ProductService.WebApi.Entities;

namespace OnlineShopMicroServices.ProductService.WebApi.Interfaces
{
    public interface IProductManager
    {
        Task<Product> CreateProductAsync(string name);
        Task ChangeNameAsync(Product product, string name);
    }
}

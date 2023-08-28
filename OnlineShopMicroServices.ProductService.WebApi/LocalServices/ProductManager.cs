using Microsoft.EntityFrameworkCore;
using OnlineShopMicroServices.ProductService.WebApi.Entities;
using OnlineShopMicroServices.ProductService.WebApi.Exceptions;
using OnlineShopMicroServices.ProductService.WebApi.Interfaces;

namespace OnlineShopMicroServices.ProductService.WebApi.LocalServices
{
    public class ProductManager : IProductManager
    {
        private readonly IAppDbContext _context;

        public ProductManager(IAppDbContext context)
        {
            this._context = context;
        }
        public async Task<Product> CreateProductAsync(string name)
        {
            await CheckDuplicateNameAsync(name);

            return new Product(name);
        }

        private async Task CheckDuplicateNameAsync(string name, long? Id = null)
        {
            var query = _context.Products
                .Where(w => w.Name == name);
            if (Id != null)
            {
                query = query
                    .Where(w => w.Id != Id);
            }

            if (await query.AnyAsync())
            {
                throw new BadRequestException("The product with simiilar name exists.");
            }

        }

        public async Task ChangeNameAsync(Product product, string name)
        {
            await CheckDuplicateNameAsync(name,product.Id);

            product.SetName(name);
        }
    }
}

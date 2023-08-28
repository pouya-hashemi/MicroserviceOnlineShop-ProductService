using Microsoft.EntityFrameworkCore;
using OnlineShopMicroServices.ProductService.WebApi.Entities;

namespace OnlineShopMicroServices.ProductService.WebApi.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Product> Products{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

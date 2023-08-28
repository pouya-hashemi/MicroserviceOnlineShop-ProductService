using Microsoft.EntityFrameworkCore;
using OnlineShopMicroServices.ProductService.WebApi.Entities;
using OnlineShopMicroServices.ProductService.WebApi.Interfaces;
using System.Reflection;

namespace OnlineShopMicroServices.ProductService.WebApi.Persistance
{
    public class AppDbContext:DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {
            
        }

        public DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopMicroServices.ProductService.WebApi.Entities;
using OnlineShopMicroServices.ProductService.WebApi.EntityConstraints;

namespace OnlineShopMicroServices.ProductService.WebApi.Persistance.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder
                .Property(x => x.Name)
                .HasMaxLength(ProductConstraint.NameMaxLength)
                .IsRequired();

        }
    }
}

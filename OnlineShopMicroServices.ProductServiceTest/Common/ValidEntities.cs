using OnlineShopMicroServices.ProductService.WebApi.Entities;
using OnlineShopMicroServices.ProductService.WebApi.EntityConstraints;


namespace OnlineShopMicroServices.ProductServiceTest.Common
{
    internal class ValidEntities
    {
        public Product GetValidProduct => new Product(new string(Enumerable.Repeat('a', ProductConstraint.NameMinLength).ToArray()));
        public Product GetValidProduct2 => new Product(new string(Enumerable.Repeat('b', ProductConstraint.NameMinLength).ToArray()));
    }
}

using OnlineShopMicroServices.ProductService.WebApi.EntityConstraints;
using OnlineShopMicroServices.ProductService.WebApi.Exceptions;
using System.Runtime.CompilerServices;

namespace OnlineShopMicroServices.ProductService.WebApi.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; private set; }

        public Product(string name)
        {
            this.Name = ValidateName(name);
        }
        private string ValidateName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new BadRequestException("Name is required");

            if (name.Length > ProductConstraint.NameMaxLength || name.Length < ProductConstraint.NameMinLength)
                throw new BadRequestException($"Name must be between {ProductConstraint.NameMinLength} and {ProductConstraint.NameMaxLength} characters long.");

            return name;

        }
        public void SetName(string name)
        {
            this.Name=ValidateName(name);
        }

    }
}

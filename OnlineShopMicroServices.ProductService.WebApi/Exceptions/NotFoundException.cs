using System.Net;

namespace OnlineShopMicroServices.ProductService.WebApi.Exceptions
{
    public class NotFoundException:ExceptionBase
    {
        public NotFoundException(string item):base($"{item} was not found !!!",HttpStatusCode.NotFound)
        {
            
        }
    }
}

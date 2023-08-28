using System.Net;

namespace OnlineShopMicroServices.ProductService.WebApi.Exceptions
{
    public class BadRequestException:ExceptionBase
    {
        public BadRequestException(string message):base(message,HttpStatusCode.BadRequest)
        {
            
        }
    }
}

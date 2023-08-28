using System.Net;

namespace OnlineShopMicroServices.ProductService.WebApi.Exceptions
{
    public class ExceptionBase:Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ExceptionBase(string message,HttpStatusCode httpStatusCode):base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }
    }
}

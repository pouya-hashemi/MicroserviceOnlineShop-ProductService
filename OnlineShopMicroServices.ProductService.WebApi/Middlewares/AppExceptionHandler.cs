using OnlineShopMicroServices.ProductService.WebApi.Exceptions;

namespace OnlineShopMicroServices.ProductService.WebApi.Middlewares
{
    public class AppExceptionHandler
    {
        private readonly RequestDelegate _next;

        public AppExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExceptionBase baseEx)
            {
                context.Response.StatusCode = (int)baseEx.HttpStatusCode;
                await context.Response.WriteAsync(baseEx.Message);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("The service is not available right now. please try again later");
            }
        }
    }
}

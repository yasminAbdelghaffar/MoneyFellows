using API.Utilities;
using System.Net;

namespace API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (KeyNotFoundException exception)
            {
                await HttpResponseUtilities.SetContextResponseAsync(context, new { ErrorDetail = exception.Message }, HttpStatusCode.OK);
                return;
            }
            catch (Exception exception)
            {
                await HttpResponseUtilities.SetContextResponseAsync(context, new { ErrorDetail = exception.ToString() }, HttpStatusCode.OK);
                return;
            }

        }
    }

}

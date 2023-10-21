using entityf.Data.Errors;
using entityf.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace entityf.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext conext)
        {
            try
            {
                await _next(conext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(conext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext conext, Exception e)
        {
            conext.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDeatils
            {
                ErrorType = "Failure",
                ErrorMessage = e.Message
            };

            switch (e)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
                default:
                    break;
            }

            string respone = JsonConvert.SerializeObject(errorDetails);
            conext.Response.StatusCode = (int)statusCode;
            return conext.Response.WriteAsync(respone);
        }
    }
}

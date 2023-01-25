using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP23.P01.Web.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace SP23.P01.Web.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (NotFoundException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                AccessViolationException => (int)HttpStatusCode.Unauthorized,
                NotFoundException => (int)HttpStatusCode.NotFound,
                DbUpdateException => (int)HttpStatusCode.BadRequest,
                InvalidDataException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = exception switch
            {
                AccessViolationException => "Access not authorized!",
                DbUpdateException => "Invalid data!",
                NotFoundException => exception.Message,
                InvalidDataException => "Invalid input",
                _ => "Internal Server Error!"
            };
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}

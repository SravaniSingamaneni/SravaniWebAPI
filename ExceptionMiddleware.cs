using Microsoft.AspNetCore.Mvc;
using SravaniWebAPI.Exceptions;
using System.Net;
using System.Text.Json;

namespace SravaniWebAPI
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) 
        { 
            _next = next;
        }
        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }            
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex) 
        {
            HttpStatusCode status;

            status = ex switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                BadRequestException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError                   
            };

            var response = new
            {
                statusCode = (int)status,
                Message = ex.Message,
                TraceId = context.TraceIdentifier // TraceId for debugging
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode=(int) status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

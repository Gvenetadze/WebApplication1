using System.Text.Json;
using System.Net;
using WebApplication1.Utils.Exceptions;

namespace WebApplication1.Utils.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
		try
		{
            await _next(context);
        }
        catch (NotFoundException ex)
		{
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            var response = new
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = "The requested resource was not found.",
                Detailed = ex.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            context.Response.ContentType= "application/json";
            context.Response.StatusCode= (int)HttpStatusCode.BadRequest;
            var response = new
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "Bad request. Please check your input or the request format.",
                Detailed = ex.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

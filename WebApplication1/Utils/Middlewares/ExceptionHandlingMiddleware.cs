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
			throw;
		}
        catch (Exception)
        {
            throw;
        }
    }
}

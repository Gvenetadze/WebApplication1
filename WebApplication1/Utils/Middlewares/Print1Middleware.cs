namespace WebApplication1.Utils.Middlewares;

public class Print1Middleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/swagger") &&
            !context.Request.Path.Equals("/favicon.ico"))
        {
            Console.WriteLine($"Middleware 1: Before request - Path: {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Middleware 1: After request - Path: {context.Request.Path}");
        }
        else
        {
            await _next(context);
        }
    }

}

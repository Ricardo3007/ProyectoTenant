public class MultitenantMiddleware
{

    private readonly RequestDelegate _next;

    public MultitenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        var slugTenant = context.Request.Path.Value.Split('/')[1]; 
        context.Items["SlugTenant"] = slugTenant; 

        await _next(context);
    }
}

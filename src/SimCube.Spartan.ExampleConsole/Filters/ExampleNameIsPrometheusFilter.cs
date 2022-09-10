namespace SimCube.Spartan.ExampleConsole.Filters;

/// <inheritdoc />
public class ExampleNameIsPrometheusFilter : IEndpointFilter
{
    /// <inheritdoc />
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var name = context.HttpContext.Request.RouteValues["name"]?.ToString();

        if (name == "Prometheus")
        {
            return Results.Text("Hello, Prometheus!");
        }

        return await next(context);
    }
}

namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <inheritdoc />
public class GetExampleWithTypeResultHandler : IRequestHandler<GetExampleWithTypeResultRequest, Results<Ok<bool>, NotFound>>
{
    /// <inheritdoc />
    public async Task<Results<Ok<bool>, NotFound>> Handle(GetExampleWithTypeResultRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return request.Name == "Prom3theu5" ? TypedResults.Ok(true) : TypedResults.NotFound();
    }
}

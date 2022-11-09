namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class GetExampleThreeGroupRequestHandler : IRequestHandler<GetExampleThreeGroupRequest, Results<Ok<string>, NotFound>>
{
    /// <inheritdoc />
    public async Task<Results<Ok<string>, NotFound>> Handle(GetExampleThreeGroupRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);

        return request.Age switch
        {
            < 18 => TypedResults.NotFound(),
            >= 18 => TypedResults.Ok($"The age was {request.Age} and the name was {request.Name}"),
        };
    }
}

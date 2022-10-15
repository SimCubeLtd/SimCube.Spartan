namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class GetExampleCachedRequestHandler : IRequestHandler<GetExampleCachedRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(GetExampleCachedRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

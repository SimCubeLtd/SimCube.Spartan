namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class GetExampleRequestHandler : IRequestHandler<GetExampleRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(GetExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

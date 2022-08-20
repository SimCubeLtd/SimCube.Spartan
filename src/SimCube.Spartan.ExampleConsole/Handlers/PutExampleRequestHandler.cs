namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class PutExampleRequestHandler : IRequestHandler<PutExampleRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(PutExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

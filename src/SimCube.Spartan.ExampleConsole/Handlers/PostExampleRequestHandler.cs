namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class PostExampleRequestHandler : IRequestHandler<PostExampleRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(PostExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

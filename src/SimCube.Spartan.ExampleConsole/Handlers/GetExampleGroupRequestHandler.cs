namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class GetExampleGroupRequestHandler : IRequestHandler<GetExampleGroupRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(GetExampleGroupRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

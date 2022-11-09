namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class GetExampleTwoGroupRequestHandler : IRequestHandler<GetExampleTwoGroupRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(GetExampleTwoGroupRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

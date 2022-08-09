using SimCube.Spartan.ExampleConsole.Requests;

namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
public class PatchExampleRequestHandler : IRequestHandler<PatchExampleRequest, IResult>
{
    /// <inheritdoc />
    public Task<IResult> Handle(PatchExampleRequest request, CancellationToken cancellationToken) =>
        Task.FromResult(Results.Ok($"The age was {request.Age} and the name was {request.Name}"));
}

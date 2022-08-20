namespace SimCube.Spartan.Interfaces;

/// <summary>
/// Interface for the Mediated Stream Requests.
/// </summary>
/// <typeparam name="TResult">The result type for Streamed Results.</typeparam>
public interface IMediatedStream<out TResult> : IStreamRequest<TResult>
{
}

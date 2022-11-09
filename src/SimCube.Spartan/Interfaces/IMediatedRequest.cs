namespace SimCube.Spartan.Interfaces;

/// <summary>
/// Interface for the Mediated Http Requests.
/// </summary>
public interface IMediatedRequest : IMediatedRequest<IResult>
{
}

/// <summary>
/// Interface for the Mediated Http Requests.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IMediatedRequest<out TResult> : IRequest<TResult>
{
}



namespace SimCube.Spartan.Validation;

/// <summary>
/// Validation rules for mediated requests.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
[ExcludeFromCodeCoverage]
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The validators to use to validate against.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    /// <summary>
    /// Performs the validation.
    /// </summary>
    /// <param name="request">The request to validate.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="next">The next middleware in the request pipeline.</param>
    /// <returns>The result of the validation, or the result of the next result in the pipeline if validation is successful.</returns>
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);

        var results = (await Task.WhenAll(
            _validators.Select(
                v => v.ValidateAsync(context, cancellationToken)))).ToList();

        if (!results.Any(result => result.Errors.Count > 0))
        {
            return await next();
        }

        var problems = results
            .SelectMany(validationResult => validationResult.Errors)
            .GroupBy(item => item.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(entry => entry.ErrorMessage).ToArray());

        return (TResponse)Results.ValidationProblem(problems);
    }
}

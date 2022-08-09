using SimCube.Spartan.ExampleConsole.Requests;

namespace SimCube.Spartan.ExampleConsole.Validators;

/// <summary>
/// Validator for Example Request.
/// </summary>
public class GetExampleRequestValidator : AbstractValidator<GetExampleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExampleRequestValidator"/> class.
    /// </summary>
    public GetExampleRequestValidator() =>
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("You must be 18 to use this service.");
}

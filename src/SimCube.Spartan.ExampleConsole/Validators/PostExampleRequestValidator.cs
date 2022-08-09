using SimCube.Spartan.ExampleConsole.Requests;

namespace SimCube.Spartan.ExampleConsole.Validators;

/// <summary>
/// Validator for Example Request.
/// </summary>
public class PostExampleRequestValidator : AbstractValidator<PostExampleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostExampleRequestValidator"/> class.
    /// </summary>
    public PostExampleRequestValidator() =>
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("You must be 18 to use this service.");
}

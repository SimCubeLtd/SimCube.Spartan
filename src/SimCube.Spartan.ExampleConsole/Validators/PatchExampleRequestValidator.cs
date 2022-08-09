using SimCube.Spartan.ExampleConsole.Requests;

namespace SimCube.Spartan.ExampleConsole.Validators;

/// <summary>
/// Validator for Example Request.
/// </summary>
public class PatchExampleRequestValidator : AbstractValidator<PatchExampleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PatchExampleRequestValidator"/> class.
    /// </summary>
    public PatchExampleRequestValidator() =>
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("You must be 18 to use this service.");
}

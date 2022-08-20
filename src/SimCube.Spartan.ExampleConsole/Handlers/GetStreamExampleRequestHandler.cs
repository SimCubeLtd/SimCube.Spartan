using System.Runtime.CompilerServices;
using Bogus;
using Person = SimCube.Spartan.ExampleConsole.Models.Person;

namespace SimCube.Spartan.ExampleConsole.Handlers;

/// <summary>
/// Th example request handler.
/// </summary>
[ExcludeFromCodeCoverage]
public class GetStreamExampleRequestHandler : IStreamRequestHandler<GetStreamExampleRequest, Person>
{
    private readonly Faker<Person> _faker;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetStreamExampleRequestHandler"/> class.
    /// </summary>
    public GetStreamExampleRequestHandler()
    {
        Randomizer.Seed = new(1701);

        _faker = new Faker<Person>()
            .StrictMode(true)
            .RuleFor(o => o.Name, f => f.Person.FullName)
            .RuleFor(o => o.Age, f => f.Random.Number(18, 100))
            .RuleFor(o => o.EmailAddress, f => f.Person.Email);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<Person> Handle(
        GetStreamExampleRequest request,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(200, cancellationToken);

            yield return _faker.Generate();
        }
    }
}

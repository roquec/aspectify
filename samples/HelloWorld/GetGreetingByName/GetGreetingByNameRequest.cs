namespace HelloWorld.GetGreetingByName;

public record GetGreetingByNameRequest
{
    public required string Name { get; init; }
}
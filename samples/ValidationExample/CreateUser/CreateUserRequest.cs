namespace ValidationExample.CreateUser;

public record CreateUserRequest
{
    public required string Name { get; init; }
    public required int Age { get; init; }
    public required string Email { get; init; }
}
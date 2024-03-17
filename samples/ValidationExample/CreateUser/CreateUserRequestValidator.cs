using FluentValidation;

namespace ValidationExample.CreateUser;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest> 
{
    public CreateUserRequestValidator()
    {
        RuleFor(request => request.Name).NotNull();
        RuleFor(request => request.Age).GreaterThan(0);
        RuleFor(request => request.Email).EmailAddress();
    }
}
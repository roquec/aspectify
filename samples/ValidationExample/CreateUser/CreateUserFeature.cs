using Aspectify.Features;

namespace ValidationExample.CreateUser;

public class CreateUserFeature : IFeature<CreateUserRequest, CreateUserResult>
{
    public Task<CreateUserResult> Handle(CreateUserRequest request)
    {
        var result = new CreateUserResult();
        return Task.FromResult(result);
    }
}
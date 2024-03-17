using Aspectify;
using Aspectify.Features;
using ValidationExample.CreateUser;

namespace ValidationExample;

public class Client
{
    private readonly CreateUserFeature _createUserFeature;

    public Client(CreateUserFeature createUserFeature)
    {
        _createUserFeature = createUserFeature;
    }

    public async Task Run()
    {
        var request = new CreateUserRequest
        {
            Name = "Roque",
            Age = -1,
            Email = "roque@test.test"
        };

        var result = await _createUserFeature.Execute(request);
    }
}

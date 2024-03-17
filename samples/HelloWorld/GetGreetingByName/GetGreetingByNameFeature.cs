using Aspectify.Features;

namespace HelloWorld.GetGreetingByName;

public class GetGreetingByNameFeature : IFeature<GetGreetingByNameRequest, GetGreetingByNameResult>
{
    public Task<GetGreetingByNameResult> Handle(GetGreetingByNameRequest greetingRequest)
    {
        var name = greetingRequest.Name;
        var greeting = $"Hello world to {name}!";
        var result = new GetGreetingByNameResult
        {
            Greeting = greeting
        };
        return Task.FromResult(result);
    }
}
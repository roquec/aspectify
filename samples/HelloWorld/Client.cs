using Aspectify.Features;
using HelloWorld.GetGreetingByName;

namespace HelloWorld;

public class Client
{
    private readonly GetGreetingByNameFeature _getGreetingByNameFeature;

    public Client(GetGreetingByNameFeature getGreetingByNameFeature)
    {
        _getGreetingByNameFeature = getGreetingByNameFeature;
    }
    
    public async Task Run()
    {
        const string name = "RoqueC";

        var request = new GetGreetingByNameRequest
        {
            Name = name
        };

        var result = await _getGreetingByNameFeature.Execute(request);

        var greeting = result.Greeting;
        
        Console.WriteLine(greeting);
    }
}
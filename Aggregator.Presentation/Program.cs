namespace Aggregator.Presentation;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddDependencies();

        //Hardcoded here, but would normally be created from the user input above
        var riskData = new RiskData(firstName: "John", lastName: "Smith", value: 500, make: "Cool New Phone",
            DateTime.Parse("1980-01-01"));
        //Omitted for brevity - Collect input (risk data from the user)
        var request = new PriceRequest(riskData);

        var serviceProvider = services.BuildServiceProvider();
        var priceEngine = serviceProvider.GetService<IPriceEngine>();
        var response = priceEngine.GetPrice(request);

        Console.Out.WriteLine(response.Price == -1
            ? $"There was an error - {response.Error}"
            : $"You price is {response.Price}, from insurer: {response.Insurer}. This includes tax of {response.Tax}");
    }
}
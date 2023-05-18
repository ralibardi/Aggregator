namespace Aggregator.Presentation.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPriceEngine, PriceEngine>();
        services.AddScoped<IQuotationSystemFactory, QuotationSystemFactory>();

        return services;
    }
}
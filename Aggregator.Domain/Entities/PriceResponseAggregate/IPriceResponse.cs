namespace Aggregator.Domain.Entities.PriceResponseAggregate;

public interface IPriceResponse
{
    decimal Tax { get; }
    string Insurer { get; }
    string? Error { get; }
    decimal Price { get; }
}
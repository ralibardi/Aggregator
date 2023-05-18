namespace Aggregator.Domain.Entities.PriceResponseAggregate;

public class PriceResponse : IPriceResponse
{
    public PriceResponse(decimal price, string insurer, decimal tax, string? error = null)
    {
        Price = price;
        Insurer = insurer;
        Tax = tax;
        Error = error;
    }

    public decimal Price { get; }
    public string Insurer { get; }
    public decimal Tax { get; }
    public string? Error { get; }
}
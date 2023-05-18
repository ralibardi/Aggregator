namespace Aggregator.Domain.Entities.PriceRequestAggregate;

public interface IPriceRequest
{
    IRiskData? RiskData { get; }
}
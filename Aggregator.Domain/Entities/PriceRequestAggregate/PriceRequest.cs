namespace Aggregator.Domain.Entities.PriceRequestAggregate;

public class PriceRequest : IPriceRequest
{
    public PriceRequest(IRiskData? riskData)
    {
        RiskData = riskData;
    }

    public IRiskData? RiskData { get; }
}
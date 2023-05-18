namespace Aggregator.Presentation.Engines;

public interface IPriceEngine
{
    IPriceResponse GetPrice(IPriceRequest request);
}
namespace Aggregator.Domain.Factories;

public interface IQuotationSystemFactory
{
    IQuotationSystem? GetQuotationSystem(QuotationSystemType type);
}
namespace Aggregator.Domain.Factories;

public class QuotationSystemFactory : IQuotationSystemFactory
{
    public IQuotationSystem? GetQuotationSystem(QuotationSystemType type) => type switch
    {
        QuotationSystemType.Type1 => new QuotationSystem1("http://quote-system-1.com", "1234"),
        QuotationSystemType.Type2 => new QuotationSystem2("http://quote-system-2.com", "1235"),
        QuotationSystemType.Type3 => new QuotationSystem3("http://quote-system-3.com", "100"),
        _ => null,
    };
}
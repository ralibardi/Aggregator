namespace Aggregator.Domain.Services.QuotationSystem;

public abstract class QuotationSystem : IQuotationSystem
{
    private readonly string _url;
    private readonly string _port;

    protected QuotationSystem(string url, string port)
    {
        _url = url ?? throw new Exception(nameof(url));
        _port = port ?? throw new Exception(nameof(port));
    }

    public abstract dynamic GetPrice(dynamic request);
}
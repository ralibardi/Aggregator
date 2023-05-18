namespace Aggregator.Presentation.Engines;

public class PriceEngine : IPriceEngine
{
    private readonly IQuotationSystemFactory _quotationSystemFactory;

    public PriceEngine(IQuotationSystemFactory quotationSystemFactory)
    {
        _quotationSystemFactory = quotationSystemFactory;
    }

    //Pass request with risk data with details of a gadget, return the best price retrieved from 3 external quotation engines
    public IPriceResponse GetPrice(IPriceRequest request)
    {
        var error = ValidateRequest(request);

        return error ?? GetQuotation(request);
    }

    private IPriceResponse GetQuotation(IPriceRequest request)
    {
        var quotationType = GetQuotationType(request);
        var systemRequest = GetSystemRequest(request, quotationType);
        var systemResponse = _quotationSystemFactory.GetQuotationSystem(quotationType)?.GetPrice(systemRequest);

        if (systemResponse != null && systemResponse.IsSuccess && systemResponse.Price > 0)
        {
            return new PriceResponse(price: systemResponse.Price, insurer: systemResponse.Name, tax: systemResponse.Tax);
        }

        return new PriceResponse(price: -1, insurer: string.Empty, error: "No insurer found", tax: 0);
    }

    private static ExpandoObject GetSystemRequest(IPriceRequest request, QuotationSystemType quotationType)
    {
        dynamic systemRequest = new ExpandoObject();
        systemRequest.FirstName = request.RiskData.FirstName;
        systemRequest.LastName = request.RiskData.LastName;
        systemRequest.Make = request.RiskData.Make;
        systemRequest.Value = request.RiskData.Value;


        if (quotationType is QuotationSystemType.Type1 or QuotationSystemType.Type3)
        {
            systemRequest.DOB = request.RiskData.DOB;
        }

        return systemRequest;
    }

    private static QuotationSystemType GetQuotationType(IPriceRequest request)
    {
        if (request.RiskData.DOB != null)
        {
            return QuotationSystemType.Type1;
        }

        if (request.RiskData.Make is "examplemake1" or "examplemake2" or "examplemake3")
        {
            return QuotationSystemType.Type2;
        }

        return QuotationSystemType.Type3;
    }

    private static IPriceResponse? ValidateRequest(IPriceRequest request)
    {
        var errorMessage = string.Empty;

        if (request.RiskData == null)
        {
            errorMessage = "Risk Data is missing";
        }

        if (string.IsNullOrWhiteSpace(request.RiskData?.FirstName) && string.IsNullOrWhiteSpace(errorMessage))
        {
            errorMessage = "First name is required";
        }

        if (string.IsNullOrWhiteSpace(request.RiskData?.LastName) && string.IsNullOrWhiteSpace(errorMessage))
        {
            errorMessage = "Surname is required";
        }

        if (request.RiskData?.Value == 0 && string.IsNullOrWhiteSpace(errorMessage))
        {
            errorMessage = "Value is required";
        }

        return string.IsNullOrWhiteSpace(errorMessage) ? null : new PriceResponse(price: -1, insurer: string.Empty, error: errorMessage, tax: 0);
    }
}
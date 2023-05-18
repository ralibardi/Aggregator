namespace Aggregator.Domain.Services;

public class QuotationSystem2 : QuotationSystem.QuotationSystem
{
    public QuotationSystem2(string url, string port) : base(url, port)
    {

    }

    public override dynamic GetPrice(dynamic request)
    {
        //Omitted - Call to an external service
        //var response = _someExternalService.PostHttpRequest(requestData);

        dynamic response = new ExpandoObject();
        response.Price = 234.56M;
        response.IsSuccess = true;
        response.Name = "qewtrywrh";
        response.Tax = 234.56M * 0.12M;

        return response;
    }
}
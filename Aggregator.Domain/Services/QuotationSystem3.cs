namespace Aggregator.Domain.Services;

public class QuotationSystem3 : QuotationSystem.QuotationSystem
{
    public QuotationSystem3(string url, string port) : base(url, port)
    {

    }

    public override dynamic GetPrice(dynamic request)
    {
        //Omitted - Call to an external service
        //var response = _someExternalService.PostHttpRequest(requestData);

        dynamic response = new ExpandoObject();
        response.Price = 92.67M;
        response.IsSuccess = true;
        response.Name = "zxcvbnm";
        response.Tax = 92.67M * 0.12M;

        return response;
    }
}
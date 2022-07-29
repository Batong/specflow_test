using RestSharp;

namespace SpecFlowTest.API;

public class ApplicationInterface
{

    public RestResponse? Response;
    public string BaseUrl { get; set; }
    public string Endpoint { get; set; }

    public ApplicationInterface(string endpoint = "empty", string baseUrl = "empty")
    {
        Endpoint = endpoint;
        BaseUrl = baseUrl;
    }

    public void ExecuteRequest()
    {
        RestClient client = new RestClient(BaseUrl);
        RestRequest request = new RestRequest(Endpoint, Method.Get);
        Response = client.Execute(request);
    }
}
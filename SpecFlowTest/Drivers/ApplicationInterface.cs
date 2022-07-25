using Dynamitey.DynamicObjects;
using Google.Protobuf;
using RestSharp;

namespace SpecFlowTest.API;

public class ApplicationInterface
{

    public RestResponse? Response;
    public string BaseUrl { get; set; }
    public string Endpoint { get; set; }

    public ApplicationInterface(string Endpoint = "empty", string BaseUrl = "empty")
    {
        this.Endpoint = Endpoint;
        this.BaseUrl = BaseUrl;
    }

    public void ExecuteRequest()
    {
        RestClient Client = new RestClient(BaseUrl);
        RestRequest request = new RestRequest(Endpoint, Method.Get);
        Response = Client.Execute(request);
    }
}
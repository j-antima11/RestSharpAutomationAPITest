using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RestSharpAutomationAPITest.Resources
{
    public class Helper<T>
    {
        public RestClient client;
        public RestRequest request;
        public string endPoint = "https://reqres.in/";

        public RestClient SetUrl(string resource)
        {
            var url = Path.Combine(endPoint, resource);
            var client = new RestClient(url);
            return client;
        }

        public RestRequest CreatePostRequest(string jsonload)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreatePutRequest(string jsonload)
        {
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", jsonload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateGetRequest()
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }

        public string Serialize(dynamic content)
        {
            string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
            return serializeObject;
        }

    }
}

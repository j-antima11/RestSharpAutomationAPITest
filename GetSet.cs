using RestSharpAutomationAPITest.Model;
using RestSharpAutomationAPITest.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAutomationAPITest
{
    public class GetSet<T>
    {
        public ListOfUsers GetUsers(string endpoint)
        {
            var user = new Helper<ListOfUsers>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListOfUsers content = user.GetContent<ListOfUsers>(response);
            return content;
        }

        public PostActions CreateUser(string resource, dynamic payload)
        {
            var user = new Helper<PostActions>();
            var url = user.SetUrl(resource);
            var jsonReq = user.Serialize(payload);
            var request = user.CreatePostRequest(jsonReq);
            var response = user.GetResponse(url, request);
            PostActions content = user.GetContent<PostActions>(response);
            return content;
        }

    }
}

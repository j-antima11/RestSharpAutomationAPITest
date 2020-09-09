using System;
using System.Text;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharpAutomationAPITest.Model;

namespace RestSharpAutomationAPITest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class UnitTest1
    {
        [Test]

        // 1.Verify that a POST request can be posted to the API to create the single user and assert that the single user is created. 
        public void PostRequest()
        {

            var callClient = new RestClient("https://reqres.in/api/");

            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("name", "morpheus");
            //jObjectbody.Add("job", "leader");

            var request = new RestRequest("users", Method.POST);
            //request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new PostActions() { name = "morpheus", job = "leader" });

            var restResponse = callClient.Execute<PostActions>(request);

            Console.WriteLine(restResponse.Content);

            Assert.That(restResponse.Data.name.ToString, Is.EqualTo("morpheus"), "The user is not found");

        }

        //2.Verify that a GET request can be posted to the API to get the expected details of single user
        public void GetSingleUser()
        {
            //Creating Client connection	
            var restClient = new RestClient("https://reqres.in/api/users");

            //Creating request to get data from server
            var restRequest = new RestRequest("1", Method.GET);

            // Executing request to server and checking server response to the it
            var restResponse = restClient.Execute<PostActions>(restRequest);

            // JObject ops = JObject.Parse(restResponse.Content);
            // Assert.That(ops["name"].ToString, Is.EqualTo("George"), "The user is not found");
            Assert.That(restResponse.Data.name.ToString, Is.EqualTo("George"), "The user is not found");
        }

        //3.Verify that a GET request can be posted to the API to get the expected details of the list of users
        public void GetUserList()
        {
            //Creating Client connection	
            var restClient = new RestClient("https://reqres.in/api");

            //Creating request to get data from server
            var restRequest = new RestRequest("users", Method.GET);

            // Executing request to server and checking server response to the it
            var restResponse = restClient.Execute<List<PostActions>>(restRequest);

            Console.WriteLine(restResponse.Content);
        }


        //4.Verify that a PUT request can be posted to the API to update the single user and assert that the expected update was made. 
         public void PutData()
        {

            var callClient = new RestClient("https://reqres.in/api/users");

            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("name", "morpheus");
            //jObjectbody.Add("job", "leader");

            var request = new RestRequest("1", Method.PUT);
            //request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new PostActions() { job = "engineer" });

        }

        //5.Verify that a GET request can be posted to the API to return a single user not found, which should return a “404” response.

        public void GetIncorrectUser()
        {
            //Creating Client connection	
            var restClient = new RestClient("https://reqres.in/api/users");

            //Creating request to get data from server
            var restRequest = new RestRequest("14", Method.GET);

            // Executing request to server and checking server response to the it
            var restResponse = restClient.Execute<PostActions>(restRequest);

            Assert.That(restResponse.Data.name.ToString, Is.EqualTo("Marcus"), "The user is not found");
        }

    }
}

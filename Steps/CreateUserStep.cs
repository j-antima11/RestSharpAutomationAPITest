using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpAutomationAPITest.Model;
using System;
using TechTalk.SpecFlow;

namespace RestSharpAutomationAPITest.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        
        
        
        const string Endpoint = " https://reqres.in/";
        [Given(@"name of user = morpheus")]
        public void GivenNameOfUser(string name)
        {
           
        }
        
        [Given(@"job = leader")]
        public void GivenJobLeader()
        {
            
        }
        
        [When(@"I create user")]
        public void WhenICreateUser()
        {
            
        }
        
        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var result = callClient.Execute<PostActions>(response);
            Assert.AreEqual(CreateUser.name, result.name);
            Assert.AreEqual(CreateUser.job, result.job);
        }
    }
}

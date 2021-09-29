﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpAutomation.HelperClass.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceAutomation.Model.JsonModel;

namespace RestSharpAutomation.RestPostEndPoint
{
    [TestClass]
    public class TestPostEndPoint
    {
        private string _url = "https://reqres.in/api/users";
        [TestMethod]
        public void TestCreateUserWithJson()
        {
            string payload = @"{
           ""name"": ""Robin Sehwag1"",
            ""job"": ""Team leader""
             }";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = _url
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(payload);
            IRestResponse restReponse = restClient.Post(restRequest);
            Assert.AreEqual(201, (int)restReponse.StatusCode);
            Console.WriteLine(restReponse.Content);


        }
        private UserCreationRequest CreateUserModel()
        {
            UserCreationRequest userRequest = new UserCreationRequest();
            userRequest.name = "Rohit Basin2";
            userRequest.job = "Tester";
            return userRequest;

        }
        [TestMethod]
        public void TestCreateUserWithJsonObject()
        {
            
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = _url
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(CreateUserModel());// restsharp automatically serielaize to JSON format
            IRestResponse restReponse = restClient.Post(restRequest);
            Assert.AreEqual(201, (int)restReponse.StatusCode);
            Console.WriteLine(restReponse.Content);


        }
        [TestMethod]
        public void TestCreateUserWithJson_Helper()
        {
           Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json" }

        };
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<UserCreationRequest> restResponse = restClientHelper.PerformPostRequest<UserCreationRequest>(_url, headers, CreateUserModel());
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);

        }


    }
}

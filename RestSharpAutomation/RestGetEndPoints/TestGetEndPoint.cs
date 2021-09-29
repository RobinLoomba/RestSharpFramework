using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpAutomation.HelperClass.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceAutomation.Model.JsonModel;

namespace RestSharpAutomation.RestGetEndPoints
{
    [TestClass]
   public  class TestGetEndPoint
    {
        private string _getUrl = "https://reqres.in/api/users?page=2";
        [TestMethod]
        public void TestGetUsingRestSharp()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(_getUrl);
            IRestResponse  restResponse = restClient.Get(restRequest);
            //Console.WriteLine(restResponse.IsSuccessful);
            //Console.WriteLine(restResponse.StatusCode);
            if(restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code is " + restResponse.StatusCode);
                Console.WriteLine("Response Content  is " + restResponse.Content);
                
            }
           

        }
        [TestMethod]
        public void TestGetXMLFormat()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(_getUrl);
            restRequest.AddHeader("Accept", "application/xml");
            IRestResponse restResponse = restClient.Get(restRequest);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code is " + restResponse.StatusCode);
                Console.WriteLine("Response Content  is " + restResponse.Content);

            }



        }
        [TestMethod]
        public void TestGetWithJsonSerialize()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(_getUrl);
            restRequest.AddHeader("Accept", "application/json");
            IRestResponse<UserResponse> restResponse =  restClient.Get<UserResponse>(restRequest);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code is " + restResponse.StatusCode);
                Console.WriteLine("Response Content  is " + restResponse.Content);
                Console.WriteLine("Page number is " + restResponse.Data.total_pages);

            }
            else
            {

            }



        }
        [TestMethod]
        public void TestGetWithJsonHelperClass()
        {

            Dictionary<string, string> headers = new Dictionary<string, string>()
           {
               {"Accept","application/json" }
           };
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformGetRequest(_getUrl, headers);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Console.WriteLine(restResponse.Content);
            IRestResponse<UserResponse> restResponse1 = restClientHelper.PerformGetRequest<UserResponse>(_getUrl, headers);
            Assert.AreEqual(2, restResponse1.Data.total_pages);



        }
    }
}

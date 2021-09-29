using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebServiceAutomation.Model;
using WebServiceAutomation.Model.JsonModel;

namespace WebServiceAutomation
{
    [TestClass]
    public class UnitTest1
    {
        private string _getUrl = "https://reqres.in/api/users?page=2";
        [TestMethod]
        public void TestGetAllEndPoint()
        {
            HttpClient httpClient = new HttpClient();// Create object for HTTp Client
            httpClient.GetAsync(_getUrl);//Call GetSync MEthod
            httpClient.Dispose();//To Close the http connection
        }
        [TestMethod]
        public void TestGetAllEndPointwithUri()
        {
            HttpClient httpClient = new HttpClient();// Create object for HTTp Client
            Uri getUri = new Uri(_getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);//Call GetSync MEthod
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code is " + (int)statusCode);
            httpClient.Dispose();//To Close the http connection
        }
        [TestMethod]
        public void TestGetAllEndPointwithInvalidUri()
        {
            HttpClient httpClient = new HttpClient();// Create object for HTTp Client
            Uri getUri = new Uri(_getUrl+"/Test");
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);//Call GetSync MEthod
            HttpResponseMessage httpResponseMessage = httpResponse.Result;  
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            HttpContent responseContent =  httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            Console.WriteLine("Status Code is " + (int)statusCode);
            httpClient.Dispose();//To Close the http connection
        }
        [TestMethod]
        public void TestGetAllEndPointJsonFormat()
        {
            HttpClient httpClient = new HttpClient();// Create object for HTTp Client
            HttpRequestHeaders requestHeaders =  httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
            Uri getUri = new Uri(_getUrl);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);//Call GetSync MEthod
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            Console.WriteLine("Status Code is " + (int)statusCode);
            httpClient.Dispose();//To Close the http connection

        }
        [TestMethod]
        public void TestGetEndPointUsingSendSync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(_getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage>  httpResponse = httpClient.SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            Console.WriteLine("Status Code is " + (int)statusCode);
            httpClient.Dispose();//To Close the http connection


        }
        [TestMethod]
        public void TestUsingMEthod()// with the help of using clause , No need to close the connection and framework will handle itself
        {
            using(HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(_getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
                    using(HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                       // Console.WriteLine(httpResponseMessage.ToString());
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //Console.WriteLine(data);

                        //Console.WriteLine("Status Code is " + (int)statusCode);
                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        Console.WriteLine(restResponse.ToString());

                    }

                }

            }

        }
        [TestMethod]
        public void TestDeserializeMethodTest()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(_getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        // Console.WriteLine(httpResponseMessage.ToString());
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        HttpContent responseContent = httpResponseMessage.Content;
                        Task<string> responseData = responseContent.ReadAsStringAsync();
                        string data = responseData.Result;
                        //Console.WriteLine(data);

                        //Console.WriteLine("Status Code is " + (int)statusCode);
                        RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
                        // Console.WriteLine(restResponse.ToString());
                        UserResponse response = JsonConvert.DeserializeObject<UserResponse>(restResponse.ResponseData);
                        Assert.AreEqual(200, (int)statusCode);
                        Assert.AreEqual(2, response.total_pages);
                       

                    }

                }

            }

        }
    }
}

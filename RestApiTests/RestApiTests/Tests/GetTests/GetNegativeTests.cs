using System;
using RestSharp;
using System.Net;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using RestApiTests.Model;

namespace RestApiTests.Tests.GetTests
{
    [TestFixture]
    public class GetNegativeTests
    {
        [Test]
        public void ShouldReturn0ItemsWhenResourcePathIsEmpty()
        {
            var jsonfile = File.ReadAllText("DataDefaultPattern.json");
            var itempattern = JsonConvert.DeserializeObject<DataPattern>(jsonfile);

            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["emptyPath"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.IsFalse(
                response.Content.Contains(itempattern.Currency)
                |
                response.Content.Contains(itempattern.Design_Url)
                ); // выбрано 2 сущности, хотя можно было и одну.
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Error, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPathContainsSymbolЪAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["PathЪ"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(500, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPathContainsSymbolBracketAfterNumbers()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["Path["], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(500, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPathContainsSymbolBracketSlash()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["Path/["], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(405, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPathContainsAmpersandAtTheBeginning()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["Path&"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(404, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }
    }
}

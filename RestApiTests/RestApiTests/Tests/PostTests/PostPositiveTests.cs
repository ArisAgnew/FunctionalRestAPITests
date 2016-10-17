using System;
using RestSharp;
using System.Net;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using RestApiTests.Model;

namespace RestApiTests.Tests.PostTests
{
    [TestFixture]
    public class PostPositiveTests
    {
        [Test]
        public void ShouldReturnCorrectValue()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["correctValue"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(td.GetValue()["correctValue"], response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectValueWhenPostPathContainsSomeQuery()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath/?"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["correctValue"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(td.GetValue()["correctValue"], response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectNegativeValueWhenValueIsDoubleMin()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["doubleMin"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(
                td.GetValue()["doubleMin"].ToString(), response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectPositiveValueWhenValueIsDoubleMax()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["doubleMax"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(
                td.GetValue()["doubleMax"].ToString(), response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectConvertedValueWhenValueIsDouble()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["doubleValue"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            // Convertion this 4.94065645841247E+7D into this 49406564,5841247
            Assert.AreEqual(
                td.GetValue()["doubleValue"].ToString(), response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectConvertedValueWhenValueIsZeroHex()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["zeroHex"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            // Convertion 0x0000000000000000 into 0
            Assert.AreEqual(
                td.GetValue()["zeroHex"].ToString(), response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectConvertedValueWhenValueIsUInt64MaxValueHex()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["uint64MaxValueHex"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            // Convertion 0xffffffffffffffff into 18446744073709551615, (in some cases return -1, but it's not our occasion)
            Assert.AreEqual(
                td.GetValue()["uint64MaxValueHex"].ToString(), response.Data.Title);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }
    }
}

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
    public class PostNegativeTests
    {
        [Test]
        public void ShouldReturnErrorWhenValueIsEmpty()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["correctKey"], td.GetValue()["emptyValue"]);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content, "Invalid parameters");
            Assert.AreEqual(400, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Error, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenResourcePathIsEmpty()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["emptyPath"], Method.POST);

            request.AddParameter(td.GetKey()["correctKey"], string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(405, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenKeyIsEmpty()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["emptyPath"], Method.POST);

            request.AddParameter(td.GetKey()["emptyKey"], string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(405, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenKeyContainsSingleSpaceSymbol()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPostPath"], Method.POST);

            request.AddParameter(
                td.GetKey()["singleSpaceKey"], string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(500, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPostPathContainsBracketAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["incorrectPostPath["], Method.POST);

            request.AddParameter(string.Empty, string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content, "Operation is not supported");
            Assert.AreEqual(400, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Error, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPostPathContainsQuestionSymbol()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["incorrectPostPath?"], Method.POST);

            request.AddParameter(string.Empty, string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(405, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPostPathContainsAmpersandSymbolAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["incorrectPostPath&"], Method.POST);

            request.AddParameter(string.Empty, string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(404, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPostPathContainsBracketSymbolAfterSlashAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["incorrectPostPath/["], Method.POST);

            request.AddParameter(string.Empty, string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(500, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }

        [Test]
        public void ShouldReturnErrorWhenPostPathContainsAmpersandSymbolAfterSlashAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["incorrectPostPath&"], Method.POST);

            request.AddParameter(string.Empty, string.Empty);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsEmpty(response.Content);
            Assert.AreEqual(404, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.POST, response.Request.Method);
        }
    }
}

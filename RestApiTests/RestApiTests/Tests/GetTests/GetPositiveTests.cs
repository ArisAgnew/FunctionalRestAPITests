using System;
using RestSharp;
using System.Net;
using NUnit.Framework;
using RestApiTests.Model;

namespace RestApiTests.Tests.GetTests
{
    [TestFixture]
    public class GetPositiveTests
    {
        [Test]
        public void ShouldReturnCorrectAssertionOfItemValues()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctSingleAccountsPath"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.AreEqual(
                "/content/images/MasterCard_Gold_EMV_PayPass_ЕжикСобака.png",
                response.Data.Design_Url);
            Assert.AreEqual(0, response.Data.Transactions_Total_Amount);
            Assert.AreEqual(472465, response.Data.Tariff_Avg_Month_Balance);
            Assert.AreEqual(1, response.Data.Type);
            Assert.AreEqual("2019-10-31T00:00:00", response.Data.Closing_Date);
            Assert.AreEqual(1, response.Data.Partial_Withdraw_Available);
            Assert.AreEqual(1, response.Data.Refill_Available);
            Assert.AreEqual(-1000, response.Data.Blocked_Amount);
            Assert.AreEqual("xint", response.Data.Scheme_Id);
            Assert.AreEqual("5449***1331", response.Data.Pan);
            Assert.AreEqual(12345678, response.Data.Account_Id);
            Assert.AreEqual("MasterCard1331", response.Data.Title_Small);
            // При прогоне тестов методом POST значение меняется, таким образом
            // при последовательном прогоне всей пачки тестов, значение будет равно по
            // ключу "correctValue".
            Assert.AreEqual(td.GetValue()["correctValue"], response.Data.Title);
            Assert.AreEqual(1000, response.Data.Balance);
            Assert.AreEqual("RUR", response.Data.Currency);
            Assert.AreEqual(false, response.Data.IsSalary);
        }

        [Test]
        public void ShouldReturnCorrectResponseDataWhenPathIsCorrect()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctSingleAccountsPath"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectResponseWhenPathContainsSomeQuery()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctPathWithQuery"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectResponseWhenPathContainsQuestionSymbolAtTheBeginning()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["Path?1"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Error, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShouldReturnCorrectResponseWhenPathContainsQuestionSymbolAtTheEnding()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["Path?2"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }

        [Test]
        public void ShoudReturnCorrectResponseDataArrayWhenPathIsCorrect()
        {
            var td = new TestData();
            var client = new RestClient(td.BaseUrl);
            var request = new RestRequest(td.GetResourcePath()["correctAccountsPath"], Method.GET);

            IRestResponse<Data> response = client.Execute<Data>(request);

            Assert.IsNotEmpty(response.Content);
            Assert.AreEqual(200, response.StatusCode.GetHashCode());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(Method.GET, response.Request.Method);
        }
    }
}

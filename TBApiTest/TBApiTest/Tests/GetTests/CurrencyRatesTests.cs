using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using TBApiTest.Models;
using TBApiTest.Base;

namespace TBApiTest.Tests.GetTests
{
    [TestFixture]
    public class CurrencyRatesTests
    {
        [Test]
        public void CheckThatJsonObjectsSuchAsFromCurrencyAndToCurrencyShouldMatchToCodeAndNameValues()
        {
            // JPath выражения
            string jsonFromCurPath  = "$...fromCurrency";
            string jsonToCurPath    = "$...toCurrency";

            var datapattern = new DataPattern();
            var testdata    = new TestData();
            var http        = new HttpAction();

            var response = http.GETRequest(testdata.BaseUrl, testdata.GetResourcePath()["currencyRatesPath"]);
            var content  = response.Content;

            JObject jsonObj = JObject.Parse(content);            
            IEnumerable<JToken> jsonArrayFromCur    = jsonObj.SelectTokens(jsonFromCurPath, true);
            IEnumerable<JToken> jsonArrayToCur      = jsonObj.SelectTokens(jsonToCurPath, true);

            var rubcode = datapattern.GetCurrencyStuff()["rubcode"];
            var rubname = datapattern.GetCurrencyStuff()["rubname"];
            var usdcode = datapattern.GetCurrencyStuff()["usdcode"];
            var usdname = datapattern.GetCurrencyStuff()["usdname"];
            var eurcode = datapattern.GetCurrencyStuff()["eurcode"];
            var eurname = datapattern.GetCurrencyStuff()["eurname"];
            var gbpcode = datapattern.GetCurrencyStuff()["gbpcode"];
            var gbpname = datapattern.GetCurrencyStuff()["gbpname"];
            
            foreach (JToken fromCur in jsonArrayFromCur)
            {
                string cutFromCur = fromCur.ToString().
                    Trim(new char[] { '{', '}' }).Replace(" ", string.Empty);
                Debug.WriteLine(cutFromCur);
                if (cutFromCur.Contains(rubcode))
                {
                    Assert.That(cutFromCur.Contains(rubcode));
                    Debug.WriteLine("RUB TRUE");
                }
                else if (cutFromCur.Contains(usdcode))
                {
                    Assert.That(cutFromCur.Contains(usdcode));
                    Debug.WriteLine("USD TRUE");
                }
                else if (cutFromCur.Contains(eurcode))
                {
                    Assert.That(cutFromCur.Contains(eurcode));
                    Debug.WriteLine("EUR TRUE");
                }
                else if (cutFromCur.Contains(gbpcode))
                {
                    Assert.That(cutFromCur.Contains(gbpcode));
                    Debug.WriteLine("GBP TRUE");
                }
                else
                    throw new Exception(
                        $"Matching CurrencyCode did not happen.");
            }


            foreach (JToken toCur in jsonArrayToCur)
            {
                var cutToCur = toCur.ToString().
                    Trim(new char[] { '{', '}' }).Replace(" ", string.Empty);
                Debug.WriteLine(cutToCur);
                if (cutToCur.Contains(rubname))
                {
                    Assert.That(cutToCur.Contains(rubname));
                    Debug.WriteLine("RUB TRUE");
                }
                else if (cutToCur.Contains(usdname))
                {
                    Assert.That(cutToCur.Contains(usdname));
                    Debug.WriteLine("USD TRUE");
                }
                else if (cutToCur.Contains(eurname))
                {
                    Assert.That(cutToCur.Contains(eurname));
                    Debug.WriteLine("EUR TRUE");
                }
                else if (cutToCur.Contains(gbpname))
                {
                    Assert.That(cutToCur.Contains(gbpname));
                    Debug.WriteLine("GBP TRUE");
                }
                else
                    throw new Exception(
                        $"Matching CurrencyName did not happen.");
            }
        }
    }
}

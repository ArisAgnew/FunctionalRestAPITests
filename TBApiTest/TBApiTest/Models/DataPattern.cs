using System.Collections.Generic;

namespace TBApiTest.Models
{
    class DataPattern
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Получает совокупность шаблонов валютных данных
        /// *С# 6.0
        /// </returns>
        public Dictionary<dynamic, dynamic> GetCurrencyStuff() =>
            new Dictionary<dynamic, dynamic>
            {
                {"rubcode", "\"code\":643,"},
                {"rubname", "\"name\":\"RUB\""},
                {"usdcode", "\"code\":840,"},
                {"usdname", "\"name\":\"USD\""},
                {"eurcode", "\"code\":978,"},
                {"eurname", "\"name\":\"EUR\""},
                {"gbpcode", "\"code\":826,"},
                {"gbpname", "\"name\":\"GBP\""},
            };
    }

    class TestData
    {
        private string baseurl = "https://www.tinkoff.ru/";

        public string BaseUrl
        {
            get { return baseurl; }
            protected set { baseurl = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Получает необходимый resoursce path
        /// *С# 6.0
        /// </returns>
        public Dictionary<string, object> GetResourcePath() =>
            new Dictionary<string, object>
            {
                {"currencyRatesPath", "api/v1/currency_rates/" }
            };
    }
}

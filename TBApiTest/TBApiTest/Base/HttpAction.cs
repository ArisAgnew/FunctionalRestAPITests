using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;

namespace TBApiTest.Base
{
    public class HttpAction
    {
        /// <summary>
        /// GET метод, запрашивающий содержимое ресурса uri
        /// Иcпользуется фреймворк RestSharp
        /// </summary>
        /// <param name="baseurl"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual IRestResponse GETRequest(string baseurl, dynamic path)
        {
            var client = new RestClient(baseurl);
            var request = new RestRequest(path, Method.GET);
            var response = client.Execute(request);
            return response;
        }        

        /// <summary>
        /// Асинхронный GET метод, запрашивающий содержимое ресурса uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public virtual async Task<string> GETRequest(string uri)
        {
            HttpClient client = new HttpClient();
            return await Task.Run(
                async () =>
                {
                    var response = await client.GetAsync(new Uri(uri));
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            );
        }
    }
}

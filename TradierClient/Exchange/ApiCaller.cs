using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange
{
    internal class ApiCaller
    {
        private readonly string _apiHost = "";
        public ApiCaller() 
        {
            _apiHost = ConfigurationManager.AppSettings["TradierUrl"];
        }

        public async Task<bool> Call(ITradierCommand cmd)
        {
            bool success = false;
            using(HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.Method = cmd.HttpMethod;
                request.Headers.Accept.Clear();
                if (cmd.MessageFormat.CompareTo(MessageFormatEnum.JSON) == 0)
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                else //defaulting to Xml
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                }
                request.Headers.Add("Authorization", String.Format("Bearer {0}", cmd.AccessToken));

                StringBuilder sbParams = new StringBuilder();
                foreach(string key in cmd.Parameters.Keys)
                {
                    if(sbParams.Length > 0)
                        sbParams.Append("&");

                    sbParams.Append(HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(cmd.Parameters[key]));
                }
                request.RequestUri = new Uri(String.Format("{0}{1}?{2}", _apiHost, cmd.UriStem, sbParams.ToString()));
                HttpResponseMessage response = await client.SendAsync(request);

                success = response.IsSuccessStatusCode;
                string content = await response.Content.ReadAsStringAsync();

                RawResponse raw = new RawResponse((int)response.StatusCode, content);
                cmd.RawResponse = raw;
            }
            return success;
        }
    }
}

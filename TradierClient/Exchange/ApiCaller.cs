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

            HttpRequestMessage request = null;
            if (cmd.HttpMethod == HttpMethod.Get)
            {
                request = CreateGetRequest(cmd);
            }
            else if (cmd.HttpMethod == HttpMethod.Post)
            { }
            else
                throw new ArgumentOutOfRangeException(String.Format("Unrecognized HttpMethod value on ITradierCommand: {0}", cmd.HttpMethod.Method));

            //Initialize headers common to every call
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

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.SendAsync(request);

                success = response.IsSuccessStatusCode;
                string content = await response.Content.ReadAsStringAsync();

                RawResponse raw = new RawResponse((int)response.StatusCode, content);
                cmd.RawResponse = raw;
            }
            return success;
        }

        private HttpRequestMessage CreatePostRequest(ITradierCommand cmd)
        {
            var request = new HttpRequestMessage();
            request.Method = cmd.HttpMethod; 
            
            StringBuilder sbParams = new StringBuilder();
            foreach (string key in cmd.Parameters.Keys)
            {
                if (sbParams.Length > 0)
                    sbParams.Append("&");

                sbParams.Append(HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(cmd.Parameters[key]));
            }

            request.Content = new StringContent(sbParams.ToString());
            //TODO: Need to set RequestUri here.
            return request;
        }

        private HttpRequestMessage CreateGetRequest(ITradierCommand cmd)
        {
            var request = new HttpRequestMessage();
            request.Method = cmd.HttpMethod;

            StringBuilder sbParams = new StringBuilder();
            foreach (string key in cmd.Parameters.Keys)
            {
                if (sbParams.Length > 0)
                    sbParams.Append("&");

                sbParams.Append(HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(cmd.Parameters[key]));
            }
            request.RequestUri = new Uri(String.Format("{0}{1}?{2}", _apiHost, cmd.UriStem, sbParams.ToString()));
            return request;
        }
    }
}

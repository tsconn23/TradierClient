using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Commands
{
    internal abstract class BaseGetCommand : ITradierCommand
    {
        string _accessToken = "";
        public string AccessToken 
        {
            get { return _accessToken ?? ""; }
            set { _accessToken = value; } 
        }

        public HttpMethod HttpMethod
        {
            get { return HttpMethod.Get; }
        }

        public MessageFormatEnum MessageFormat { get; set; }

        private Dictionary<string, string> _parameters;
        public Dictionary<string, string> Parameters
        {
            get 
            {
                if (_parameters == null) _parameters = new Dictionary<string, string>();
                return _parameters; 
            }
        }

        protected void AddParameter(string key, string value)
        {
            if (_parameters == null) _parameters = new Dictionary<string, string>();
            if (!_parameters.ContainsKey(key))
                _parameters.Add(key, value);
            else
                _parameters[key] = value;
        }

        public virtual string UriStem
        {
            get { throw new NotImplementedException(); }
        }

        private RawResponse _rawResponse = null;
        public virtual RawResponse RawResponse
        {
            get { return _rawResponse; }
            set { _rawResponse = value; }
        }

        protected string DateTimeFormat
        {
            get { return "yyyy-MM-dd HH:mm"; }
        }

        protected string DateFormat
        {
            get { return "yyyy-MM-dd"; }
        }
    }
}

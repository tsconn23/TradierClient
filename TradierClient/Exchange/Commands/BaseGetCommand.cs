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

        protected Dictionary<string, string> _parameters;
        public virtual Dictionary<string, string> Parameters
        {
            get { return _parameters; }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange
{
    public class RawResponse
    {
        public RawResponse(int statusCode, string content)
        {
            _statusCode = statusCode;
            _content = content;
        }

        private int _statusCode = 0;
        public int StatusCode
        {
            get { return _statusCode; }
        }

        private string _content = "";
        public string Content
        {
            get { return _content; }
        }
    }
}

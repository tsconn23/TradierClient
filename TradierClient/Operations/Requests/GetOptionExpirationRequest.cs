using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetOptionExpirationRequest
    {
        public GetOptionExpirationRequest(string symbol)
        {
            _symbol = symbol;
        }

        private string _symbol;
        public string Symbol
        {
            get
            {
                return _symbol ?? string.Empty;
            }
        }
    }
}

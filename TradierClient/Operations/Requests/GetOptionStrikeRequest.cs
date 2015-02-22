using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetOptionStrikeRequest
    {
        public GetOptionStrikeRequest(string symbol, DateTime expiration)
        {
            _symbol = symbol;
            _expiration = expiration;
        }

        private string _symbol;
        public string Symbol
        {
            get
            {
                return _symbol ?? string.Empty;
            }
        }

        private DateTime _expiration = DateTime.MinValue;
        public DateTime Expiration
        {
            get
            {
                return _expiration;
            }
        }
    }
}

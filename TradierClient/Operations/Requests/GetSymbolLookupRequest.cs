using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetSymbolLookupRequest
    {
        public GetSymbolLookupRequest(string keyword, string exchanges, string types)
        {
            _keyword = keyword;
            _exchanges = exchanges;
            _types = types;
        }

        private string _keyword = string.Empty;
        public string Keyword
        {
            get { return _keyword ?? string.Empty; }
        }

        private string _exchanges = string.Empty;
        public string Exchanges
        {
            get { return _exchanges ?? string.Empty; }
        }

        private string _types = string.Empty;
        public string Types
        {
            get { return _types ?? string.Empty; }
        }
    }
}

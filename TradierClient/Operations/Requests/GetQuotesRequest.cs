using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetQuotesRequest
    {
        public GetQuotesRequest(string symbol)
        {
            _symbols = new string[] { symbol };
        }

        public GetQuotesRequest(string[] symbols)
        {
            _symbols = symbols;
        }

        public GetQuotesRequest(string delimitedList, string delimiter)
        {
            delimitedList = delimitedList.Replace(" ","");
            _symbols = delimitedList.Split(new string[] {delimiter}, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] _symbols;
        public string[] Symbols
        {
            get { return _symbols ?? new string[] { }; }
        }
    }
}

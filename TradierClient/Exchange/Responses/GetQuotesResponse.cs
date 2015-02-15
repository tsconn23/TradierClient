using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Responses
{
    public class GetQuotesResponse : ITradierResponse
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }
}

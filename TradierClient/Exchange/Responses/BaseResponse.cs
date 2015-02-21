using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Responses
{
    public abstract class BaseResponse : ITradierResponse
    {
        public BaseResponse(RawResponse raw)
        {
            RawResponse = raw;
            //Create our object model if applicable based on raw.Content
        }

        public RawResponse RawResponse { get; set; }
    }
}

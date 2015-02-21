using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Responses
{
    public class GetOptionChainResponse : BaseResponse
    {
        public GetOptionChainResponse(RawResponse raw) : base(raw) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Responses
{
    public class GetHistoricalPricingResponse :BaseResponse
    {
        public GetHistoricalPricingResponse(RawResponse raw) : base(raw) { }
    }
}

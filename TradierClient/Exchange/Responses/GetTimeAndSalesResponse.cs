using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Responses
{
    public class GetTimeAndSalesResponse : BaseResponse
    {
        public GetTimeAndSalesResponse(RawResponse raw, MessageFormatEnum format) : base(raw)
        {
            this.MessageFormat = format;
        }
    }
}

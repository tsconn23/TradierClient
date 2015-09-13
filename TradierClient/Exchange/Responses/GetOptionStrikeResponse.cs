using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Responses
{
    public class GetOptionStrikeResponse : BaseResponse
    {
        public GetOptionStrikeResponse(RawResponse raw, MessageFormatEnum format) : base(raw)
        {
            this.MessageFormat = format;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Interfaces
{
    internal interface ITradierResponse
    {
        int StatusCode { get; set; }

        string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Interfaces
{
    public interface ITradierResponse
    {
        RawResponse RawResponse { get; set; }
    }
}

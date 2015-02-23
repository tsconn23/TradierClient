using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetMarketCalendarRequest
    {
        public GetMarketCalendarRequest(int month, int year)
        {
            Month = month;
            Year = year;
        }

        public int Month { get; private set; }

        public int Year { get; private set; }

    }
}

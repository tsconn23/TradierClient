using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetMarketCalendarCommand : BaseGetCommand
    {
        public GetMarketCalendarCommand(int month, int year, string accessToken)
        {
            AddParameter("month", month.ToString());
            AddParameter("year", year.ToString());
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/calendar"; }
        }
    }
}

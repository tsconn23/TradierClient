using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Commands
{
    internal class GetQuotesCommand : BaseGetCommand
    {
        public GetQuotesCommand(string[] symbols, string accessToken)
        {
            AddParameter("symbols", String.Join(",", symbols ?? new string[] { }));
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/quotes"; }
        }
    }
}

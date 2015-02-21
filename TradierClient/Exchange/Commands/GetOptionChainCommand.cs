using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetOptionChainCommand : BaseGetCommand
    {
        public GetOptionChainCommand(string symbol, DateTime expiration, string accessToken)
        {
            AddParameter("symbol", symbol ?? string.Empty);
            AddParameter("expiration", expiration.ToString(this.DateFormat));
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/options/chains"; }
        }
    }
}

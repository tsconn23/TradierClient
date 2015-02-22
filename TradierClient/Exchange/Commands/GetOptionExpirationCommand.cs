using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetOptionExpirationCommand : BaseGetCommand
    {
        public GetOptionExpirationCommand(string symbol, string accessToken)
        {
            AddParameter("symbol", symbol ?? string.Empty);
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/options/expirations"; }
        }
    }
}

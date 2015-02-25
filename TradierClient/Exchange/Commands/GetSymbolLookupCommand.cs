using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetSymbolLookupCommand : BaseGetCommand
    {
        public GetSymbolLookupCommand(string keyword, string accessToken)
        {
            AddParameter("q", keyword ?? string.Empty);
            AccessToken = accessToken;
        }

        public GetSymbolLookupCommand(string keyword, string exchanges, string types, string accessToken)
        {
            //if(!string.IsNullOrEmpty(keyword))
            /* I found in practice that the keyword/q parameter is not optional */
            AddParameter("q", keyword ?? string.Empty);

            if(!string.IsNullOrEmpty(exchanges))
                AddParameter("exchanges", exchanges ?? string.Empty);

            if(!string.IsNullOrEmpty(types))
                AddParameter("types", types.ToLower() ?? string.Empty);

            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/lookup"; }
        }
    }
}

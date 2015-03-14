using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetUserHistoryCommand : BaseGetCommand
    {
        public GetUserHistoryCommand(string accessToken)
        {
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/user/history"; }
        }
    }
}

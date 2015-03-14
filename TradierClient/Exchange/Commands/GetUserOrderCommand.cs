using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetUserOrderCommand : BaseGetCommand
    {
        public GetUserOrderCommand(string accessToken)
        {
            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/user/orders"; }
        }
    }
}

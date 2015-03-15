using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Commands
{
    internal class GetAccountOrderStatusCommand : BaseGetCommand
    {
        public GetAccountOrderStatusCommand(string accountId, string orderId, string accessToken)
        {
            _accountId = accountId ?? "";
            _orderId = orderId ?? "";
            AccessToken = accessToken;
        }

        private string _accountId = "";
        private string _orderId = "";

        public override string UriStem
        {
            get { return String.Format("v1/accounts/{0}/orders/{1}", _accountId, _orderId); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Commands
{
    internal class GetAccountCostBasisCommand : BaseGetCommand
    {
        public GetAccountCostBasisCommand(string accountId, string accessToken)
        {
            _accountId = accountId ?? "";
            AccessToken = accessToken;
        }

        private string _accountId = "";

        public override string UriStem
        {
            get { return String.Format("v1/accounts/{0}/gainloss", _accountId); }
        }
    }
}

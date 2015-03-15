using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Commands
{
    internal class GetAccountHistoryCommand : BaseGetCommand
    {
        public GetAccountHistoryCommand(string accountId, int offset, int perPage, string accessToken)
        {
            _accountId = accountId ?? "";
            _offset = offset;
            _perPage = perPage;
            AccessToken = accessToken;
        }

        private string _accountId = "";
        private int _offset = 0;
        private int _perPage = 0;

        public override string UriStem
        {
            //get { return String.Format("v1/accounts/{0}/history/{1}/{2}", _accountId, _offset, _perPage); }
            get { return String.Format("v1/accounts/{0}/history", _accountId); }
        }
    }
}

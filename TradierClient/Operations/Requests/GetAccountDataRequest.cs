using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    /// <summary>
    /// A generic request class for working with those account related methods that have AccountId as
    /// their only parameter.
    /// </summary>
    public class GetAccountDataRequest
    {
        public GetAccountDataRequest(string accountId)
        {
            _accountId = accountId ?? "";
        }

        private string _accountId;
        public string AccountId
        {
            get { return _accountId; }
        }
    }
}

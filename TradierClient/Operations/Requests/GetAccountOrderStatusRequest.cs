using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetAccountOrderStatusRequest
    {
        public GetAccountOrderStatusRequest(string accountId, string orderId)
        {
            _accountId = accountId ?? "";
            _orderId = orderId ?? "";
        }

        private string _accountId;
        public string AccountId
        {
            get { return _accountId; }
        }

        private string _orderId;
        public string OrderId
        {
            get { return _orderId; }
        }
    }
}

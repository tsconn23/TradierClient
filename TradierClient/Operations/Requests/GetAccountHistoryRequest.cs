using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetAccountHistoryRequest
    {
        public GetAccountHistoryRequest(string accountId, int offset, int perPage)
        {
            _accountId = accountId ?? "";
            _offset = offset;
            _perPage = perPage;
        }

        private string _accountId;
        public string AccountId
        {
            get { return _accountId; }
        }

        private int _offset = 0;
        public int Offset
        {
            get { return _offset; }
        }

        private int _perPage = 0;
        public int PerPage
        {
            get { return _perPage; }
        }
    }
}

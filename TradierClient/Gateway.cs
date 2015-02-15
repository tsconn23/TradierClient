using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient.Operations;

namespace TradierClient
{
    public class Gateway
    {
        private readonly string _accessToken = "";

        public Gateway(string accessToken)
        {
            _accessToken = accessToken;
        }

        internal string AccesToken
        {
            get { return _accessToken; }
        }

        private MessageFormatEnum _messageFormat = MessageFormatEnum.Undefined;
        public MessageFormatEnum MessageFormat
        {
            get { return _messageFormat; }
            set { _messageFormat = value; }
        }

        private MarketData _marketData = null;
        public MarketData MarketData
        {
            get
            {
                _marketData = _marketData ?? new MarketData(this);
                return _marketData;
            }
        }
    }
}

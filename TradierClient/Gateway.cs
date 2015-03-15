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

        private UserData _userData = null;
        public UserData UserData
        {
            get
            {
                _userData = _userData ?? new UserData(this);
                return _userData;
            }
        }

        private AccountData _accountData = null;
        public AccountData AccountData
        {
            get
            {
                _accountData = _accountData ?? new AccountData(this);
                return _accountData;
            }
        }
    }
}

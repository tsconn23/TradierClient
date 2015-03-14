using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient;
using TradierClient.Exchange;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Operations
{
    public abstract class BaseMarketOperations
    {
        private readonly Gateway _gateway = null;

        public BaseMarketOperations(Gateway gateway)
        {
            _gateway = gateway;
        }

        protected Gateway Gateway
        {
            get { return _gateway; }
        }

        protected async Task MakeApiCall(ITradierCommand command)
        {
            command.MessageFormat = Gateway.MessageFormat;
            var caller = new ApiCaller();
            await caller.Call(command);
        }
    }
}

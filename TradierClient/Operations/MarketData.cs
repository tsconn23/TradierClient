using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient;
using TradierClient.Exchange;
using TradierClient.Exchange.Commands;
using TradierClient.Exchange.Interfaces;
using TradierClient.Exchange.Responses;
using TradierClient.Operations.Requests;

namespace TradierClient.Operations
{
    public class MarketData
    {
        private readonly Gateway _gateway = null;

        public MarketData(Gateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<GetQuotesResponse> GetQuotes(GetQuotesRequest cmd)
        {
            var command = new GetQuotesCommand(cmd.Symbols, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;
            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetQuotesResponse();
            response.StatusCode = command.RawResponse.StatusCode;
            response.Content = command.RawResponse.Content;
            //Create our object model if applicable
            return response;
        }
    }
}

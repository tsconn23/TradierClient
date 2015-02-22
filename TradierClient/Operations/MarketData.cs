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

        public async Task<GetQuotesResponse> GetQuotes(GetQuotesRequest request)
        {
            var command = new GetQuotesCommand(request.Symbols, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;
            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetQuotesResponse(command.RawResponse);
            return response;
        }

        public async Task<GetIntradayStatusResponse> GetIntradayStatus()
        {
            var command = new GetIntradayStatusCommand(_gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;
            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetIntradayStatusResponse(command.RawResponse);
            return response;
        }

        public async Task<GetTimeAndSalesResponse> GetTimeAndSales(GetTimeAndSalesRequest request)
        {
            var command = new GetTimeAndSalesCommand(request.Symbol, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;

            command.Interval = request.Interval;
            command.SessionFilter = request.SessionFilter;
            command.StartDateTime = request.StartDateTime;
            command.EndDateTime = request.EndDateTime;

            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetTimeAndSalesResponse(command.RawResponse);
            return response;
        }

        public async Task<GetHistoricalPricingResponse> GetHistoricalPricing(GetHistoricalPricingRequest request)
        {
            var command = new GetHistoricalPricingCommand(request.Symbol, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;

            command.Interval = request.Interval;
            command.StartDateTime = request.StartDateTime;
            command.EndDateTime = request.EndDateTime;

            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetHistoricalPricingResponse(command.RawResponse);
            return response;
        }

        public async Task<GetOptionChainResponse> GetOptionChain(GetOptionChainRequest request)
        {
            var command = new GetOptionChainCommand(request.Symbol, request.Expiration, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;

            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetOptionChainResponse(command.RawResponse);
            return response;
        }

        public async Task<GetOptionExpirationResponse> GetOptionExpirations(GetOptionExpirationRequest request)
        {
            var command = new GetOptionExpirationCommand(request.Symbol, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;

            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetOptionExpirationResponse(command.RawResponse);
            return response;
        }

        public async Task<GetOptionStrikeResponse> GetOptionStrikes(GetOptionStrikeRequest request)
        {
            var command = new GetOptionStrikeCommand(request.Symbol, request.Expiration, _gateway.AccesToken);
            command.MessageFormat = _gateway.MessageFormat;

            //Send command to API
            var caller = new ApiCaller();
            await caller.Call(command);
            //Some handling of the response
            var response = new GetOptionStrikeResponse(command.RawResponse);
            return response;
        }
    }
}

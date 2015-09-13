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
    public class AccountData : BaseMarketOperations
    {
        public AccountData(Gateway gateway) : base(gateway) { }

        public async Task<GeneralAccountDataResponse> GetAccountBalance(GetAccountDataRequest request)
        {
            var command = new GetAccountBalancesCommand(request.AccountId, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralAccountDataResponse> GetAccountPositions(GetAccountDataRequest request)
        {
            var command = new GetAccountPositionsCommand(request.AccountId, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralAccountDataResponse> GetAccountHistory(GetAccountHistoryRequest request)
        {
            var command = new GetAccountHistoryCommand(request.AccountId, request.Offset, request.PerPage, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralAccountDataResponse> GetAccountCostBasis(GetAccountDataRequest request)
        {
            var command = new GetAccountCostBasisCommand(request.AccountId, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralAccountDataResponse> GetAccountOrders(GetAccountDataRequest request)
        {
            var command = new GetAccountOrdersCommand(request.AccountId, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralAccountDataResponse> GetAccountOrderStatus(GetAccountOrderStatusRequest request)
        {
            var command = new GetAccountOrderStatusCommand(request.AccountId, request.OrderId, Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralAccountDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }
    }
}

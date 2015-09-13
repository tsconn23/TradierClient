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
    public class UserData : BaseMarketOperations
    {
        public UserData(Gateway gateway) : base(gateway) { }

        public async Task<GeneralUserDataResponse> GetUserOrders()
        {
            var command = new GetUserOrderCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralUserDataResponse> GetUserProfile()
        {
            var command = new GetUserProfileCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralUserDataResponse> GetUserBalances()
        {
            var command = new GetUserBalancesCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralUserDataResponse> GetUserPositions()
        {
            var command = new GetUserPositionsCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralUserDataResponse> GetUserHistory()
        {
            var command = new GetUserHistoryCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }

        public async Task<GeneralUserDataResponse> GetUserCostBasis()
        {
            var command = new GetUserCostBasisCommand(Gateway.AccesToken);

            //Send command to API
            await MakeApiCall(command);

            //Some handling of the response
            var response = new GeneralUserDataResponse(command.RawResponse, command.MessageFormat);
            return response;
        }
    }
}

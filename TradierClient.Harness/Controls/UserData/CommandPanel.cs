using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradierClient.Exchange;
using TradierClient.Operations.Requests;

namespace TradierClient.Harness.Controls.UserData
{
    public partial class CommandPanel : BaseHarnessControl
    {
        public CommandPanel()
        {
            InitializeComponent();
        }

        public CommandPanel(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            string responseText = "";
            
            switch(ApiCall)
            {
                case "User Data/Get Profile":
                    var response = await ApiGateway.UserData.GetUserProfile();
                    responseText = response.RawResponse.Content;
                    break;
                case "User Data/Get Balances":
                    response = await ApiGateway.UserData.GetUserBalances();
                    responseText = response.RawResponse.Content;
                    break;
                case "User Data/Get Positions":
                    response = await ApiGateway.UserData.GetUserPositions();
                    responseText = response.RawResponse.Content;
                    break;
                case "User Data/Get History":
                    response = await ApiGateway.UserData.GetUserHistory();
                    responseText = response.RawResponse.Content;
                    break;
                case "User Data/Get Cost Basis":
                    response = await ApiGateway.UserData.GetUserCostBasis();
                    responseText = response.RawResponse.Content;
                    break;
                case "User Data/Get Orders":
                    response = await ApiGateway.UserData.GetUserOrders();
                    responseText = response.RawResponse.Content;
                    break;
            }

            txtResponse.Text = responseText;
        }
    }
}

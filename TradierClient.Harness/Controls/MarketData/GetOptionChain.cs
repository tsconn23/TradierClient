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

namespace TradierClient.Harness.Controls.MarketData
{
    public partial class GetOptionChain : BaseHarnessControl
    {
        public GetOptionChain()
        {
            InitializeComponent();
        }

        public GetOptionChain(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string msgValidation = "";

            if (txtSymbol.Text.Length == 0)
            {
                isValid = false;
                msgValidation = "Symbol textbox cannot be blank.\r\n";
            }

            if(DateTime.Now.Date.CompareTo(dateTimeExpiration.Value) > 0)
            {
                isValid = false;
                msgValidation += "Please provide a future date for expiration.\r\n";
            }

            if (msgValidation.Length > 0)
                MessageBox.Show(msgValidation);

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string responseText = "";
            if (ApiCall.CompareTo("Market/Get Option Strikes") == 0)
            {
                var request = new GetOptionStrikeRequest(txtSymbol.Text, dateTimeExpiration.Value);
                var response = await ApiGateway.MarketData.GetOptionStrikes(request);
                responseText = response.RawResponse.Content;
            }
            else //execute get option chain by default
            {
                var request = new GetOptionChainRequest(txtSymbol.Text, dateTimeExpiration.Value);
                var response = await ApiGateway.MarketData.GetOptionChain(request);
                responseText = response.RawResponse.Content;
            }

            txtResponse.Text = responseText;
        }
    }
}

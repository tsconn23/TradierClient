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
    public partial class GetQuotes : BaseHarnessControl
    {
        public GetQuotes() : base()
        {
            InitializeComponent();
        }

        public GetQuotes(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
            if (ApiCall.CompareTo("Market/Get Option Expirations") == 0)
            {
                label2.Text = "** Only one symbol may be used when fetching option expirations. **";
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string msgValidation = "";

            if(txtSymbols.Text.Length == 0)
            {
                isValid = false;
                msgValidation = "Symbols textbox cannot be blank.\r\n";
            }

            if (string.IsNullOrEmpty(ApiCall))
            {
                isValid = false;
                msgValidation += "Please select an API Call.\r\n";
            }

            if (msgValidation.Length > 0)
                MessageBox.Show(msgValidation);

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string responseText = "";

            if (ApiCall.CompareTo("Market/Get Quotes") == 0)
            {
                var request = new GetQuotesRequest(txtSymbols.Text, ",");
                var response = await ApiGateway.MarketData.GetQuotes(request);
                responseText = response.RawResponse.Content;
            }
            else if (ApiCall.CompareTo("Market/Get Option Expirations") == 0)
            {
                var request = new GetOptionExpirationRequest(txtSymbols.Text);
                var response = await ApiGateway.MarketData.GetOptionExpirations(request);
                responseText = response.RawResponse.Content;
            }
            txtResponse.Text = responseText;
        }
    }
}

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
            var request = new GetQuotesRequest(txtSymbols.Text, ",");
            var response = await ApiGateway.MarketData.GetQuotes(request);
            txtResponse.Text = response.Content;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradierClient;
using TradierClient.Exchange;
using TradierClient.Operations.Requests;

namespace TradierClient.Harness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var tradierGateway = InitializeGateway();

            switch(cmbApiCall.SelectedItem.ToString())
            {
                case "Market/GetQuotes":
                    var request = new GetQuotesRequest(txtSymbols.Text, ",");
                    var response = await tradierGateway.MarketData.GetQuotes(request);
                    txtResponse.Text = response.Content;
                    break;
            }
        }

        private Gateway InitializeGateway()
        {
            string accessToken = ConfigurationManager.AppSettings["AccessToken"];
            var gateway = new Gateway(accessToken);

            switch(cmbMessageFormat.SelectedItem.ToString())
            {
                case "JSON":
                    gateway.MessageFormat = MessageFormatEnum.JSON;
                    break;
                case "XML":
                    gateway.MessageFormat = MessageFormatEnum.XML;
                    break;
            }
            return gateway;
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
            if(cmbApiCall.SelectedIndex < 0)
            {
                isValid = false;
                msgValidation += "Please select an API Call.\r\n";
            }
            if(cmbMessageFormat.SelectedIndex < 0)
            {
                isValid = false;
                msgValidation += "Please select desired Message Format.\r\n";
            }

            if (msgValidation.Length > 0)
                MessageBox.Show(msgValidation);

            return isValid;
        }
    }
}

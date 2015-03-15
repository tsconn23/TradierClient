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

namespace TradierClient.Harness.Controls.AccountData
{
    public partial class CommandPanel : BaseHarnessControl
    {
        public CommandPanel()
        {
            InitializeComponent();
            //Putting the following in Designer.cs hoses the GUI
            txtAccountId.Text = CommandPanel.AccountId;
        }

        public CommandPanel(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
            //Putting the following in Designer.cs hoses the GUI
            txtAccountId.Text = CommandPanel.AccountId;
            if (ApiCall.CompareTo("Account/Get History") == 0)
            {
                label3.Visible = true;
                txtOffset.Visible = true;
                txtPageSize.Visible = true;
            }
            else if (ApiCall.CompareTo("Account/Get Order Status") == 0)
            {
                label2.Visible = true;
                txtOrderId.Visible = true;
            }
        }

        public static string AccountId { get; set; }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            CommandPanel.AccountId = txtAccountId.Text;

            string responseText = "";

            switch (ApiCall)
            {
                case "Account/Get Balances":
                    var response = await ApiGateway.AccountData.GetAccountBalance(new GetAccountDataRequest(txtAccountId.Text));
                    responseText = response.RawResponse.Content;
                    break;
                case "Account/Get Positions":
                    response = await ApiGateway.AccountData.GetAccountPositions(new GetAccountDataRequest(txtAccountId.Text));
                    responseText = response.RawResponse.Content;
                    break;
                case "Account/Get History":
                    response = await ApiGateway.AccountData.GetAccountHistory(new GetAccountHistoryRequest(txtAccountId.Text, int.Parse(txtOffset.Text), int.Parse(txtPageSize.Text)));
                    responseText = response.RawResponse.Content;
                    break;
                case "Account/Get Cost Basis":
                    response = await ApiGateway.AccountData.GetAccountCostBasis(new GetAccountDataRequest(txtAccountId.Text));
                    responseText = response.RawResponse.Content;
                    break;
                case "Account/Get Orders":
                    response = await ApiGateway.AccountData.GetAccountOrders(new GetAccountDataRequest(txtAccountId.Text));
                    responseText = response.RawResponse.Content;
                    break;
                case "Account/Get Order Status":
                    response = await ApiGateway.AccountData.GetAccountOrderStatus(new GetAccountOrderStatusRequest(txtAccountId.Text, txtOrderId.Text));
                    responseText = response.RawResponse.Content;
                    break;
            }

            txtResponse.Text = responseText;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string msgValidation = "";

            if (string.IsNullOrEmpty(txtAccountId.Text))
            {
                isValid = false;
                msgValidation = "AccountID is a required field.\r\n";
            }

            if (txtOrderId.Visible)
            {
                if (string.IsNullOrEmpty(txtOrderId.Text))
                {
                    isValid = false;
                    msgValidation += "OrderID is required for this call.\r\n";
                }
            }

            if (txtOffset.Visible)
            {
                if (string.IsNullOrEmpty(txtOffset.Text))
                {
                    txtOffset.Text = "1";
                }
                else
                {
                    int temp = 0;
                    if (!int.TryParse(txtOffset.Text, out temp))
                    {
                        isValid = false;
                        msgValidation += "Offset must be numeric.\r\n";
                    }
                }

                if (string.IsNullOrEmpty(txtPageSize.Text))
                {
                    txtPageSize.Text = "25";
                }
                else
                {
                    int temp = 0;
                    if (!int.TryParse(txtPageSize.Text, out temp))
                    {
                        isValid = false;
                        msgValidation += "Page Size must be numeric.\r\n";
                    }
                }
            }

            if (!isValid)
                MessageBox.Show(msgValidation);

            return isValid;
        }
    }
}

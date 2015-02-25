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
    public partial class GetIntradayStatus : BaseHarnessControl
    {
        public GetIntradayStatus()
        {
            InitializeComponent();
        }

        public GetIntradayStatus(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
            if (ApiCall.CompareTo("Market/Get Intraday Status") == 0)
            {
                label1.Visible = false;
                txtMonth.Visible = false;
                label2.Visible = false;
                txtYear.Visible = false;
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string errorMsg = "";

            if(txtMonth.Visible)
            {
                int m = 0;
                if(!int.TryParse(txtMonth.Text, out m))
                {
                    isValid = false;
                    errorMsg = "Month must be a numeric value between 01-12.\r\n";
                }
                else if(m < 1 || m > 12)
                {
                    isValid = false;
                    errorMsg = "Month must be a numeric value between 01-12.\r\n";
                }
            }

            if(txtYear.Visible)
            {
                int y = 0;
                if (!int.TryParse(txtYear.Text, out y))
                {
                    isValid = false;
                    errorMsg += "Year must be a numeric value.\r\n";
                }
                else if(txtYear.Text.Length != 4)
                {
                    isValid = false;
                    errorMsg += "Year must be four characters long.\r\n";
                }
            }

            if (!isValid) MessageBox.Show(errorMsg);

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string responseText = "";

            if (ApiCall.CompareTo("Market/Get Intraday Status") == 0)
            {
                var response = await ApiGateway.MarketData.GetIntradayStatus();
                responseText = response.RawResponse.Content;
            }
            else if (ApiCall.CompareTo("Market/Get Market Calendar") == 0)
            {
                var request = new GetMarketCalendarRequest(int.Parse(txtMonth.Text), int.Parse(txtYear.Text));
                var response = await ApiGateway.MarketData.GetMarketCalendar(request);
                responseText = response.RawResponse.Content;
            }

            txtResponse.Text = responseText;
        }
    }
}

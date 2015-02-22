using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradierClient.Exchange;
using TradierClient.Operations.Requests;

namespace TradierClient.Harness.Controls.MarketData
{
    public partial class GetTimeAndSales : BaseHarnessControl
    {
        public GetTimeAndSales()
            : base()
        {
            InitializeComponent();
        }

        public GetTimeAndSales(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
            if(ApiCall.CompareTo("Market/Get Historical Pricing") == 0)
            {
                label3.Visible = false;
                cmbSession.Visible = false;
                cmbSession.SelectedItem = null;

                cmbInterval.Items.Clear();
                cmbInterval.Items.Add("daily");
                cmbInterval.Items.Add("weekly");
                cmbInterval.Items.Add("monthly");
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            var sbError = new StringBuilder();

            if (txtSymbol.Text.Length == 0)
            {
                isValid = false;
                sbError.Append("You must supply a symbol.\r\n");
            }

            if (!isValid)
                MessageBox.Show(sbError.ToString());

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            
            string responseText = "";
            string interval = "";
            string sessionFilter = "";
            DateTime? dtEnd = null;
            DateTime? dtStart = null;
            

            if (cmbInterval.SelectedItem != null)
                interval = cmbInterval.SelectedItem.ToString().ToLower();

            if (cmbSession.SelectedItem != null)
            {
                if (cmbSession.SelectedItem.ToString() == "Include Pre/After Market")
                    sessionFilter = "all";
                else
                    sessionFilter = "open";
            }

            if (dateTimeEnd.Value.CompareTo(SqlDateTime.MinValue.Value) > 0)
                dtEnd = dateTimeEnd.Value;

            if (dateTimeStart.Value.CompareTo(SqlDateTime.MinValue.Value) > 0)
                dtStart = dateTimeStart.Value;

            if (ApiCall.CompareTo("Market/Get Historical Pricing") == 0)
            {
                var request = new GetHistoricalPricingRequest(txtSymbol.Text);
                request.Interval = interval;
                request.StartDateTime = dtStart;
                request.EndDateTime = dtEnd;
                var response = await ApiGateway.MarketData.GetHistoricalPricing(request);
                responseText = response.RawResponse.Content;
            }
            else if (ApiCall.CompareTo("Market/Get Time And Sales") == 0)
            {
                var request = new GetTimeAndSalesRequest(txtSymbol.Text);
                request.Interval = interval;
                request.SessionFilter = sessionFilter;
                request.StartDateTime = dtStart;
                request.EndDateTime = dtEnd;
                var response = await ApiGateway.MarketData.GetTimeAndSales(request);
                responseText = response.RawResponse.Content;
            }
            
            txtResponse.Text = responseText;

        }
    }
}

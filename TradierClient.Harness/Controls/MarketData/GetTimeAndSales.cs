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

            var request = new GetTimeAndSalesRequest(txtSymbol.Text);

            if (cmbInterval.SelectedItem != null)
                request.Interval = cmbInterval.SelectedItem.ToString().ToLower();

            if (cmbSession.SelectedItem != null)
            {
                if (cmbSession.SelectedItem.ToString() == "Include Pre/After Market")
                    request.SessionFilter = "all";
                else
                    request.SessionFilter = "open";
            }

            if (dateTimeEnd.Value.CompareTo(SqlDateTime.MinValue.Value) > 0)
                request.EndDateTime = dateTimeEnd.Value;

            if (dateTimeStart.Value.CompareTo(SqlDateTime.MinValue.Value) > 0)
                request.StartDateTime = dateTimeStart.Value;

            var response = await ApiGateway.MarketData.GetTimeAndSales(request);
            txtResponse.Text = response.RawResponse.Content;

        }
    }
}

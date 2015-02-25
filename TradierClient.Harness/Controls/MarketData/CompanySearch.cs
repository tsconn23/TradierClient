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
    public partial class CompanySearch : BaseHarnessControl
    {
        public CompanySearch()
        {
            InitializeComponent();
        }

        public CompanySearch(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string msgValidation = "";

            if (msgValidation.Length > 0)
                MessageBox.Show(msgValidation);

            if(txtKeyword.Text.Length == 0)
            {
                isValid = false;
                msgValidation = "Please provide a search term.\r\n";
            }

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var request = new GetCompanySearchRequest(txtKeyword.Text, cbIncludeIndexes.Checked);
            var response = await ApiGateway.MarketData.GetCompanySearch(request);
            txtResponse.Text = response.RawResponse.Content;
        }
    }
}

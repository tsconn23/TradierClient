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
    public partial class SymbolLookup : BaseHarnessControl
    {
        public SymbolLookup()
        {
            InitializeComponent();
        }

        public SymbolLookup(Gateway apiGateway, string apiCall)
            : base(apiGateway, apiCall)
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string msgValidation = "";

            if(txtSymbol.Text.Length == 0)
            {
                isValid = false;
                msgValidation = "Symbol is required.\r\n";
            }

            if (msgValidation.Length > 0)
                MessageBox.Show(msgValidation);

            return isValid;
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var sbTypes = new StringBuilder();
            if(chkListSecurityTypes.SelectedIndices.Count > 0)
            {
                foreach(var item in chkListSecurityTypes.SelectedItems)
                {
                    if (sbTypes.Length > 0) sbTypes.Append(",");
                    sbTypes.Append(item.ToString());
                }
            }

            var request = new GetSymbolLookupRequest(txtSymbol.Text, txtExchanges.Text, sbTypes.ToString());
            var response = await ApiGateway.MarketData.GetSymbolLookup(request);
            txtResponse.Text = response.RawResponse.Content;
        }
    }
}

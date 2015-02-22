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
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            var response = await ApiGateway.MarketData.GetIntradayStatus();
            txtResponse.Text = response.RawResponse.Content;
        }
    }
}

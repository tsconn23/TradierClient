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


namespace TradierClient.Harness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void cmbApiCall_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbApiCall.SelectedIndex > -1)
            {
                if (cmbMessageFormat.SelectedItem == null)
                {
                    MessageBox.Show("Please select desired Message Format.");
                    cmbApiCall.SelectedIndex = -1;
                    return;
                }

                var tradierGateway = InitializeGateway();
                FindControlAndAddToContainer(tradierGateway, cmbApiCall.SelectedItem.ToString());
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

        private void FindControlAndAddToContainer(Gateway gateway, string apiCall)
        {
            pnlControlContainer.Controls.Clear();

            switch (apiCall)
            {
                case "Market/Get Option Chain":
                case "Market/Get Option Strikes":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.GetOptionChain(gateway, apiCall));
                    break;
                case "Market/Get Option Expirations":
                case "Market/Get Quotes":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.GetQuotes(gateway, apiCall));
                    break;
                case "Market/Get Time And Sales":
                case "Market/Get Historical Pricing":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.GetTimeAndSales(gateway, apiCall));
                    break;
                case "Market/Get Intraday Status":
                case "Market/Get Market Calendar":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.GetIntradayStatus(gateway, apiCall));
                    break;
                case "Market/Company Search":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.CompanySearch(gateway, apiCall));
                    break;
                case "Market/Symbol Lookup":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.SymbolLookup(gateway, apiCall));
                    break;
                case "User Data/Get Profile":
                case "User Data/Get Balances":
                case "User Data/Get Positions":
                case "User Data/Get History":
                case "User Data/Get Cost Basis":
                case "User Data/Get Orders":
                    pnlControlContainer.Controls.Add(new Controls.UserData.CommandPanel(gateway, apiCall));
                    break;
            }
        }
    }
}

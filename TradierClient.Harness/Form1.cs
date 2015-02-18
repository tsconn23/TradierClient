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
                case "Market/GetQuotes":
                    pnlControlContainer.Controls.Add(new Controls.MarketData.GetQuotes(gateway, apiCall));
                    break;
            }
        }
    }
}

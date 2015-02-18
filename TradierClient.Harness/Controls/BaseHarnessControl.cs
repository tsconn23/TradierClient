using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradierClient;

namespace TradierClient.Harness.Controls
{
    public class BaseHarnessControl : UserControl
    {
        public BaseHarnessControl() { }

        public BaseHarnessControl(Gateway apiGateway,string apiCall)
        {
            ApiGateway = apiGateway;
            ApiCall = apiCall;
        }

        public Gateway ApiGateway { get; set; }

        public string ApiCall { get; set; }
        
    }
}

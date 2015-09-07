using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradierClient;

namespace TradierClient.Exchange.Responses.DTO
{
    public class MarketQuote
    {
        public string Symbol { get; set; }

        public string Description { get; set; }

        private InstrumentType _instrumentType = InstrumentType.Undefined;
        public InstrumentType InstrumentType
        {
            get { return _instrumentType; }
        }

        public void SetInstrumentType(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                switch (type.ToLower())
                {
                    case "stock":
                        _instrumentType = InstrumentType.Stock;
                        break;
                    case "etf":
                        _instrumentType = InstrumentType.ETF;
                        break;
                    case "index":
                        _instrumentType = InstrumentType.Index;
                        break;
                }
            }
        }

        public double LastPrice { get; set; }

        public double Change { get; set; }

        public double ChangePercentage { get; set; }

        public long Volume { get; set; }

        public long AverageVolume { get; set; }

        public double OpenPrice { get; set; }

        public double HighPrice { get; set; }

        public double LowPrice { get; set; }

        public double ClosePrice { get; set; }
    }
}

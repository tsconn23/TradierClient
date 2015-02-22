using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetHistoricalPricingRequest
    {
        public GetHistoricalPricingRequest(string symbol)
        {
            _symbol = symbol;
        }

        public GetHistoricalPricingRequest(string symbol, string interval)
        {
            _symbol = symbol;
            _interval = interval;
        }

        public GetHistoricalPricingRequest(string symbol, string interval, DateTime? dtStart, DateTime? dtEnd)
        {
            _symbol = symbol;
            _interval = interval;
            _dtStart = dtStart;
            _dtEnd = dtEnd;
        }

        private string _symbol;
        public string Symbol
        {
            get { return _symbol ?? string.Empty; }
        }

        private string _interval;
        public string Interval
        {
            get { return _interval ?? string.Empty; }
            set { _interval = value; }
        }

        private DateTime? _dtStart;
        public DateTime? StartDateTime
        {
            get { return _dtStart; }
            set { _dtStart = value; }
        }

        private DateTime? _dtEnd;
        public DateTime? EndDateTime
        {
            get { return _dtEnd; }
            set { _dtEnd = value; }
        }
    }
}

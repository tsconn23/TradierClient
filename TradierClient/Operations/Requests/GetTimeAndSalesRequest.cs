using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetTimeAndSalesRequest
    {
        public GetTimeAndSalesRequest(string symbol)
        {
            _symbol = symbol;
        }

        public GetTimeAndSalesRequest(string symbol, string interval)
        {
            _symbol = symbol;
            _interval = interval;
        }

        public GetTimeAndSalesRequest(string symbol, string interval, string sessionFilter)
        {
            _symbol = symbol;
            _interval = interval;
            _sessionFilter = sessionFilter;
        }

        public GetTimeAndSalesRequest(string symbol, string interval, string sessionFilter, DateTime? dtStart, DateTime? dtEnd)
        {
            _symbol = symbol;
            _interval = interval;
            _sessionFilter = sessionFilter;
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

        private string _sessionFilter;
        public string SessionFilter
        {
            get { return _sessionFilter ?? string.Empty; }
            set { _sessionFilter = value; }
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



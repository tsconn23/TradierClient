using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Responses.DTO
{
    public class MarketDay
    {
        public DateTime Date { get; set; }
        public bool IsOpen { get; set; }
        public string Description { get; set; }
        public TimeInterval PreMarket { get; set; }
        public TimeInterval Open { get; set; }
        public TimeInterval PostMarket { get; set; }
    }

    public struct TimeInterval
    {
        private string _start, _end;
        public TimeInterval(string start, string end)
        {
            _start = start;
            _end = end;
        }

        public string Start
        {
            get
            {
                return _start;
            }
        }

        public string End
        {
            get
            {
                return _end;
            }
        }
    }
}

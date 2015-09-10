using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TradierClient.Exchange.Responses
{
    public class GetMarketCalendarResponse:BaseResponse
    {
        public GetMarketCalendarResponse(RawResponse raw) : base(raw)
        {
            _days = Parse(raw.Content);
        }

        private List<DTO.MarketDay> _days;
        public List<DTO.MarketDay> Days
        {
            get
            {
                return _days ?? (_days = new List<DTO.MarketDay>());
            }
        }

        private List<DTO.MarketDay> Parse(string responseContent)
        {
            var days = new List<DTO.MarketDay>();

            JObject json = JObject.Parse(responseContent);
            JToken outer = json["calendar"]["days"].FirstOrDefault();
            if (outer != null)
            {
                JArray array = null;
                if (((JProperty)outer).Value is JArray)
                    array = (JArray)((JProperty)outer).Value;
                else
                    throw new ArgumentOutOfRangeException("Expected array not found at json[\"calendar\"][\"days\"].Children()");

                for (int i = 0; i < array.Count; i++)
                {
                    var day = new DTO.MarketDay();
                    foreach (JToken token in array[i].Children())
                    {
                        var property = (JProperty)token;
                        switch (property.Name)
                        {
                            case "date":
                                day.Date = DateTime.Parse((string)property.Value);
                                break;
                            case "status":
                                if (String.Compare((string)property.Value, "open", true) == 0)
                                    day.IsOpen = true;
                                break;
                            case "description":
                                day.Description = (string)property.Value;
                                break;
                            case "premarket":
                                day.PreMarket = ParseInterval(token);
                                break;
                            case "open":
                                day.Open = ParseInterval(token);
                                break;
                            case "postmarket":
                                day.PostMarket = ParseInterval(token);
                                break;
                        }
                    }
                    days.Add(day);
                }
            }
            else
                throw new NullReferenceException("No child found at json[\"calendar\"][\"days\"]");

            return days;
        }

        private static DTO.TimeInterval ParseInterval(JToken token)
        {
            string start = "";
            string end = "";
            foreach (JToken child in token.First().Children())
            {
                var childProperty = (JProperty)child;
                var value = (string)childProperty.Value;
                if (String.Compare(childProperty.Name, "start", true) == 0)
                {
                    start = value;
                }
                else if (String.Compare(childProperty.Name, "end", true) == 0)
                {
                    end = value;
                }
            }
            return new DTO.TimeInterval(start, end);
        }
    }
}

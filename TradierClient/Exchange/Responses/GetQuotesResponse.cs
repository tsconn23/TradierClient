using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TradierClient.Exchange.Interfaces;

namespace TradierClient.Exchange.Responses
{
    public class GetQuotesResponse : BaseResponse
    {
        public GetQuotesResponse(RawResponse raw, MessageFormatEnum format) : base(raw)
        {
            this.MessageFormat = format;
            if(this.MessageFormat == MessageFormatEnum.JSON)
                _quotes = MapToQuotes(raw.Content);
        }

        private List<DTO.MarketQuote> _quotes;
        public List<DTO.MarketQuote> Quotes
        {
            get
            {
                return _quotes ?? (_quotes = new List<DTO.MarketQuote>());
            }
        }

        private List<DTO.MarketQuote> MapToQuotes(string responseContent)
        {
            var quotes = new List<DTO.MarketQuote>();
            JObject json = JObject.Parse(responseContent);
            foreach (JToken outer in json["quotes"].Children()) //Will probably only ever have one child.
            {
                //This array conversion has to happen because of the way Newtsonsoft sees the value of Children()
                //when there's only one result returned versus manny. In the case of one result, there's an object
                //where an array would otherwise be and it doesn't seem to be able to infer that object as a single
                //member of an array. Therefore, I'm being explicit here.
                JArray array = null;
                if (((JProperty)outer).Value is JArray)
                    array = (JArray)((JProperty)outer).Value;
                else
                {
                    array = new JArray(((JProperty)outer).Value);
                }

                for (int i = 0; i < array.Count; i++)
                {
                    var quote = new DTO.MarketQuote();
                    foreach (JToken token in array[i].Children())
                    {
                        double dblDummy = 0.0;
                        long lngDummy = 0;
                        var property = (JProperty)token;
                        var value = (string)property.Value;
                        switch (property.Name)
                        {
                            case "symbol":
                                quote.Symbol = value;
                                break;
                            case "description":
                                quote.Description = value;
                                break;
                            case "type":
                                quote.SetInstrumentType(value);
                                break;
                            case "last":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.LastPrice = dblDummy;
                                break;
                            case "change":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.Change = dblDummy;
                                break;
                            case "change_percentage":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.ChangePercentage = dblDummy;
                                break;
                            case "volume":
                                if (Int64.TryParse(value, out lngDummy))
                                    quote.Volume = lngDummy;
                                break;
                            case "average_volume":
                                if (Int64.TryParse(value, out lngDummy))
                                    quote.AverageVolume = lngDummy;
                                break;
                            case "open":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.OpenPrice = dblDummy;
                                break;
                            case "high":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.HighPrice = dblDummy;
                                break;
                            case "low":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.LowPrice = dblDummy;
                                break;
                            case "close":
                                if (Double.TryParse(value, out dblDummy))
                                    quote.ClosePrice = dblDummy;
                                break;
                        }
                    }
                    quotes.Add(quote);
                }
            }
            return quotes;
        }
    }
}

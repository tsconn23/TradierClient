using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TradierClient.Exchange.Interfaces
{
    internal interface ITradierCommand
    {
        string AccessToken { get; }

        HttpMethod HttpMethod { get; }

        MessageFormatEnum MessageFormat { get; set; }

        Dictionary<string, string> Parameters { get;  }

        string UriStem { get; }

        RawResponse RawResponse { get; set; } 
    }
}

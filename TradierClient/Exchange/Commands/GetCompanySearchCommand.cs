using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Exchange.Commands
{
    internal class GetCompanySearchCommand : BaseGetCommand
    {
        public GetCompanySearchCommand(string keyword, bool? includeIndexes, string accessToken)
        {
            AddParameter("q", keyword ?? string.Empty);
            if (includeIndexes.HasValue)
                AddParameter("indexes", includeIndexes.Value.ToString().ToLower());

            AccessToken = accessToken;
        }

        public override string UriStem
        {
            get { return "v1/markets/search"; }
        }
    }
}

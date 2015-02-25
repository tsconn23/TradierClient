using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradierClient.Operations.Requests
{
    public class GetCompanySearchRequest
    {
        public GetCompanySearchRequest(string keyword, bool? includeIndexes)
        {
            _keyword = keyword;
            IncludeIndexes = includeIndexes;
        }

        private string _keyword = string.Empty;
        public string Keyword
        {
            get
            {
                return _keyword ?? string.Empty;
            }
            set
            {
                _keyword = value;
            }
        }

        public bool? IncludeIndexes { get; private set; }
    }
}

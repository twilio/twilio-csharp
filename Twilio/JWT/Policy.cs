using System.Collections.Generic;

namespace Twilio.JWT
{
    public class Policy
    {
        public static readonly Dictionary<string, bool> Required = new Dictionary<string, bool> { { "required", true } };
        public static readonly Dictionary<string, bool> Optional = new Dictionary<string, bool> { { "required", false } };

        private readonly string _url;
        private readonly string _method;
        private readonly bool _allowed;
        private readonly Dictionary<string, Dictionary<string, bool>> _queryFilter;
        private readonly Dictionary<string, Dictionary<string, bool>> _postFilter;

        public Policy(
            string url,
            string method,
            Dictionary<string, Dictionary<string, bool>> queryFilter=null,
            Dictionary<string, Dictionary<string, bool>> postFilter=null,
            bool allowed=true
        )
        {
            _url = url;
            _method = method;
            _allowed = allowed;
            _queryFilter = queryFilter ?? new Dictionary<string, Dictionary<string, bool>>();
            _postFilter = postFilter ?? new Dictionary<string, Dictionary<string, bool>>();
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object> {
                { "url", _url },
                { "method", _method },
                { "query_filter", _queryFilter },
                { "post_filter", _postFilter },
                { "allow", _allowed }
            };
        }
    }
}

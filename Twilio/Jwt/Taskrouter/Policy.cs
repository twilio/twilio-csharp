using System.Collections.Generic;
using Twilio.Http;

namespace Twilio.Jwt.Taskrouter
{
    public class Policy
    {
		public sealed class FilterRequirement : Dictionary<string, bool>
		{
			private FilterRequirement(bool v) 
			{
				Add("required", v);
			}

			public static readonly FilterRequirement Required = new FilterRequirement(true);
			public static readonly FilterRequirement Optional = new FilterRequirement(false);
		}

        private readonly string _url;
		private readonly bool _allowed;
        private readonly HttpMethod _method;
		private readonly Dictionary<string, FilterRequirement> _queryFilter;
		private readonly Dictionary<string, FilterRequirement> _postFilter;

        public Policy(
            string url,
			HttpMethod method,
			Dictionary<string, FilterRequirement> queryFilter=null,
			Dictionary<string, FilterRequirement> postFilter=null,
            bool allowed=true
        )
        {
            _url = url;
			_allowed = allowed;
            _method = method;
			_queryFilter = queryFilter ?? new Dictionary<string, FilterRequirement>();
			_postFilter = postFilter ?? new Dictionary<string, FilterRequirement>();
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object> {
                { "url", _url },
				{ "method", _method.ToString() },
                { "query_filter", _queryFilter },
                { "post_filter", _postFilter },
                { "allow", _allowed }
            };
        }
    }
}

using System.Collections.Generic;
using Twilio.Http;

namespace Twilio.Jwt.Taskrouter
{
    /// <summary>
    /// Policy for a TaskRouter token
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Filter requirements for a TaskRouter policy
        /// </summary>
        public sealed class FilterRequirement : Dictionary<string, bool>
        {
            private FilterRequirement(bool v) 
            {
                Add("required", v);
            }

            /// <summary>
            /// Parameter is required
            /// </summary>
            public static readonly FilterRequirement Required = new FilterRequirement(true);

            /// <summary>
            /// Parameter is optional
            /// </summary>
            public static readonly FilterRequirement Optional = new FilterRequirement(false);
        }

        private readonly string _url;
        private readonly bool _allowed;
        private readonly HttpMethod _method;
        private readonly Dictionary<string, FilterRequirement> _queryFilter;
        private readonly Dictionary<string, FilterRequirement> _postFilter;

        /// <summary>
        /// Create a new Policy
        /// </summary>
        /// <param name="url">TaskRouter URL</param>
        /// <param name="method">HTTP method</param>
        /// <param name="queryFilter">Query param filters</param>
        /// <param name="postFilter">POST data filters</param>
        /// <param name="allowed">Allow the JWT to access</param>
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

        /// <summary>
        /// Returns dictionary representation of the Policy
        /// </summary>
        /// <returns>Dictionary representation of the Policy</returns>
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

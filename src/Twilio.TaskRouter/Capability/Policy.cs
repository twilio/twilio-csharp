using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.TaskRouter
{
    public class Policy
    {
        public static readonly Dictionary<string, bool> required = new Dictionary<string, bool> { { "required", true } };
        public static readonly Dictionary<string, bool> optional = new Dictionary<string, bool> { { "required", false } };

        private string url;
        private string method;
        public Dictionary<string, Dictionary<string, bool>> queryFilter { get; set; }
        public Dictionary<string, Dictionary<string, bool>> postFilter { get; set; }
        private bool allowed;

        public Policy(string url, string method, Dictionary<string, Dictionary<string, bool>> queryFilter,
            Dictionary<string, Dictionary<string, bool>> postFilter, bool allowed)
        {
            this.url = url;
            this.method = method;
            this.allowed = allowed;
            this.queryFilter = queryFilter;
            this.postFilter = postFilter;
        }

        public Policy(string url, string method, bool allowed)
        {
            this.url = url;
            this.method = method;
            this.allowed = allowed;
            this.queryFilter = new Dictionary<string, Dictionary<string, bool>>();
            this.postFilter = new Dictionary<string, Dictionary<string, bool>>();
        }

        public Policy(string url, string method) : this(url, method, true) { }

        public Dictionary<string, Object> ToDict()
        {
            return new Dictionary<string, object> {
                { "url", url },
                { "method", method },
                { "query_filter", queryFilter },
                { "post_filter", postFilter },
                { "allow", allowed }
            };
        }
    }
}

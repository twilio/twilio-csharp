using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWT;

namespace Twilio.TaskRouter
{
    public class CapabilityAPI
    {
        protected string accountSid;
        protected string authToken;
        protected List<Policy> policies;
        private string version;
        private string friendlyName;

        public CapabilityAPI (string accountSid, string authToken, string version, string friendlyName)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.version = version;
            this.friendlyName = friendlyName;
            this.policies = new List<Policy>();
        }

        public void AddPolicy(string url, string method, bool allowed,
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {
            if (queryFilter == null) {
                queryFilter = new Dictionary<string, Dictionary<string, bool>>();
            }
            if (postFilter == null) {
                postFilter = new Dictionary<string, Dictionary<string, bool>> ();
            }

            var policy = new Policy (url, method, queryFilter, postFilter, allowed);
            policies.Add(policy);
        }

        public void Allow(string url, string method, 
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {

            this.AddPolicy(url, method, true, queryFilter, postFilter);
        }

        public void Deny(string url, string method, 
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {

            this.AddPolicy(url, method, false, queryFilter, postFilter);
        }


        public string GenerateToken()
        {
            return GenerateToken(3600);
        }

        public string GenerateToken(int ttlSeconds, 
            Dictionary<string, string> extraAttributes = null)
        {
            var ps = policies.Select(p => p.ToDict()).ToArray();
            var payload = new Dictionary<string, object> ();
            payload.Add("iss", accountSid);
            payload.Add("exp", ConvertToUnixTimestamp (DateTime.UtcNow.AddSeconds (ttlSeconds)));
            payload.Add("version", this.version);
            payload.Add("friendly_name", this.friendlyName);
            payload.Add("policies", ps);
            foreach (KeyValuePair<string, string> entry in extraAttributes) {
                payload.Add(entry.Key, entry.Value);
            }

            return JsonWebToken.Encode(payload, authToken, JwtHashAlgorithm.HS256);
        }

        static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}


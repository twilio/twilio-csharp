using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.Trunking.Model;

namespace Twilio.Trunking
{
    public partial class TrunkingClient
    {
        /// <summary>
        /// Gets an OriginationUrl by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="originationUrlSid">OriginationUrl sid.</param>
        public virtual OriginationUrl GetOriginationUrl(string trunkSid, string originationUrlSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("OriginationUrlSid", originationUrlSid);

            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddUrlSegment("OriginationUrlSid", originationUrlSid);

            return Execute<OriginationUrl>(request);
        }

        /// <summary>
        /// Lists the originationUrls.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
		public virtual OriginationUrlResult ListOriginationUrls(string trunkSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}/OriginationUrls";
            request.AddUrlSegment("TrunkSid", trunkSid);
            return Execute<OriginationUrlResult>(request);
        }

        /// <summary>
        /// Create an OriginationUrl.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
    		/// <param name="friendlyName">A human readable descriptive text,
        /// up to 64 characters long.</param>
    		/// <param name="sipUrl">The SIP address you want Twilio to route your
        /// Origination calls to. This must be a sip: schema.</param>
    		/// <param name="priority">Priority ranks the importance of the URI.
        /// Values range from 0 to 65535, where the lowest number represents
        /// the highest importance. Defaults to 10.</param>
    		/// <param name="weight">Weight is used to determine the share of load
        /// when more than one URI has the same priority.
        /// Its values range from 1 to 65535. The higher the value, the more
        /// load a URI is given. Defaults to 10.</param>
    		/// <param name="enabled">A boolean value indicating whether the URL is
        /// enabled or disabled. Defaults to true.</param>
        public virtual OriginationUrl CreateOriginationUrl(string trunkSid,
          string friendlyName, string sipUrl, int priority,
          int weight, bool enabled) {
    			var request = new RestRequest(Method.POST);
    			request.Resource = "Trunks/{TrunkSid}/OriginationUrls";

          request.AddUrlSegment("TrunkSid", trunkSid);
    			request.AddParameter("FriendlyName", friendlyName);
    			request.AddParameter("SipUrl", sipUrl);
    			request.AddParameter("Priority", priority);
    			request.AddParameter("Weight", weight);
    			request.AddParameter("Enabled", enabled);

    			return Execute<OriginationUrl>(request);
        }

        /// <summary>
        /// Update an OriginationUrl.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="originationUrlSid">OriginationUrl sid.</param>
    		/// <param name="friendlyName">A human readable descriptive text,
        /// up to 64 characters long.</param>
    		/// <param name="sipUrl">The SIP address you want Twilio to route your
        /// Origination calls to. This must be a sip: schema.</param>
    		/// <param name="priority">Priority ranks the importance of the URI.
        /// Values range from 0 to 65535, where the lowest number represents
        /// the highest importance. Defaults to 10.</param>
    		/// <param name="weight">Weight is used to determine the share of load
        /// when more than one URI has the same priority.
        /// Its values range from 1 to 65535. The higher the value, the more
        /// load a URI is given. Defaults to 10.</param>
    		/// <param name="enabled">A boolean value indicating whether the URL is
        /// enabled or disabled. Defaults to true.</param>
        public virtual OriginationUrl UpdateOriginationUrl(string trunkSid, string originationUrlSid,
          string friendlyName, string sipUrl, int priority,
          int weight, bool enabled) {
    			var request = new RestRequest(Method.POST);
    			request.Resource = "Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}";

          request.AddUrlSegment("TrunkSid", trunkSid);
          request.AddUrlSegment("OriginationUrlSid", originationUrlSid);
    			request.AddParameter("FriendlyName", friendlyName);
    			request.AddParameter("SipUrl", sipUrl);
    			request.AddParameter("Priority", priority);
    			request.AddParameter("Weight", weight);
    			request.AddParameter("Enabled", enabled);

    			return Execute<OriginationUrl>(request);
        }

        /// <summary>
        /// Delete an OriginationUrl.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        /// <param name="originationUrlSid">OriginationUrl sid.</param>
        public virtual DeleteStatus DeleteOriginationUrl(string trunkSid, string originationUrlSid)
        {
            Require.Argument("TrunkSid", trunkSid);
            Require.Argument("OriginationUrlSid", originationUrlSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}/OriginationUrls/{OriginationUrlSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);
            request.AddParameter("OriginationUrlSid", originationUrlSid, ParameterType.UrlSegment);
            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

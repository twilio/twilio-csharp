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
        /// Gets a trunk by its unique ID.
        /// </summary>
        /// <param name="trunkSid">Trunk sid.</param>
        public virtual void GetTrunk(string trunkSid, Action<Trunk> callback)
        {
            Require.Argument("TrunkSid", trunkSid);

            var request = new RestRequest();
            request.Resource = "Trunks/{TrunkSid}";

            request.AddUrlSegment("TrunkSid", trunkSid);

            ExecuteAsync<Trunk>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Lists the trunks.
        /// </summary>
		public virtual void ListTrunks(Action<TrunkResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Trunks";
            ExecuteAsync<TrunkResult>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Create a SIP Trunk.
        /// </summary>
    		/// <param name="friendlyName">The friendly name that identifies this SIP Trunk.</param>
    		/// <param name="domainName">The domain name for this SIP trunk.</param>
    		/// <param name="disasterRecoveryMethod">The HTTP method to use when sending requests to the DisasterRecoveryUrl.</param>
    		/// <param name="disasterRecoveryUrl">The url for the fallback TwiML in the event of a call failure.</param>
    		/// <param name="recording">The recording settings for call to/from this SIP trunk.</param>
    		/// <param name="secure">Whether SRTP is used for media and TLS signaling.</param>
        public virtual void CreateTrunk(string friendlyName, string domainName,
          string disasterRecoveryUrl, string disasterRecoveryMethod,
          Dictionary<string, string> recording, bool secure, Action<Trunk> callback) {
    			var request = new RestRequest(Method.POST);
    			request.Resource = "Trunks";

    			request.AddParameter("FriendlyName", friendlyName);
    			request.AddParameter("DomainName", domainName);
    			request.AddParameter("DisasterRecoveryUrl", disasterRecoveryUrl);
    			request.AddParameter("DisasterRecoveryMethod", disasterRecoveryMethod);
    			request.AddParameter("Recording", recording);
    			request.AddParameter("Secure", secure);

          ExecuteAsync<Trunk>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Update a SIP Trunk.
        /// </summary>
    		/// <param name="trunkSid">A sid that identifies a SIP Trunk.</param>
    		/// <param name="friendlyName">The friendly name that identifies this SIP Trunk.</param>
    		/// <param name="domainName">The domain name for this SIP trunk.</param>
    		/// <param name="disasterRecoveryMethod">The HTTP method to use when sending requests to the DisasterRecoveryUrl.</param>
    		/// <param name="disasterRecoveryUrl">The url for the fallback TwiML in the event of a call failure.</param>
    		/// <param name="recording">The recording settings for call to/from this SIP trunk.</param>
    		/// <param name="secure">Whether SRTP is used for media and TLS signaling.</param>
        public virtual void UpdateTrunk(string trunkSid, string friendlyName, string domainName,
          string disasterRecoveryUrl, string disasterRecoveryMethod,
          Dictionary<string, string> recording, bool secure, Action<Trunk> callback) {
    			var request = new RestRequest(Method.POST);
    			request.Resource = "Trunks/{TrunkSid}";

          request.AddUrlSegment("TrunkSid", trunkSid);
    			request.AddParameter("FriendlyName", friendlyName);
    			request.AddParameter("DomainName", domainName);
    			request.AddParameter("DisasterRecoveryUrl", disasterRecoveryUrl);
    			request.AddParameter("DisasterRecoveryMethod", disasterRecoveryMethod);
    			request.AddParameter("Recording", recording);
    			request.AddParameter("Secure", secure);

          ExecuteAsync<Trunk>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Delete a SIP Trunk.
        /// </summary>
        public virtual void DeleteTrunk(string trunkSid, Action<DeleteStatus> callback)
        {
            Require.Argument("TrunkSid", trunkSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Trunks/{TrunkSid}";

            request.AddParameter("TrunkSid", trunkSid, ParameterType.UrlSegment);
      			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }
    }
}

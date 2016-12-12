using System.Collections.Generic;

namespace Twilio.JWT
{
    /// <summary>
    /// Grant to expose Twilio Voice
    /// </summary>
    public class VoiceGrant : IGrant
    {
        public string OutgoingApplicationSid { get; set; }
        public Dictionary<string, string> OutgoingApplicationParams { get; set; }
        public string PushCredentialSid { get; set; }
        public string EndpointId { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>the grant key</returns>
        public string GetGrantKey()
        {
            return "voice";
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>the grant payload</returns>
        public object GetPayload()
        {
            var payload = new Dictionary<string, object>();
            if (OutgoingApplicationSid != null) 
			{
                var outgoing = new Dictionary<string, object> {{"application_sid", OutgoingApplicationSid}};
                if (OutgoingApplicationParams != null) 
				{
                    outgoing.Add("params", OutgoingApplicationParams) ;
                }

                payload.Add("outgoing", outgoing);
            }

            if (PushCredentialSid != null) 
			{
                payload.Add("push_credential_sid", PushCredentialSid);
            }

            if (EndpointId != null) 
			{
                payload.Add("endpoint_id", EndpointId);
            }

            return payload;
        }
    }
}

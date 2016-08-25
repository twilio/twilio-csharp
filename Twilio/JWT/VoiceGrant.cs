using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.JWT
{
    public class VoiceGrant : IGrant
    {
        public string OutgoingApplicationSid { get; set; }
        public Dictionary<string, string> OutgoingApplicationParams { get; set; }
        public string PushCredentialSid { get; set; }
        public string EndpointId { get; set; }        


        public string GetGrantKey()
        {
            return "voice";
        }

        public object GetPayload()
        {
            var payload = new Dictionary<string, object>();
            if (this.OutgoingApplicationSid != null) {
                var outgoing = new Dictionary<string, object>();
                outgoing.Add("application_sid", this.OutgoingApplicationSid);

                if (this.OutgoingApplicationParams != null) {
                    outgoing.Add("params", this.OutgoingApplicationParams) ;                   
                }

                payload.Add("outgoing", outgoing);
            }

            if (this.PushCredentialSid != null) {
                payload.Add("push_credential_sid", this.PushCredentialSid);
            }

            if (this.EndpointId != null) {
                payload.Add("endpoint_id", this.EndpointId);
            }

            return payload;
        }
    }
}

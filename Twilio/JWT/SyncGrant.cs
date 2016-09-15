using System.Collections.Generic;

namespace Twilio.JWT
{
    public class SyncGrant : IGrant
    {
        public string ServiceSid { get; set; }
        public string EndpointId { get; set; }

        public string GetGrantKey()
        {
            return "data_sync";
        }

        public object GetPayload()
        {
            var payload = new Dictionary<string, string>();

            if (this.ServiceSid != null) {
                payload.Add("service_sid", this.ServiceSid);
            }

            if (this.ServiceSid != null) {
                payload.Add("endpoint_id", this.EndpointId);
            }

            return payload;
        }
    }
}

using System.Collections.Generic;

namespace Twilio.JWT
{
    /// <summary>
    /// Grant for Twilio Sync
    /// </summary>
    public class SyncGrant : IGrant
    {
        public string ServiceSid { get; set; }
        public string EndpointId { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>the grant key</returns>
        public string GetGrantKey()
        {
            return "data_sync";
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>the grant payload</returns>
        public object GetPayload()
        {
            var payload = new Dictionary<string, string>();

            if (ServiceSid != null) {
                payload.Add("service_sid", ServiceSid);
            }

            if (EndpointId != null) {
                payload.Add("endpoint_id", EndpointId);
            }

            return payload;
        }
    }
}

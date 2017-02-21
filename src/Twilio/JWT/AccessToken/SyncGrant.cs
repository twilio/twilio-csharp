using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant for Twilio Sync
    /// </summary>
    public class SyncGrant : IGrant
    {
        /// <summary>
        /// Sync service SID
        /// </summary>
        public string ServiceSid { get; set; }
        
        /// <summary>
        /// Endpoint ID
        /// </summary>
        public string EndpointId { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>the grant key</returns>
        public string Key
        {
            get
            {
                return "data_sync";
            }
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>the grant payload</returns>
        public object Payload
        {
            get
            {
                var payload = new Dictionary<string, string>();

                if (ServiceSid != null)
                {
                    payload.Add("service_sid", ServiceSid);
                }

                if (EndpointId != null)
                {
                    payload.Add("endpoint_id", EndpointId);
                }

                return payload;
            }
        }
    }
}

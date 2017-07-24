using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant to use for IP Messaging
    /// </summary>
    [System.Obsolete("IpMessagingGrant is deprecated, use ChatGrant instead")]
    public class IpMessagingGrant : IGrant
    {
        /// <summary>
        /// Service SID
        /// </summary>
        public string ServiceSid { get; set; }
        
        /// <summary>
        /// Endpoint ID
        /// </summary>
        public string EndpointId { get; set; }
        
        /// <summary>
        /// Deployment role SID
        /// </summary>
        public string DeploymentRoleSid { get; set; }
        
        /// <summary>
        /// Push credential SID
        /// </summary>
        public string PushCredentialSid { get; set; }

        /// <summary>
        /// Get the grant name
        /// </summary>
        ///
        /// <returns>name of the grant</returns>
        public string Key
        {
            get
            {
                return "ip_messaging";
            }
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>payload of the grant</returns>
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
                if (DeploymentRoleSid != null)
                {
                    payload.Add("deployment_role_sid", DeploymentRoleSid);
                }
                if (PushCredentialSid != null)
                {
                    payload.Add("push_credential_sid", PushCredentialSid);
                }

                return payload;
            }
        }

    }
}

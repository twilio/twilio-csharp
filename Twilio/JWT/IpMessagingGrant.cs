using System.Collections.Generic;

namespace Twilio.JWT
{
    /// <summary>
    /// Grant to use for IP Messaging
    /// </summary>
    public class IpMessagingGrant : IGrant
    {
        public string ServiceSid { get; set; }
        public string EndpointId { get; set; }
        public string DeploymentRoleSid { get; set; }
        public string PushCredentialSid { get; set; }

        /// <summary>
        /// Get the grant name
        /// </summary>
        ///
        /// <returns>name of the grant</returns>
        public string GetGrantKey()
        {
            return "ip_messaging";
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>payload of the grant</returns>
        public object GetPayload()
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

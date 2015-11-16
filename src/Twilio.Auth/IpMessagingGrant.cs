using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Auth
{
    public class IpMessagingGrant : Grant
    {
        string ServiceSid { get; set; }
        string EndpointId { get; set; }
        string DeploymentRoleSid { get; set; }
        string PushCredentialSid { get; set; }

        public string GetGrantKey()
        {
            return "ip_messaging";
        }

        public object GetPayload()
        {
            var payload = new Dictionary<string, string>();
            if (this.ServiceSid != null)
            {
                payload.Add("service_sid", this.ServiceSid);
            }
            if (this.ServiceSid != null)
            {
                payload.Add("endpoint_id", this.EndpointId);
            }
            if (this.ServiceSid != null)
            {
                payload.Add("deployment_role_sid", this.DeploymentRoleSid);
            }
            if (this.ServiceSid != null)
            {
                payload.Add("push_credential_sid", this.PushCredentialSid);
            }

            return payload;
        }

    }
}

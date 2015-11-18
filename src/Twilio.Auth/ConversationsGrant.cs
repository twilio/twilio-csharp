using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Auth
{
    public class ConversationsGrant : IGrant
    {
        public string ConfigurationProfileSid { get; set; }

        public string GetGrantKey()
        {
            return "rtc";
        }

        public object GetPayload()
        {
            var payload = new Dictionary<string, string>();
            if (this.ConfigurationProfileSid != null)
            {
                payload.Add("configuration_profile_sid", this.ConfigurationProfileSid);
            }

            return payload;
        }
    }
}

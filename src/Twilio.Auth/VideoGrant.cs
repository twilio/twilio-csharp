using System.Collections.Generic;


namespace Twilio.Auth
{
    public class VideoGrant : IGrant
    {
        public string ConfigurationProfileSid { get; set; }

        public string GetGrantKey()
        {
            return "video";
        }

        public object GetPayload()
        {
            var payload = new Dictionary<string, object>();
            if (this.ConfigurationProfileSid != null)
            {
                payload.Add("configuration_profile_sid", this.ConfigurationProfileSid);
            }
            return payload;
        }
    }
}

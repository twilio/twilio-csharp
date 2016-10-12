using System.Collections.Generic;

namespace Twilio.JWT
{
    /// <summary>
    /// Grant to use for Twilio Conversations
    /// </summary>
    public class ConversationsGrant : IGrant
    {
        public string ConfigurationProfileSid { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>grant key</returns>
        public string GetGrantKey()
        {
            return "rtc";
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>grant payload</returns>
        public object GetPayload()
        {
            var payload = new Dictionary<string, string>();
            if (ConfigurationProfileSid != null)
            {
                payload.Add("configuration_profile_sid", ConfigurationProfileSid);
            }

            return payload;
        }
    }
}

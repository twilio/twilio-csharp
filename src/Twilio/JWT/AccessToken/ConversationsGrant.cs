using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant to use for Twilio Conversations
    /// </summary>
    [System.Obsolete("ConversationsGrant is deprecated, use VideoGrant instead")]
    public class ConversationsGrant : IGrant
    {
        /// <summary>
        /// Configuration profile SID for the grant
        /// </summary>
        public string ConfigurationProfileSid { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>grant key</returns>
        public string Key
        {
            get
            {
                return "rtc";
            }
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>grant payload</returns>
        public object Payload
        {
            get
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
}

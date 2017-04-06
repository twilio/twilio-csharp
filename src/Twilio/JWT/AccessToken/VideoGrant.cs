using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant to expose Twilio Video
    /// </summary>
    public class VideoGrant : IGrant
    {
        /// <summary>
        /// Configuration profile SID
        /// </summary>
        [System.Obsolete("ConfigurationProfileSid is deprecated, use Room instead")]
        public string ConfigurationProfileSid { get; set; }

        /// <summary>
        /// Roome SID or name
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Get the Video grant key
        /// </summary>
        ///
        /// <returns>the video grant key</returns>
        public string Key
        {
            get
            {
                return "video";
            }
        }

        /// <summary>
        /// Get the video grant payload
        /// </summary>
        ///
        /// <returns>the video grant payload</returns>
        public object Payload
        {
            get
            {
                var payload = new Dictionary<string, object>();
                if (ConfigurationProfileSid != null)
                {
                    payload.Add("configuration_profile_sid", ConfigurationProfileSid);
                }
                if (Room != null)
                {
                    payload.Add("room", Room);
                }

                return payload;
            }
        }
    }
}

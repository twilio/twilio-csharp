using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant to expose Twilio Live
    /// </summary>
    public class PlaybackGrant : IGrant
    {
        /// <summary>
        /// Grant payload
        /// </summary>
        public Dictionary<string, object> Grant { get; set; }

        /// <summary>
        /// Get the playback grant key
        /// </summary>
        ///
        /// <returns>the playback grant key</returns>
        public string Key
        {
            get
            {
                return "player";
            }
        }

        /// <summary>
        /// Get the playback grant payload
        /// </summary>
        ///
        /// <returns>the video grant payload</returns>
        public object Payload
        {
            get
            {
                return Grant;
            }
        }
    }
}

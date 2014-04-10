using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Available options when creating a Twilio Domain via the API. 
    /// </summary>
    public class DomainOptions
    {
        /// <summary>
        /// A human readable descriptive text, up to 64 characters long.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The unique address you reserve on Twilio to which you route your SIP traffic. Domain names can contain letters, digits, and “-”.
        /// </summary>
        public string DomainName { get; set; }
        /// <summary>
        /// The types of authentication you have mapped to your domain. The possible values are “IP_ACL” and “CREDENTIAL_LIST”. If you have both setup for your domain, both will be returned comma delimited. If you do not, have one setup for your domain, it will not be able to receive any traffic.
        /// </summary>
        public string AuthType { get; set; }
        /// <summary>
        /// The URL Twilio will request when this domain receives a call.
        /// </summary>
        public string VoiceUrl { get; set; }
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above Url. Either GET or POST.
        /// </summary>
        public string VoiceMethod { get; set; }
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by VoiceUrl.
        /// </summary>
        public string VoiceFallbackUrl { get; set; }
        /// <summary>
        /// The HTTP method Twilio will use when requesting the VoiceFallbackUrl. Either GET or POST.
        /// </summary>
        public string VoiceFallbackMethod { get; set; }
        /// <summary>
        /// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
        /// </summary>
        public string VoiceStatusCallbackUrl { get; set; }
        /// <summary>
        /// The HTTP method Twilio will use to make requests to the StatusCallback URL. Either GET or POST.
        /// </summary>
        public string VoiceStatusCallbackMethod { get; set; }
    }
}

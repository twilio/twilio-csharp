using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class DomainOptions
    {
        public string FriendlyName { get; set; }
        public string DomainName { get; set; }
        public string AuthType { get; set; }
        public string VoiceUrl { get; set; }
        public string VoiceMethod { get; set; }
        public string VoiceFallbackUrl { get; set; }
        public string VoiceFallbackMethod { get; set; }
        public string VoiceStatusCallbackUrl { get; set; }
        public string VoiceStatusCallbackMethod { get; set; }
    }
}

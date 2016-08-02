using System;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class VoiceResponse
    {
        private XElement response;

        public VoiceResponse()
        {
            response = new XElement("Response");
        }

        
    }
}


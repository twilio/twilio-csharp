using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents the list of countries where Twilio Voice services
    /// are available.
    /// Note that the returned VoiceCountry objects will not have
    /// pricing information populated. To retrieve prices for a specific
    /// country, request it with the <code>GetVoiceCountry</code>
    /// method.
    /// </summary>
    public class VoiceCountryResult : NextGenListBase
    {
        public List<VoiceCountry> Countries { get; set; }
    }
}
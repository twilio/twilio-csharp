using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents the list of countries where Twilio Messaging services
    /// are available.
    /// </summary>
    /// <remarks>
    /// Note that the returned Country objects will not have
    /// pricing information populated. To retrieve prices for a specific
    /// country, request it with the GetMessagingCountry method.
    /// </remarks>
    public class MessagingCountryResult : NextGenListBase
    {
        public List<Country> Countries { get; set; }
    }
}

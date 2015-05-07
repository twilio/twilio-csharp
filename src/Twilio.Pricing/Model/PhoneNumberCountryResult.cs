using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents the list of countries where Twilio Phone Numbers
    /// are available.
    /// Note that the returned PhoneNumberCountry objects will not have
    /// pricing information populated. To retrieve prices for a specific
    /// country, request it with the <code>GetPhoneNumberCountry</code>
    /// method.
    /// </summary>
    public class PhoneNumberCountryResult : NextGenListBase
    {
        /// <summary>
        /// The list of country data.
        /// </summary>
        /// <value>The countries.</value>
        public List<PhoneNumberCountry> Countries { get; set; }
    }
}
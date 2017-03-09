using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    /// <summary>
    /// FetchNumberOptions
    /// </summary>
    public class FetchNumberOptions : IOptions<NumberResource> 
    {
        /// <summary>
        /// The number
        /// </summary>
        public Types.PhoneNumber PathNumber { get; }

        /// <summary>
        /// Construct a new FetchNumberOptions
        /// </summary>
        ///
        /// <param name="pathNumber"> The number </param>
        public FetchNumberOptions(Types.PhoneNumber pathNumber)
        {
            PathNumber = pathNumber;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

}
using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class FetchNumberOptions : IOptions<NumberResource> 
    {
        public Types.PhoneNumber Number { get; }
    
        /// <summary>
        /// Construct a new FetchNumberOptions
        /// </summary>
        ///
        /// <param name="number"> The number </param>
        public FetchNumberOptions(Types.PhoneNumber number)
        {
            Number = number;
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
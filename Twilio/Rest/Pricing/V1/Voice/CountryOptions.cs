using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class ReadCountryOptions : ReadOptions<CountryResource> 
    {
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class FetchCountryOptions : IOptions<CountryResource> 
    {
        /// <summary>
        /// The iso_country
        /// </summary>
        public string IsoCountry { get; }
    
        /// <summary>
        /// Construct a new FetchCountryOptions
        /// </summary>
        ///
        /// <param name="isoCountry"> The iso_country </param>
        public FetchCountryOptions(string isoCountry)
        {
            IsoCountry = isoCountry;
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
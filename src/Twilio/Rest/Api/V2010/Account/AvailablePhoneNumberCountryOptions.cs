using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ReadAvailablePhoneNumberCountryOptions : ReadOptions<AvailablePhoneNumberCountryResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
    
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

    public class FetchAvailablePhoneNumberCountryOptions : IOptions<AvailablePhoneNumberCountryResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The country_code
        /// </summary>
        public string CountryCode { get; }
    
        /// <summary>
        /// Construct a new FetchAvailablePhoneNumberCountryOptions
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        public FetchAvailablePhoneNumberCountryOptions(string countryCode)
        {
            CountryCode = countryCode;
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
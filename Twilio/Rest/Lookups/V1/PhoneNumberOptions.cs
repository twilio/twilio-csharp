using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Lookups.V1 
{

    public class FetchPhoneNumberOptions : IOptions<PhoneNumberResource> 
    {
        public Types.PhoneNumber PhoneNumber { get; }
        public string CountryCode { get; set; }
        public List<string> Type { get; set; }
        public List<string> AddOns { get; set; }
        public Dictionary<string, object> AddOnsData { get; set; }
    
        /// <summary>
        /// Construct a new FetchPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public FetchPhoneNumberOptions(Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("CountryCode", CountryCode));
            }
            
            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            
            if (AddOns != null)
            {
                p.Add(new KeyValuePair<string, string>("AddOns", AddOns.ToString()));
            }
            
            if (AddOnsData != null)
            {
                p.Add(new KeyValuePair<string, string>("AddOnsData", AddOnsData.ToString()));
            }
            
            return p;
        }
    }

}
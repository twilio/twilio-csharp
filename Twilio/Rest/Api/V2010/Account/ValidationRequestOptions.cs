using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CreateValidationRequestOptions : IOptions<ValidationRequestResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber PhoneNumber { get; }
        public string FriendlyName { get; set; }
        public int? CallDelay { get; set; }
        public string Extension { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new CreateValidationRequestOptions
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public CreateValidationRequestOptions(Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (CallDelay != null)
            {
                p.Add(new KeyValuePair<string, string>("CallDelay", CallDelay.ToString()));
            }
            
            if (Extension != null)
            {
                p.Add(new KeyValuePair<string, string>("Extension", Extension));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            
            return p;
        }
    }

}
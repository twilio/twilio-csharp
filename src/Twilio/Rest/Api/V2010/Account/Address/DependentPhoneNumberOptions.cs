using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Address 
{

    /// <summary>
    /// ReadDependentPhoneNumberOptions
    /// </summary>
    public class ReadDependentPhoneNumberOptions : ReadOptions<DependentPhoneNumberResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The address_sid
        /// </summary>
        public string AddressSid { get; }
    
        /// <summary>
        /// Construct a new ReadDependentPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="addressSid"> The address_sid </param>
        public ReadDependentPhoneNumberOptions(string addressSid)
        {
            AddressSid = addressSid;
        }
    
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

}
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
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The address_sid
        /// </summary>
        public string PathAddressSid { get; }

        /// <summary>
        /// Construct a new ReadDependentPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="pathAddressSid"> The address_sid </param>
        public ReadDependentPhoneNumberOptions(string pathAddressSid)
        {
            PathAddressSid = pathAddressSid;
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
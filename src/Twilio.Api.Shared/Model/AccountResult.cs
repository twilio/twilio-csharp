using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class AccountResult : TwilioListBase
    {
        /// <summary>
        /// List of accounts returned by API
        /// </summary>
        public List<Account> Accounts { get; set; }
    }

}

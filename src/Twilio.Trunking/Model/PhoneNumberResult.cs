using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Trunking.Model
{
    public class PhoneNumberResult : NextGenListBase
    {
        /// <summary>
        /// List of PhoneNumbers.
        /// </summary>
        public List<AssociatedPhoneNumber> PhoneNumbers { get; set; }
    }
}

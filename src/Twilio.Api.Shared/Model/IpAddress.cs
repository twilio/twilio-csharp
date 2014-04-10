using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A single IP Address entry in an IpAccessControlList
    /// </summary>
    public class IpAddress : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        
        /// <summary>
        /// A human readable descriptive text for the an IP address, up to 64 characters long
        /// </summary>
        public string FriendlyName { get; set; }
        
        /// <summary>
        /// An IP address in dotted decimal notation from which you want to accept traffic. Any SIP requests from this IP address will be allowed by Twilio. IPv4 only supported today
        /// </summary>
        //[DeserializeAs(Name="IpAddress")]
        public string Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{

    public class Token : TwilioBase
    {

        /// <summary>
        /// The account sid that requested this token.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The username for this token.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The password for this token.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The IceServers for this token.
        /// </summary>
        public List<IceServer> IceServers { get; set; }
        /// <summary>
        /// How long this token is good for in seconds.
        /// </summary>
        public int Ttl { get; set; }
        /// <summary>
        /// The date that this resource was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated, given as GMT 
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}

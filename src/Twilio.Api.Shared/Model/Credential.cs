using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A specific set of SIP Domain Credentials
    /// </summary>
    /// <remarks>Though a password is stored for each username in your list, the password is not returned to protect your password. If you cannot remember your password, you will need to POST to this resource to update it.</remarks>
    public class Credential : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this Credential.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The username that will be passed when authenticating SIP requests.  It can be up to 32 characters long.
        /// </summary>
        public string Username { get; set; }
    }
}

using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messaging Credentials.
    /// </summary>
    public class CredentialResult : NextGenListBase
    {
        /// <summary>
        /// The list of Credentials.
        /// </summary>
        public List<Credential> Credentials { get; set; }
    }
}

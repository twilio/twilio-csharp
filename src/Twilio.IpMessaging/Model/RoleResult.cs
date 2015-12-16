using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messaging Roles.
    /// </summary>
    public class RoleResult : NextGenListBase
    {
        /// <summary>
        /// The list of Roles.
        /// </summary>
        public List<Role> Roles { get; set; }
    }
}

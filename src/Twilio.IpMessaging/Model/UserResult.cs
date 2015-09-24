using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messaging Users.
    /// </summary>
    public class UserResult : NextGenListBase
    {
        /// <summary>
        /// The list of Users.
        /// </summary>
        public List<User> Users { get; set; }
    }
}

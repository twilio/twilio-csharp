using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Members.
    /// </summary>
    public class MemberResult : NextGenListBase
    {
        /// <summary>
        /// The list of Members.
        /// </summary>
        public List<Member> Members { get; set; }
    }
}

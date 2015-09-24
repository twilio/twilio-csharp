using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messages.
    /// </summary>
    public class MessageResult : NextGenListBase
    {
        /// <summary>
        /// The list of Messages.
        /// </summary>
        public List<Message> Messages { get; set; }
    }
}

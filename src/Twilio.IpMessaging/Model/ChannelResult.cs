using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messaging Channels.
    /// </summary>
    public class ChannelResult : NextGenListBase
    {
        /// <summary>
        /// The list of Channels.
        /// </summary>
        public List<Channel> Channels { get; set; }
    }
}

using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents the list of Ip Messaging Services.
    /// </summary>
    public class ServiceResult : NextGenListBase
    {
        /// <summary>
        /// The list of Services.
        /// </summary>
        public List<Service> Services { get; set; }
    }
}

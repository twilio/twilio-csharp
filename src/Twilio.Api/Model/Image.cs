using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class Image : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The date that this resource was created
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The date that the Message was sent
        /// </summary>
        public DateTime DateSent { get; set; }
        /// <summary>
        /// The unique id of the Account that sent this Mqessage.
        /// </summary>
        public string AccountSid { get; set; }

        public string ParentSid { get; set; }

        public string ContentType { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class Key : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A human-readable description of this Key.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The time this Key was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The time this Key was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The secret key. Only returned upon the initial creation of the Key resource; null on subsequent requests.
        /// </summary>
        public string Secret { get; set; }
    }
}

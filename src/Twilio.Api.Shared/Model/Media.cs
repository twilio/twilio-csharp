using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A piece of media, such as an image, associated with a message
    /// </summary>
    public class Media : TwilioBase
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
        /// The unique id of the Account that sent this Message.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// A 34 character string that uniquely identifies the parent message of
        /// this media.
        /// </summary>
        public string ParentSid { get; set; }
        /// <summary>
        /// The content type of the media (usually for jpg or gif extensions)
        /// </summary>
        public string ContentType { get; set; }
    }
}

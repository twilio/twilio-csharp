using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workers represent an entity that is able to perform tasks, such as an agent working in a call center, or a salesperson handling leads.
    /// </summary>
    public class Worker : TwilioBase
    {
        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the activity sid.
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// Gets or sets the available.
        /// </summary>
        public string Available { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// Gets or sets the date status changed.
        /// </summary>
        public DateTime DateStatusChanged { get; set; }
    }
}


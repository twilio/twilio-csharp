using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workers represent an entity that is able to perform tasks, such as an agent working in a call center, or a salesperson handling leads.
    /// </summary>
    public class Worker : TwilioBase
    {
        /// <summary>
        /// The unique ID of the Worker.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A user-friendly name for the Worker.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The ID of the account that owns this Worker.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Activity" /> this Worker
        /// is currently performing.
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// String describing the Worker's current Activity.
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// The ID of the Workspace containing this Worker.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// User-defined JSON object describing this Worker.
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// A dictionary representing the user-defined JSON object describing this Worker.
        /// </summary>
        public Dictionary<string, string> ParseAttributes() {
            return TaskRouterClient.FromJsonToDictionary(Attributes);
        }
        /// <summary>
        /// Whether the worker can be assigned a new <see cref="Twilio.TaskRouter.Task" />.
        /// </summary>
        public string Available { get; set; }
        /// <summary>
        /// The date this Worker was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date this Worker was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The date this Worker's Activity last changed.
        /// </summary>
        public DateTime DateStatusChanged { get; set; }
    }
}


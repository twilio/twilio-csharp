using RestSharp.Deserializers;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Workflows control how tasks will be prioritized and routed into Queues,
    /// and how Tasks should escalate in priority or move across queues over
    /// time. Workflows are described in a simple JSON format.
    /// </summary>
    public class Workflow : TwilioBase
    {
        /// <summary>
        /// The unique ID of the Workflow.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// Human readable description of this Workflow.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The ID of the account that owns this Workflow.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ID of the <see cref="Twilio.TaskRouter.Workspace" /> that
        /// contains this Workflow.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// The URL that will be called whenever a task managed by this
        /// Workflow is assigned to a <see cref="Twilio.TaskRouter.Worker" />.
        /// </summary>
        public string AssignmentCallbackUrl { get; set; }
        /// <summary>
        /// If the request to the AssignmentCallbackUrl fails, the assignment callback will be made to this URL.
        /// </summary>
        public string FallbackAssignmentCallbackUrl { get; set; }
        /// <summary>
        /// The type of the Configuration document.
        /// </summary>
        public string DocumentContentType { get; set; }

        /// <summary>
        /// JSON document configuring the rules for this Workflow.
        /// </summary>
        public string Configuration { set; get; }

        /// <summary>
        /// Returns the current Workflow configuration as a strongly-typed WorkflowConfiguration object
        /// </summary>
        public WorkflowConfiguration WorkflowConfiguration { 
            get 
            {                
                if (!String.IsNullOrEmpty(this.Configuration))
                {
                    return WorkflowConfiguration.Create(this.Configuration);
                }
                return new WorkflowConfiguration();
            }  
        }

        /// <summary>
        /// Determines how long TaskRouter will wait for a confirmation
        /// response from your application after assigning a Task to a worker.
        /// Defaults to 120 seconds.
        /// </summary>
        public string TaskReservationTimeout { set; get; }
        /// <summary>
        /// The date this workflow was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date this workflow was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}


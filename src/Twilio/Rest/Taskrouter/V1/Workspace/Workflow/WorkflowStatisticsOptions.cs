using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow 
{

    /// <summary>
    /// FetchWorkflowStatisticsOptions
    /// </summary>
    public class FetchWorkflowStatisticsOptions : IOptions<WorkflowStatisticsResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The workflow_sid
        /// </summary>
        public string PathWorkflowSid { get; }
        /// <summary>
        /// The minutes
        /// </summary>
        public int? Minutes { get; set; }
        /// <summary>
        /// The start_date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// The end_date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Construct a new FetchWorkflowStatisticsOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkflowSid"> The workflow_sid </param>
        public FetchWorkflowStatisticsOptions(string pathWorkspaceSid, string pathWorkflowSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathWorkflowSid = pathWorkflowSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.Value.ToString()));
            }

            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }

            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }

            return p;
        }
    }

}
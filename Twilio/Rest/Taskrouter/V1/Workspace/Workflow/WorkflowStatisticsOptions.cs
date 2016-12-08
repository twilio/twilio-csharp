using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow 
{

    public class FetchWorkflowStatisticsOptions : IOptions<WorkflowStatisticsResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkflowSid { get; }
        public int? Minutes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    
        /// <summary>
        /// Construct a new FetchWorkflowStatisticsOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        public FetchWorkflowStatisticsOptions(string workspaceSid, string workflowSid)
        {
            WorkspaceSid = workspaceSid;
            WorkflowSid = workflowSid;
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
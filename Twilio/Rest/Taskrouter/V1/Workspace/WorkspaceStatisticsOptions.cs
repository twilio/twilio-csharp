using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchWorkspaceStatisticsOptions : IOptions<WorkspaceStatisticsResource> 
    {
        public string WorkspaceSid { get; }
        public int? Minutes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    
        /// <summary>
        /// Construct a new FetchWorkspaceStatisticsOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public FetchWorkspaceStatisticsOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.ToString()));
            }
            
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.ToString()));
            }
            
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.ToString()));
            }
            
            return p;
        }
    }

}
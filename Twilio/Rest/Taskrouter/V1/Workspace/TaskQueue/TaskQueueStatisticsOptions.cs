using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    public class FetchTaskQueueStatisticsOptions : IOptions<TaskQueueStatisticsResource> 
    {
        public string WorkspaceSid { get; }
        public string TaskQueueSid { get; }
        public DateTime? EndDate { get; set; }
        public int? Minutes { get; set; }
        public DateTime? StartDate { get; set; }
    
        /// <summary>
        /// Construct a new FetchTaskQueueStatisticsOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        public FetchTaskQueueStatisticsOptions(string workspaceSid, string taskQueueSid)
        {
            WorkspaceSid = workspaceSid;
            TaskQueueSid = taskQueueSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd")));
            }
            
            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.Value.ToString()));
            }
            
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd")));
            }
            
            return p;
        }
    }

}
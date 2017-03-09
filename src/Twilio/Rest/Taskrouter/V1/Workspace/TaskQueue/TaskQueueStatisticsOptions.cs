using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    /// <summary>
    /// FetchTaskQueueStatisticsOptions
    /// </summary>
    public class FetchTaskQueueStatisticsOptions : IOptions<TaskQueueStatisticsResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        public string PathTaskQueueSid { get; }
        /// <summary>
        /// The end_date
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// The minutes
        /// </summary>
        public int? Minutes { get; set; }
        /// <summary>
        /// The start_date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Construct a new FetchTaskQueueStatisticsOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathTaskQueueSid"> The task_queue_sid </param>
        public FetchTaskQueueStatisticsOptions(string pathWorkspaceSid, string pathTaskQueueSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathTaskQueueSid = pathTaskQueueSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }

            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.Value.ToString()));
            }

            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }

            return p;
        }
    }

}
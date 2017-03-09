using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    /// <summary>
    /// FetchWorkspaceStatisticsOptions
    /// </summary>
    public class FetchWorkspaceStatisticsOptions : IOptions<WorkspaceStatisticsResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
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
        /// Construct a new FetchWorkspaceStatisticsOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        public FetchWorkspaceStatisticsOptions(string pathWorkspaceSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
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
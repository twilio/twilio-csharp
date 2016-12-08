using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchEventOptions : IOptions<EventResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchEventOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchEventOptions(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class ReadEventOptions : ReadOptions<EventResource> 
    {
        public string WorkspaceSid { get; }
        public DateTime? EndDate { get; set; }
        public string EventType { get; set; }
        public int? Minutes { get; set; }
        public string ReservationSid { get; set; }
        public DateTime? StartDate { get; set; }
        public string TaskQueueSid { get; set; }
        public string TaskSid { get; set; }
        public string WorkerSid { get; set; }
        public string WorkflowSid { get; set; }
    
        /// <summary>
        /// Construct a new ReadEventOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadEventOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd")));
            }
            
            if (EventType != null)
            {
                p.Add(new KeyValuePair<string, string>("EventType", EventType));
            }
            
            if (Minutes != null)
            {
                p.Add(new KeyValuePair<string, string>("Minutes", Minutes.Value.ToString()));
            }
            
            if (ReservationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ReservationSid", ReservationSid.ToString()));
            }
            
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd")));
            }
            
            if (TaskQueueSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueSid", TaskQueueSid.ToString()));
            }
            
            if (TaskSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskSid", TaskSid.ToString()));
            }
            
            if (WorkerSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkerSid", WorkerSid.ToString()));
            }
            
            if (WorkflowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowSid", WorkflowSid.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
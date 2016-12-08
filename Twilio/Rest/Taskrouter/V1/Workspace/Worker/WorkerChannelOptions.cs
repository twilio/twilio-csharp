using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class ReadWorkerChannelOptions : ReadOptions<WorkerChannelResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
    
        /// <summary>
        /// Construct a new ReadWorkerChannelOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        public ReadWorkerChannelOptions(string workspaceSid, string workerSid)
        {
            WorkspaceSid = workspaceSid;
            WorkerSid = workerSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class FetchWorkerChannelOptions : IOptions<WorkerChannelResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchWorkerChannelOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchWorkerChannelOptions(string workspaceSid, string workerSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            WorkerSid = workerSid;
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

    public class UpdateWorkerChannelOptions : IOptions<WorkerChannelResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
        public int? Capacity { get; set; }
        public bool? Available { get; set; }
    
        /// <summary>
        /// Construct a new UpdateWorkerChannelOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateWorkerChannelOptions(string workspaceSid, string workerSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            WorkerSid = workerSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Capacity != null)
            {
                p.Add(new KeyValuePair<string, string>("Capacity", Capacity.Value.ToString()));
            }
            
            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available.Value.ToString()));
            }
            
            return p;
        }
    }

}
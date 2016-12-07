using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class ReadWorkerOptions : ReadOptions<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string ActivityName { get; set; }
        public string ActivitySid { get; set; }
        public string Available { get; set; }
        public string FriendlyName { get; set; }
        public string TargetWorkersExpression { get; set; }
        public string TaskQueueName { get; set; }
        public string TaskQueueSid { get; set; }
    
        /// <summary>
        /// Construct a new ReadWorkerOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadWorkerOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (ActivityName != null)
            {
                p.Add(new KeyValuePair<string, string>("ActivityName", ActivityName));
            }
            
            if (ActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid));
            }
            
            if (Available != null)
            {
                p.Add(new KeyValuePair<string, string>("Available", Available));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (TargetWorkersExpression != null)
            {
                p.Add(new KeyValuePair<string, string>("TargetWorkersExpression", TargetWorkersExpression));
            }
            
            if (TaskQueueName != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueName", TaskQueueName));
            }
            
            if (TaskQueueSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueSid", TaskQueueSid));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class CreateWorkerOptions : IOptions<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string FriendlyName { get; }
        public string ActivitySid { get; set; }
        public string Attributes { get; set; }
    
        /// <summary>
        /// Construct a new CreateWorkerOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateWorkerOptions(string workspaceSid, string friendlyName)
        {
            WorkspaceSid = workspaceSid;
            FriendlyName = friendlyName;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (ActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            return p;
        }
    }

    public class FetchWorkerOptions : IOptions<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchWorkerOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchWorkerOptions(string workspaceSid, string sid)
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

    public class UpdateWorkerOptions : IOptions<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
        public string ActivitySid { get; set; }
        public string Attributes { get; set; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateWorkerOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateWorkerOptions(string workspaceSid, string sid)
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
            if (ActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

    public class DeleteWorkerOptions : IOptions<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteWorkerOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteWorkerOptions(string workspaceSid, string sid)
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

}
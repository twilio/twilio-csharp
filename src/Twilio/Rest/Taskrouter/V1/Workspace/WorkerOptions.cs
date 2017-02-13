using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class ReadWorkerOptions : ReadOptions<WorkerResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The activity_name
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// The activity_sid
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// The available
        /// </summary>
        public string Available { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The target_workers_expression
        /// </summary>
        public string TargetWorkersExpression { get; set; }
        /// <summary>
        /// The task_queue_name
        /// </summary>
        public string TaskQueueName { get; set; }
        /// <summary>
        /// The task_queue_sid
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid.ToString()));
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
                p.Add(new KeyValuePair<string, string>("TaskQueueSid", TaskQueueSid.ToString()));
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The activity_sid
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// The attributes
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid.ToString()));
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The activity_sid
        /// </summary>
        public string ActivitySid { get; set; }
        /// <summary>
        /// The attributes
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("ActivitySid", ActivitySid.ToString()));
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
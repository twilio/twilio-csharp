using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchTaskOptions : IOptions<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchTaskOptions(string workspaceSid, string sid)
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

    public class UpdateTaskOptions : IOptions<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
        public string Attributes { get; set; }
        public TaskResource.StatusEnum AssignmentStatus { get; set; }
        public string Reason { get; set; }
        public int? Priority { get; set; }
        public string TaskChannel { get; set; }
    
        /// <summary>
        /// Construct a new UpdateTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateTaskOptions(string workspaceSid, string sid)
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
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            if (AssignmentStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("AssignmentStatus", AssignmentStatus.ToString()));
            }
            
            if (Reason != null)
            {
                p.Add(new KeyValuePair<string, string>("Reason", Reason));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (TaskChannel != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
            }
            
            return p;
        }
    }

    public class DeleteTaskOptions : IOptions<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteTaskOptions(string workspaceSid, string sid)
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

    public class ReadTaskOptions : ReadOptions<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public int? Priority { get; set; }
        public TaskResource.StatusEnum AssignmentStatus { get; set; }
        public string WorkflowSid { get; set; }
        public string WorkflowName { get; set; }
        public string TaskQueueSid { get; set; }
        public string TaskQueueName { get; set; }
        public string TaskChannel { get; set; }
        public string EvaluateTaskAttributes { get; set; }
        public string Ordering { get; set; }
        public bool? HasAddons { get; set; }
    
        /// <summary>
        /// Construct a new ReadTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadTaskOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (AssignmentStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("AssignmentStatus", AssignmentStatus.ToString()));
            }
            
            if (WorkflowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowSid", WorkflowSid));
            }
            
            if (WorkflowName != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowName", WorkflowName));
            }
            
            if (TaskQueueSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueSid", TaskQueueSid));
            }
            
            if (TaskQueueName != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueName", TaskQueueName));
            }
            
            if (TaskChannel != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
            }
            
            if (EvaluateTaskAttributes != null)
            {
                p.Add(new KeyValuePair<string, string>("EvaluateTaskAttributes", EvaluateTaskAttributes));
            }
            
            if (Ordering != null)
            {
                p.Add(new KeyValuePair<string, string>("Ordering", Ordering));
            }
            
            if (HasAddons != null)
            {
                p.Add(new KeyValuePair<string, string>("HasAddons", HasAddons.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class CreateTaskOptions : IOptions<TaskResource> 
    {
        public string WorkspaceSid { get; }
        public string Attributes { get; set; }
        public string WorkflowSid { get; set; }
        public int? Timeout { get; set; }
        public int? Priority { get; set; }
        public string TaskChannel { get; set; }
    
        /// <summary>
        /// Construct a new CreateTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public CreateTaskOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            if (WorkflowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowSid", WorkflowSid));
            }
            
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.ToString()));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            
            if (TaskChannel != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
            }
            
            return p;
        }
    }

}
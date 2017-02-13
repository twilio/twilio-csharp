using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchTaskOptions : IOptions<TaskResource> 
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The attributes
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// The assignment_status
        /// </summary>
        public TaskResource.StatusEnum AssignmentStatus { get; set; }
        /// <summary>
        /// The reason
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// The priority
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// The task_channel
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("Priority", Priority.Value.ToString()));
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The priority
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// The assignment_status
        /// </summary>
        public List<string> AssignmentStatus { get; set; }
        /// <summary>
        /// The workflow_sid
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// The workflow_name
        /// </summary>
        public string WorkflowName { get; set; }
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        public string TaskQueueSid { get; set; }
        /// <summary>
        /// The task_queue_name
        /// </summary>
        public string TaskQueueName { get; set; }
        /// <summary>
        /// The evaluate_task_attributes
        /// </summary>
        public string EvaluateTaskAttributes { get; set; }
        /// <summary>
        /// The ordering
        /// </summary>
        public string Ordering { get; set; }
        /// <summary>
        /// The has_addons
        /// </summary>
        public bool? HasAddons { get; set; }
    
        /// <summary>
        /// Construct a new ReadTaskOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadTaskOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
            AssignmentStatus = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.Value.ToString()));
            }
            
            if (AssignmentStatus != null)
            {
                p.AddRange(AssignmentStatus.Select(prop => new KeyValuePair<string, string>("AssignmentStatus", prop)));
            }
            
            if (WorkflowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowSid", WorkflowSid.ToString()));
            }
            
            if (WorkflowName != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowName", WorkflowName));
            }
            
            if (TaskQueueSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueSid", TaskQueueSid.ToString()));
            }
            
            if (TaskQueueName != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskQueueName", TaskQueueName));
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
                p.Add(new KeyValuePair<string, string>("HasAddons", HasAddons.Value.ToString()));
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
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string WorkspaceSid { get; }
        /// <summary>
        /// The timeout
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// The priority
        /// </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// The task_channel
        /// </summary>
        public string TaskChannel { get; set; }
        /// <summary>
        /// The workflow_sid
        /// </summary>
        public string WorkflowSid { get; set; }
        /// <summary>
        /// The attributes
        /// </summary>
        public string Attributes { get; set; }
    
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
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.Value.ToString()));
            }
            
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.Value.ToString()));
            }
            
            if (TaskChannel != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskChannel", TaskChannel));
            }
            
            if (WorkflowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkflowSid", WorkflowSid.ToString()));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            return p;
        }
    }

}
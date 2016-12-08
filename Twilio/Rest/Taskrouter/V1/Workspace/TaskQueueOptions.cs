using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class FetchTaskQueueOptions : IOptions<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTaskQueueOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchTaskQueueOptions(string workspaceSid, string sid)
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

    public class UpdateTaskQueueOptions : IOptions<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string TargetWorkers { get; set; }
        public string ReservationActivitySid { get; set; }
        public string AssignmentActivitySid { get; set; }
        public int? MaxReservedWorkers { get; set; }
        public TaskQueueResource.TaskOrderEnum TaskOrder { get; set; }
    
        /// <summary>
        /// Construct a new UpdateTaskQueueOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateTaskQueueOptions(string workspaceSid, string sid)
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
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (TargetWorkers != null)
            {
                p.Add(new KeyValuePair<string, string>("TargetWorkers", TargetWorkers));
            }
            
            if (ReservationActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ReservationActivitySid", ReservationActivitySid.ToString()));
            }
            
            if (AssignmentActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("AssignmentActivitySid", AssignmentActivitySid.ToString()));
            }
            
            if (MaxReservedWorkers != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxReservedWorkers", MaxReservedWorkers.Value.ToString()));
            }
            
            if (TaskOrder != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskOrder", TaskOrder.ToString()));
            }
            
            return p;
        }
    }

    public class ReadTaskQueueOptions : ReadOptions<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string FriendlyName { get; set; }
        public string EvaluateWorkerAttributes { get; set; }
        public string WorkerSid { get; set; }
    
        /// <summary>
        /// Construct a new ReadTaskQueueOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public ReadTaskQueueOptions(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (EvaluateWorkerAttributes != null)
            {
                p.Add(new KeyValuePair<string, string>("EvaluateWorkerAttributes", EvaluateWorkerAttributes));
            }
            
            if (WorkerSid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkerSid", WorkerSid.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class CreateTaskQueueOptions : IOptions<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string FriendlyName { get; }
        public string ReservationActivitySid { get; }
        public string AssignmentActivitySid { get; }
        public string TargetWorkers { get; set; }
        public int? MaxReservedWorkers { get; set; }
        public TaskQueueResource.TaskOrderEnum TaskOrder { get; set; }
    
        /// <summary>
        /// Construct a new CreateTaskQueueOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="reservationActivitySid"> The reservation_activity_sid </param>
        /// <param name="assignmentActivitySid"> The assignment_activity_sid </param>
        public CreateTaskQueueOptions(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid)
        {
            WorkspaceSid = workspaceSid;
            FriendlyName = friendlyName;
            ReservationActivitySid = reservationActivitySid;
            AssignmentActivitySid = assignmentActivitySid;
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
            
            if (ReservationActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("ReservationActivitySid", ReservationActivitySid.ToString()));
            }
            
            if (AssignmentActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("AssignmentActivitySid", AssignmentActivitySid.ToString()));
            }
            
            if (TargetWorkers != null)
            {
                p.Add(new KeyValuePair<string, string>("TargetWorkers", TargetWorkers));
            }
            
            if (MaxReservedWorkers != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxReservedWorkers", MaxReservedWorkers.Value.ToString()));
            }
            
            if (TaskOrder != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskOrder", TaskOrder.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteTaskQueueOptions : IOptions<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTaskQueueOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteTaskQueueOptions(string workspaceSid, string sid)
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
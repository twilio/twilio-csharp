using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class ReadReservationOptions : ReadOptions<ReservationResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public ReservationResource.StatusEnum ReservationStatus { get; set; }
    
        /// <summary>
        /// Construct a new ReadReservationOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        public ReadReservationOptions(string workspaceSid, string workerSid)
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
            if (ReservationStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("ReservationStatus", ReservationStatus.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class FetchReservationOptions : IOptions<ReservationResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchReservationOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchReservationOptions(string workspaceSid, string workerSid, string sid)
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

    public class UpdateReservationOptions : IOptions<ReservationResource> 
    {
        public string WorkspaceSid { get; }
        public string WorkerSid { get; }
        public string Sid { get; }
        public ReservationResource.StatusEnum ReservationStatus { get; set; }
        public string WorkerActivitySid { get; set; }
        public string Instruction { get; set; }
        public string DequeuePostWorkActivitySid { get; set; }
        public string DequeueFrom { get; set; }
        public string DequeueRecord { get; set; }
        public int? DequeueTimeout { get; set; }
        public string DequeueTo { get; set; }
        public Uri DequeueStatusCallbackUrl { get; set; }
        public string CallFrom { get; set; }
        public string CallRecord { get; set; }
        public int? CallTimeout { get; set; }
        public string CallTo { get; set; }
        public Uri CallUrl { get; set; }
        public Uri CallStatusCallbackUrl { get; set; }
        public bool? CallAccept { get; set; }
        public string RedirectCallSid { get; set; }
        public bool? RedirectAccept { get; set; }
        public Uri RedirectUrl { get; set; }
    
        /// <summary>
        /// Construct a new UpdateReservationOptions
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateReservationOptions(string workspaceSid, string workerSid, string sid)
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
            if (ReservationStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("ReservationStatus", ReservationStatus.ToString()));
            }
            
            if (WorkerActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("WorkerActivitySid", WorkerActivitySid));
            }
            
            if (Instruction != null)
            {
                p.Add(new KeyValuePair<string, string>("Instruction", Instruction));
            }
            
            if (DequeuePostWorkActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeuePostWorkActivitySid", DequeuePostWorkActivitySid));
            }
            
            if (DequeueFrom != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeueFrom", DequeueFrom));
            }
            
            if (DequeueRecord != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeueRecord", DequeueRecord));
            }
            
            if (DequeueTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeueTimeout", DequeueTimeout.ToString()));
            }
            
            if (DequeueTo != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeueTo", DequeueTo));
            }
            
            if (DequeueStatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeueStatusCallbackUrl", DequeueStatusCallbackUrl.ToString()));
            }
            
            if (CallFrom != null)
            {
                p.Add(new KeyValuePair<string, string>("CallFrom", CallFrom));
            }
            
            if (CallRecord != null)
            {
                p.Add(new KeyValuePair<string, string>("CallRecord", CallRecord));
            }
            
            if (CallTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("CallTimeout", CallTimeout.ToString()));
            }
            
            if (CallTo != null)
            {
                p.Add(new KeyValuePair<string, string>("CallTo", CallTo));
            }
            
            if (CallUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallUrl", CallUrl.ToString()));
            }
            
            if (CallStatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallStatusCallbackUrl", CallStatusCallbackUrl.ToString()));
            }
            
            if (CallAccept != null)
            {
                p.Add(new KeyValuePair<string, string>("CallAccept", CallAccept.ToString()));
            }
            
            if (RedirectCallSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectCallSid", RedirectCallSid));
            }
            
            if (RedirectAccept != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectAccept", RedirectAccept.ToString()));
            }
            
            if (RedirectUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectUrl", RedirectUrl.ToString()));
            }
            
            return p;
        }
    }

}
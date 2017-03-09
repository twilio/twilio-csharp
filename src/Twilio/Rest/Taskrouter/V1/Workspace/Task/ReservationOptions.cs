using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task 
{

    /// <summary>
    /// ReadReservationOptions
    /// </summary>
    public class ReadReservationOptions : ReadOptions<ReservationResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The task_sid
        /// </summary>
        public string PathTaskSid { get; }
        /// <summary>
        /// The reservation_status
        /// </summary>
        public ReservationResource.StatusEnum ReservationStatus { get; set; }

        /// <summary>
        /// Construct a new ReadReservationOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathTaskSid"> The task_sid </param>
        public ReadReservationOptions(string pathWorkspaceSid, string pathTaskSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathTaskSid = pathTaskSid;
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

    /// <summary>
    /// FetchReservationOptions
    /// </summary>
    public class FetchReservationOptions : IOptions<ReservationResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The task_sid
        /// </summary>
        public string PathTaskSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchReservationOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathTaskSid"> The task_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchReservationOptions(string pathWorkspaceSid, string pathTaskSid, string pathSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathTaskSid = pathTaskSid;
            PathSid = pathSid;
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

    /// <summary>
    /// UpdateReservationOptions
    /// </summary>
    public class UpdateReservationOptions : IOptions<ReservationResource> 
    {
        /// <summary>
        /// The workspace_sid
        /// </summary>
        public string PathWorkspaceSid { get; }
        /// <summary>
        /// The task_sid
        /// </summary>
        public string PathTaskSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The reservation_status
        /// </summary>
        public ReservationResource.StatusEnum ReservationStatus { get; set; }
        /// <summary>
        /// The worker_activity_sid
        /// </summary>
        public string WorkerActivitySid { get; set; }
        /// <summary>
        /// The instruction
        /// </summary>
        public string Instruction { get; set; }
        /// <summary>
        /// The dequeue_post_work_activity_sid
        /// </summary>
        public string DequeuePostWorkActivitySid { get; set; }
        /// <summary>
        /// The dequeue_from
        /// </summary>
        public string DequeueFrom { get; set; }
        /// <summary>
        /// The dequeue_record
        /// </summary>
        public string DequeueRecord { get; set; }
        /// <summary>
        /// The dequeue_timeout
        /// </summary>
        public int? DequeueTimeout { get; set; }
        /// <summary>
        /// The dequeue_to
        /// </summary>
        public string DequeueTo { get; set; }
        /// <summary>
        /// The dequeue_status_callback_url
        /// </summary>
        public Uri DequeueStatusCallbackUrl { get; set; }
        /// <summary>
        /// The call_from
        /// </summary>
        public string CallFrom { get; set; }
        /// <summary>
        /// The call_record
        /// </summary>
        public string CallRecord { get; set; }
        /// <summary>
        /// The call_timeout
        /// </summary>
        public int? CallTimeout { get; set; }
        /// <summary>
        /// The call_to
        /// </summary>
        public string CallTo { get; set; }
        /// <summary>
        /// The call_url
        /// </summary>
        public Uri CallUrl { get; set; }
        /// <summary>
        /// The call_status_callback_url
        /// </summary>
        public Uri CallStatusCallbackUrl { get; set; }
        /// <summary>
        /// The call_accept
        /// </summary>
        public bool? CallAccept { get; set; }
        /// <summary>
        /// The redirect_call_sid
        /// </summary>
        public string RedirectCallSid { get; set; }
        /// <summary>
        /// The redirect_accept
        /// </summary>
        public bool? RedirectAccept { get; set; }
        /// <summary>
        /// The redirect_url
        /// </summary>
        public Uri RedirectUrl { get; set; }

        /// <summary>
        /// Construct a new UpdateReservationOptions
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathTaskSid"> The task_sid </param>
        /// <param name="pathSid"> The sid </param>
        public UpdateReservationOptions(string pathWorkspaceSid, string pathTaskSid, string pathSid)
        {
            PathWorkspaceSid = pathWorkspaceSid;
            PathTaskSid = pathTaskSid;
            PathSid = pathSid;
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
                p.Add(new KeyValuePair<string, string>("WorkerActivitySid", WorkerActivitySid.ToString()));
            }

            if (Instruction != null)
            {
                p.Add(new KeyValuePair<string, string>("Instruction", Instruction));
            }

            if (DequeuePostWorkActivitySid != null)
            {
                p.Add(new KeyValuePair<string, string>("DequeuePostWorkActivitySid", DequeuePostWorkActivitySid.ToString()));
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
                p.Add(new KeyValuePair<string, string>("DequeueTimeout", DequeueTimeout.Value.ToString()));
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
                p.Add(new KeyValuePair<string, string>("CallTimeout", CallTimeout.Value.ToString()));
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
                p.Add(new KeyValuePair<string, string>("CallAccept", CallAccept.Value.ToString()));
            }

            if (RedirectCallSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectCallSid", RedirectCallSid.ToString()));
            }

            if (RedirectAccept != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectAccept", RedirectAccept.Value.ToString()));
            }

            if (RedirectUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("RedirectUrl", RedirectUrl.ToString()));
            }

            return p;
        }
    }

}
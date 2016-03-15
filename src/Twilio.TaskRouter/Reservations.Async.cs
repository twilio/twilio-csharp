using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Retrieve the details for a reservation instance. Makes a GET request to an Reservation Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservation belongs to</param>
        /// <param name="taskSid">The Sid of the task the reservation belongs to</param>
        /// <param name="reservationSid">The Sid of the reservation to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetReservation(string workspaceSid, string taskSid, string reservationSid, Action<Reservation> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);
            Require.Argument("ReservationSid", reservationSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            ExecuteAsync<Reservation>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List reservations for a task
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListReservations(string workspaceSid, string taskSid, Action<ReservationResult> callback)
        {
            ListReservations(workspaceSid, taskSid, null, null, null, null, callback);
        }

        /// <summary>
        /// List reservations for a task with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        /// <param name="status">Optional status to match</param>
        /// <param name="reservationStatus">Optional reservation status to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListReservations(string workspaceSid, string taskSid, string reservationStatus, string afterSid, string beforeSid, int? count, Action<ReservationResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);

            if (reservationStatus.HasValue())
                request.AddParameter("ReservationStatus", reservationStatus);
            if (afterSid.HasValue())
                request.AddParameter("AfterSid", afterSid);
            if (beforeSid.HasValue())
                request.AddParameter("BeforeSid", beforeSid);
            if (count.HasValue)
                request.AddParameter("PageSize", count.Value);

            ExecuteAsync<ReservationResult>(request, callback);
        }

        /// <summary>
        /// List reservations for a worker with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="workerSid">The Sid of the worker the reservations belong to</param>
        /// <param name="reservationStatus">Optional assignment status to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListReservationsForWorker(string workspaceSid, string workerSid, string reservationStatus, string afterSid, string beforeSid, int? count, Action<ReservationResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Reservations";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            if (reservationStatus.HasValue())
                request.AddParameter("ReservationStatus", reservationStatus);
            if (afterSid.HasValue())
                request.AddParameter("AfterSid", afterSid);
            if (beforeSid.HasValue())
                request.AddParameter("BeforeSid", beforeSid);
            if (count.HasValue)
                request.AddParameter("PageSize", count.Value);

            ExecuteAsync<ReservationResult>(request, callback);
        }

        /// <summary>
        /// Update a reservation.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="taskSid">Task Sid</param>
        /// <param name="reservationSid">Reservation sid.</param>
        /// <param name="reservationStatus">Optional Reservation status.</param>
        /// <param name="workerActivitySid">Optional Worker Activity Sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateReservation(string workspaceSid, string taskSid, string reservationSid,
            string reservationStatus, string workerActivitySid, Action<Reservation> callback)
        {
            UpdateReservation(workspaceSid, "Tasks", taskSid, reservationSid, callback,
                reservationStatus: reservationStatus, workerActivitySid: workerActivitySid);
        }

        /// <summary>
        /// Update a reservation.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="resource">Tasks or Workers resource</param>
        /// <param name="resourceSid">Task Sid or Worker Sid</param>
        /// <param name="reservationSid">Reservation sid.</param>
        /// <param name="reservationStatus">Optional Reservation status.</param>
        /// <param name="workerActivitySid">Optional Worker Activity Sid.</param>
        /// <param name="instruction">Optional Instruction.</param>
        /// <param name="dequeuePostWorkActivitySid">Optional Dequeue Post Work Activity Sid.</param>
        /// <param name="dequeueFrom">Optional Dequeue From.</param>
        /// <param name="dequeueRecord">Optional Dequeue Record.</param>
        /// <param name="dequeueTimeout">Optional Dequeue Timeout.</param>
        /// <param name="dequeueTo">Optional Dequeue To.</param>
        /// <param name="dequeueStatusCallbackUrl">Optional Dequeue Status Callback Url.</param>
        /// <param name="callFrom">Optional Call From.</param>
        /// <param name="callRecord">Optional Call Record.</param>
        /// <param name="callTimeout">Optional Call Timeout.</param>
        /// <param name="callTo">Optional Call To.</param>
        /// <param name="callUrl">Optional Call Url.</param>
        /// <param name="callStatusCallbackUrl">Optional Call Status Callback Url.</param>
        /// <param name="callAccept">Optional Call Accept.</param>
        /// <param name="redirectCallSid">Optional Redirect Call Sid.</param>
        /// <param name="redirectAccept">Optional Redirect Accept.</param>
        /// <param name="redirectUrl">Optional Redirect Url.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateReservation(
            string workspaceSid,
            string resource,
            string resourceSid,
            string reservationSid,
            Action<Reservation> callback,
            string reservationStatus = null,
            string workerActivitySid = null,
            string instruction = null,
            string dequeuePostWorkActivitySid = null,
            string dequeueFrom = null,
            string dequeueRecord = null,
            string dequeueTimeout = null,
            string dequeueTo = null,
            string dequeueStatusCallbackUrl = null,
            string callFrom = null,
            string callRecord = null,
            string callTimeout = null,
            string callTo = null,
            string callUrl = null,
            string callStatusCallbackUrl = null,
            string callAccept = null,
            string redirectCallSid = null,
            string redirectAccept = null,
            string redirectUrl = null
        )
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("Resource", resource);
            Require.Argument("ResourceSid", resourceSid);
            Require.Argument("ReservationSid", reservationSid);
            Require.Argument("ReservationStatus", reservationStatus);
            Require.Argument("Callback", callback);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/{Resource}/{ResourceSid}/Reservations/{ReservationSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("Resource", resource);
            request.AddUrlSegment("ResourceSid", resourceSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            if (!String.IsNullOrEmpty(reservationStatus))
                request.AddParameter("ReservationStatus", reservationStatus);

            if (!String.IsNullOrEmpty(workerActivitySid))
                request.AddParameter("WorkerActivitySid", workerActivitySid);

            if (!String.IsNullOrEmpty(instruction))
                request.AddParameter("Instruction", instruction);

            if (!String.IsNullOrEmpty(dequeuePostWorkActivitySid))
                request.AddParameter("DequeuePostWorkActivitySid", dequeuePostWorkActivitySid);

            if (!String.IsNullOrEmpty(dequeueFrom))
                request.AddParameter("DequeueFrom", dequeueFrom);

            if (!String.IsNullOrEmpty(dequeueRecord))
                request.AddParameter("DequeueRecord", dequeueRecord);

            if (!String.IsNullOrEmpty(dequeueTimeout))
                request.AddParameter("DequeueTimeout", dequeueTimeout);

            if (!String.IsNullOrEmpty(dequeueTo))
                request.AddParameter("DequeueTo", dequeueTo);

            if (!String.IsNullOrEmpty(dequeueStatusCallbackUrl))
                request.AddParameter("DequeueStatusCallbackUrl", dequeueStatusCallbackUrl);

            if (!String.IsNullOrEmpty(callFrom))
                request.AddParameter("CallFrom", callFrom);

            if (!String.IsNullOrEmpty(callRecord))
                request.AddParameter("CallRecord", callRecord);

            if (!String.IsNullOrEmpty(callTimeout))
                request.AddParameter("CallTimeout", callTimeout);

            if (!String.IsNullOrEmpty(callTo))
                request.AddParameter("CallTo", callTo);

            if (!String.IsNullOrEmpty(callUrl))
                request.AddParameter("CallUrl", callUrl);

            if (!String.IsNullOrEmpty(callStatusCallbackUrl))
                request.AddParameter("CallStatusCallbackUrl", callStatusCallbackUrl);

            if (!String.IsNullOrEmpty(callAccept))
                request.AddParameter("CallAccept", callAccept);

            if (!String.IsNullOrEmpty(redirectCallSid))
                request.AddParameter("RedirectCallSid", redirectCallSid);

            if (!String.IsNullOrEmpty(redirectAccept))
                request.AddParameter("RedirectAccept", redirectAccept);

            if (!String.IsNullOrEmpty(redirectUrl))
                request.AddParameter("RedirectUrl", redirectUrl);

            ExecuteAsync<Reservation>(request, (response) => { callback(response); });
        }
    }
}


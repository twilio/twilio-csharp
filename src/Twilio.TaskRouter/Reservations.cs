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
        public virtual Reservation GetReservation(string workspaceSid, string taskSid, string reservationSid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);
            Require.Argument("ReservationSid", reservationSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            return Execute<Reservation>(request);
        }

        /// <summary>
        /// List reservations for a task
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        public virtual ReservationResult ListReservations(string workspaceSid, string taskSid)
        {
            return ListReservations(workspaceSid, taskSid, null, null, null, null);
        }

        /// <summary>
        /// List reservations for a task with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        /// <param name="reservationStatus">Optional reservation status to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual ReservationResult ListReservations(string workspaceSid, string taskSid, string reservationStatus, string afterSid, string beforeSid, int? count)
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

            return Execute<ReservationResult>(request);
        }

        /// <summary>
        /// List reservations for a worker.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="workerSid">The Sid of the worker the reservations belong to</param>
        public virtual ReservationResult ListReservationsForWorker(string workspaceSid, string workerSid)
        {
            return ListReservationsForWorker(workspaceSid, workerSid, null, null, null, null);
        }

        /// <summary>
        /// List reservations for a worker with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="workerSid">The Sid of the worker the reservations belong to</param>
        /// <param name="reservationStatus">Optional reservation status to match</param>
        /// <param name="afterSid">Reservation Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual ReservationResult ListReservationsForWorker(string workspaceSid, string workerSid, string reservationStatus, string afterSid, string beforeSid, int? count)
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

            return Execute<ReservationResult>(request);
        }
            
        /// <summary>
        /// Update a reservation.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="taskSid">Task sid.</param>
        /// <param name="reservationSid">Reservation sid.</param>
        /// <param name="reservationStatus">Reservation status.</param>
        /// <param name="workerActivitySid">Optional worker activity sid.</param>
        /// <param name="instruction">Optional instruction.</param>
        /// <param name="dequeueFrom">Optional dequeue from</param>
        /// <param name="dequeuePostWorkActivitySid">Optional dequeue post work activity sid.</param>
        /// <param name="callFrom">Optional call from.</param>
        /// <param name="callUrl">Optional call URL.</param>
        /// <param name="callAccept">Optional call accept.</param>
        /// <param name="callStatusCallbackUrl">Optional call status callback URL.</param>
        public virtual Reservation UpdateReservation(string workspaceSid, string taskSid, string reservationSid, string reservationStatus, 
            string workerActivitySid = null, string instruction = null, string dequeueFrom = null, string dequeuePostWorkActivitySid = null, 
            string callFrom = null, string callUrl = null, string callAccept = null, string callStatusCallbackUrl = null)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);
            Require.Argument("ReservationSid", reservationSid);
            Require.Argument("ReservationStatus", reservationStatus);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            request.AddParameter("ReservationStatus", reservationStatus);
            if (workerActivitySid.HasValue())
                request.AddParameter("WorkerActivitySid", workerActivitySid);
            if (instruction.HasValue())
            {
                request.AddParameter("Instruction", instruction);
                if (instruction.Equals("Dequeue"))
                {
                    if (dequeueFrom.HasValue())
                        request.AddParameter("DequeueFrom", dequeueFrom);
                    if (dequeuePostWorkActivitySid.HasValue())
                        request.AddParameter("DequeuePostWorkActivitySid", dequeuePostWorkActivitySid);
                }
                else
                {
                    if (callFrom.HasValue())
                        request.AddParameter("CallFrom", callFrom);
                    if (callFrom.HasValue())
                        request.AddParameter("CallUrl", callUrl);
                    if (callAccept.HasValue())
                        request.AddParameter("CallAccept", callAccept);
                    if (callStatusCallbackUrl.HasValue())
                        request.AddParameter("CallStatusCallbackUrl", callStatusCallbackUrl);
                }
            }
            return Execute<Reservation>(request);
        }
    }
}


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
        public virtual Reservation UpdateReservation(string workspaceSid, string taskSid, string reservationSid, string reservationStatus, string workerActivitySid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);
            Require.Argument("ReservationSid", reservationSid);
            Require.Argument("ReservationStatus", reservationStatus);

            return this.UpdateReservation(new ReservationRequest(workspaceSid, taskSid, reservationSid, reservationStatus)
                .WithWorkerActivitySid(workerActivitySid));
        }

        /// <summary>
        /// Updates the reservation.
        /// </summary>
        /// <param name="reservationRequest">Reservation request.</param>
        public virtual Reservation UpdateReservation(ReservationRequest reservationRequest) 
        {
            Require.Argument("ReservationRequest", reservationRequest);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}";
            request.AddUrlSegment("WorkspaceSid", reservationRequest.GetWorkspaceSid());
            request.AddUrlSegment("TaskSid", reservationRequest.GetTaskSid());
            request.AddUrlSegment("ReservationSid", reservationRequest.GetReservationSid());

            request.AddParameter("ReservationStatus", reservationRequest.GetReservationStatus());
            if (reservationRequest.GetWorkerActivitySid().HasValue())
                request.AddParameter("WorkerActivitySid", reservationRequest.GetWorkerActivitySid());
            if (reservationRequest.GetInstruction().HasValue())
            {
                request.AddParameter("Instruction", reservationRequest.GetInstruction());
                if (reservationRequest.GetInstruction().Equals("Dequeue"))
                {
                    if (reservationRequest.GetDequeueFrom().HasValue())
                        request.AddParameter("DequeueFrom", reservationRequest.GetDequeueFrom());
                    if (reservationRequest.GetDequeuePostWorkActivitySid().HasValue())
                        request.AddParameter("DequeuePostWorkActivitySid", reservationRequest.GetDequeuePostWorkActivitySid());
                }
                else
                {
                    if (reservationRequest.GetCallFrom().HasValue())
                        request.AddParameter("CallFrom", reservationRequest.GetCallFrom());
                    if (reservationRequest.GetCallUrl().HasValue())
                        request.AddParameter("CallUrl", reservationRequest.GetCallUrl());
                    if (reservationRequest.GetCallAccept().HasValue())
                        request.AddParameter("CallAccept", reservationRequest.GetCallAccept());
                    if (reservationRequest.GetCallStatusCallbackUrl().HasValue())
                        request.AddParameter("CallStatusCallbackUrl", reservationRequest.GetCallStatusCallbackUrl());
                }
            }
            return Execute<Reservation>(request);
        }
    }
}


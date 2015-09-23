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
        /// <param name="taskSid">Task sid.</param>
        /// <param name="reservationSid">Reservation sid.</param>
        /// <param name="reservationStatus">Reservation status.</param>
        /// <param name="workerActivitySid">Optional worker activity sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateReservation(string workspaceSid, string taskSid, string reservationSid, string reservationStatus, string workerActivitySid, Action<Reservation> callback)
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

            ExecuteAsync<Reservation>(request, (response) => { callback(response); });
        }
    }
}


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
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            return Execute<Reservation>(request);
        }

        /// <summary>
        /// List reservations on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        public virtual ReservationResult ListReservations(string workspaceSid, string taskSid)
        {
            return ListReservations(workspaceSid, taskSid, null, null, null, null, null);
        }

        /// <summary>
        /// List reservations on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the reservations belong to</param>
        /// <param name="taskSid">The Sid of the task the reservations belong to</param>
        /// <param name="status">Optional status to match</param>
        /// <param name="assignmentStatus">Optional assignment status to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        public virtual ReservationResult ListReservations(string workspaceSid, string taskSid, string status, string assignmentStatus, string afterSid, string beforeSid, int? count)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskSid", taskSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);

            if (status.HasValue())
                request.AddParameter("Status", status);
            if (assignmentStatus.HasValue())
                request.AddParameter("AssignmentStatus", assignmentStatus);
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

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Tasks/{TaskSid}/Reservations/{ReservationSid}.json";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskSid", taskSid);
            request.AddUrlSegment("ReservationSid", reservationSid);

            request.AddParameter("ReservationStatus", reservationStatus);
            if (workerActivitySid.HasValue())
                request.AddParameter("WorkerActivitySid", workerActivitySid);

            return Execute<Reservation>(request);
        }
    }
}


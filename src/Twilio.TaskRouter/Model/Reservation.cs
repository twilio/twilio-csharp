using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// A Task Reservation is created whenever a Task is assigned to a Worker.
    /// </summary>
    public class Reservation : TwilioBase
    {
        /// <summary>
        /// Gets or sets the sid.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// Gets or sets the account sid.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Gets or sets the workspace sid.
        /// </summary>
        public string WorkspaceSid { get; set; }
        /// <summary>
        /// Gets or sets the task sid.
        /// </summary>
        public string TaskSid { get; set; }
        /// <summary>
        /// Gets or sets the worker sid.
        /// </summary>
        public string WorkerSid { get; set; }
        /// <summary>
        /// Gets or sets the name of the worker.
        /// </summary>
        public string WorkerName { get; set; }
        /// <summary>
        /// Gets or sets the worker activity sid.
        /// </summary>
        public string WorkerActivitySid { get; set; }
        /// <summary>
        /// Gets or sets the reservation status.
        /// </summary>
        public string ReservationStatus { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}


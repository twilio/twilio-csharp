using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant to use for Twilio TaskRouter
    /// </summary>
    public class TaskRouterGrant : IGrant
    {
        /// <summary>
        /// Workspace SID
        /// </summary>
        public string WorkspaceSid { get; set; }

        /// <summary>
        /// Worker SID
        /// </summary>
        public string WorkerSid { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Get the grant name
        /// </summary>
        ///
        /// <returns>name of the grant</returns>
        public string Key
        {
            get
            {
                return "task_router";
            }
        }

        /// <summary>
        /// Get the grant payload
        /// </summary>
        ///
        /// <returns>payload of the grant</returns>
        public object Payload
        {
            get
            {
                var payload = new Dictionary<string, string>();

                if (WorkspaceSid != null)
                {
                    payload.Add("workspace_sid", WorkspaceSid);
                }
                if (WorkerSid != null)
                {
                    payload.Add("worker_sid", WorkerSid);
                }
                if (Role != null)
                {
                    payload.Add("role", Role);
                }

                return payload;
            }
        }

    }
}
using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Grant for Twilio TaskRouter
    /// </summary>
    public class TaskRouterGrant : IGrant
    {
        public string WorkspaceSid { get; set; }
        public string WorkerSid { get; set; }
        public string Role { get; set; }

        /// <summary>
        /// Get the grant key
        /// </summary>
        ///
        /// <returns>the grant key</returns>
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
        /// <returns>the grant payload</returns>
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

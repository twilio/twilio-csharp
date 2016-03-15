using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Roles belonging to a Service.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <returns>List of Roles</returns>
		public virtual RoleResult ListRoles(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles";

            request.AddUrlSegment("ServiceSid", serviceSid);

            return Execute<RoleResult>(request);
        }

        /// <summary>
        /// Retrieves a Role by Role Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="roleSid">Role Sid</param>
        /// <returns>Role</returns>
        public virtual Role GetRole(string serviceSid, string roleSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("RoleSid", roleSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles/{RoleSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("RoleSid", roleSid);

            return Execute<Role>(request);
        }
    }
}

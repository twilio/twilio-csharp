using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Roles belonging to a Service.
        /// </summary>
        public virtual RoleResult ListRoles()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles";

            return Execute<RoleResult>(request);
        }

        /// <summary>
        /// Retrieves a Role by Role Sid.
        /// </summary>
        /// <param name="roleSid">Role Sid</param>
        public virtual Role GetRole(string roleSid)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles/{RoleSid}";
            request.AddUrlSegment("RoleSid", roleSid);

            return Execute<Role>(request);
        }
    }
}

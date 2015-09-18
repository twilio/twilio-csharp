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
        public virtual void ListRoles(Action<RoleResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles";

            ExecuteAsync<RoleResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves a Role by Role Sid.
        /// </summary>
        /// <param name="roleSid">Role Sid</param>
        public virtual void GetRole(string roleSid, Action<Role> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles/{RoleSid}";
            request.AddUrlSegment("RoleSid", roleSid);

            ExecuteAsync<Role>(request, (response) => callback(response));
        }
    }
}

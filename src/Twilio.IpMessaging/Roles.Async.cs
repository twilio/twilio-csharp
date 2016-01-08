using System;
using System.Collections.Generic;
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
        public virtual void ListRoles(string serviceSid, 
            Action<RoleResult> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles";

            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync<RoleResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves a Role by Role Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual void GetRole(string serviceSid, string roleSid, 
            Action<Role> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("RoleSid", roleSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Roles/{RoleSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("RoleSid", roleSid);

            ExecuteAsync<Role>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Role
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="type">Type</param>
        /// <param name="permissions">Permissions</param>
        /// <returns>Role</returns>
        public virtual void CreateRole(string serviceSid, string friendlyName, string type, List<string> permissions, Action<Role> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("FriendlyName", friendlyName);
            Require.Argument("Type", type);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Roles";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Type", type);
            foreach (string permission in permissions) {
                request.AddParameter("Permission", permission);
            }

            ExecuteAsync<Role>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a Role
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="roleSid">Role Sid</param>
        /// <param name="friendlyName">Friendly Name</param>
        /// <param name="permissions">Permissions</param>
        /// <returns>Role</returns>
        public virtual void UpdateRole(string serviceSid, string roleSid, string friendlyName, List<string> permissions, Action<Role> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Roles/{RoleSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("RoleSid", roleSid);
            request.AddParameter("FriendlyName", friendlyName);
            foreach (string permission in permissions) {
                request.AddParameter("Permission", permission);
            }

            ExecuteAsync<Role>(request, (response) => callback(response));
        }
    }
}

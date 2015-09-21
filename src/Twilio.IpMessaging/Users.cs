using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Users belonging to a Service.
        /// </summary>
        public virtual UserResult ListUsers()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServcieSid}/Users";

            return Execute<UserResult>(request);
        }

        /// <summary>
        /// Retrieves User by User Sid.
        /// </summary>
        /// <param name="userSid">User Sid</param>
        public virtual User GetUser(string userSid)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";
            request.AddUrlSegment("UserSid", userSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="identity">Identity</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual User CreateUser(string identity, string roleSid)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServcieSid}/Users";

            request.AddUrlSegment("ServcieSid", serviceSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Updates a User.
        /// </summary>
        /// <param name="roleSid">Role Sid</param>
        public virtual User UpdateUser(string roleSid)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";

            request.AddUrlSegment("ServcieSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            request.AddParameter("RoleSid", roleSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Deletes a User identified by User Sid.
        /// </summary>
        /// <param name="userSid">User Sid</param>
        public virtual DeleteStatus DeleteUser(string userSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";
            request.AddUrlSegment("UserSid", userSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                                            DeleteStatus.Success :
                                            DeleteStatus.Failed;
        }
    }
}

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
        /// <param name="serviceSid">Service Sid</param>
        public virtual UserResult ListUsers(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Users";

            request.AddUrlSegment("ServiceSid", serviceSid);

            return Execute<UserResult>(request);
        }

        /// <summary>
        /// Retrieves User by User Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        public virtual User GetUser(string serviceSid, string userSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="identity">Identity</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual User CreateUser(string serviceSid, string identity, 
            string roleSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("Identity", identity);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Users";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Updates a User.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual User UpdateUser(string serviceSid, string userSid, string roleSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            request.AddParameter("RoleSid", roleSid);

            return Execute<User>(request);
        }

        /// <summary>
        /// Deletes a User identified by User Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        public virtual DeleteStatus DeleteUser(string serviceSid, string userSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                                            DeleteStatus.Success :
                                            DeleteStatus.Failed;
        }
    }
}

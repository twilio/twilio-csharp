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
        /// Retrieves all the Users belonging to a Service.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        public virtual void ListUsers(string serviceSid, 
            Action<UserResult> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Users";

            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync<UserResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves User by User Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        public virtual void GetUser(string serviceSid, string userSid, 
            Action<User> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="identity">Identity</param>
        public virtual void CreateUser(string serviceSid, string identity, 
            Action<User> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("Identity", identity);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Users";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Identity", identity);

            ExecuteAsync(request, callback);
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="identity">Identity</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual void CreateUser(string serviceSid, string identity, 
            string roleSid, Action<User> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("Identity", identity);
            
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Users";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a User.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual void UpdateUser(string serviceSid, string userSid, 
            string roleSid, Action<User> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a User identified by User Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="userSid">User Sid</param>
        public virtual void DeleteUser(string serviceSid, string userSid, 
            Action<DeleteStatus> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("UserSid", userSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Users/{UserSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            ExecuteAsync(request, (response) => { callback(
                response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}

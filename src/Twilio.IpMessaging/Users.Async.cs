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
        public virtual void ListUsers(Action<UserResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServcieSid}/Users";

            ExecuteAsync<UserResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves User by User Sid.
        /// </summary>
        /// <param name="userSid">User Sid</param>
        public virtual void GetUser(string userSid, Action<User> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";
            request.AddUrlSegment("UserSid", userSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <param name="identity">Identity</param>
        /// <param name="roleSid">Role Sid</param>
        public virtual void CreateUser(string identity, string roleSid,
          Action<User> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServcieSid}/Users";

            request.AddUrlSegment("ServcieSid", serviceSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a User.
        /// </summary>
        /// <param name="roleSid">Role Sid</param>
        public virtual void UpdateUser(string roleSid, Action<User> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";

            request.AddUrlSegment("ServcieSid", serviceSid);
            request.AddUrlSegment("UserSid", userSid);

            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<User>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a User identified by User Sid.
        /// </summary>
        /// <param name="userSid">User Sid</param>
        public virtual void DeleteUser(string credentialSid,
          Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServcieSid}/Users/{UserSid}";
            request.AddUrlSegment("UserSid", userSid);

            var response = Execute(request);
            ExecuteAsync(request, (response) => { callback(
              response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}

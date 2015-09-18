using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Members belonging to a Channel.
        /// </summary>
        public virtual void ListMembers(Action<MemberResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            ExecuteAsync<MemberResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves a Member by Member Sid.
        /// </summary>
        /// <param name="memberSid">Member Sid</param>
        public virtual void GetMember(string memberSid,
          Action<Member> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";
            request.AddUrlSegment("MemberSid", memberSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Member.
        /// </summary>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual void CreateMember(string identity, string roleSid,
          Action<Member> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Modifies Member properties in a channel.
        /// </summary>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual void ModifyMember(string identity, string roleSid,
          Action<Member> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("MemberSid", memberSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Member identified by Member Sid.
        /// </summary>
        /// <param name="memberSid">Member Sid</param>
        public virtual void DeleteMember(string memberSid,
          Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";
            request.AddUrlSegment("MemberSid", memberSid);

            var response = Execute(request);
            ExecuteAsync(request, (response) => { callback(
              response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}

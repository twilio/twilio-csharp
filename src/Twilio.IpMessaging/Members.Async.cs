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
        /// Retrieves all the Members belonging to a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        public virtual void ListMembers(string serviceSid, string channelSid,
            Action<MemberResult> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            ExecuteAsync<MemberResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves a Member by Member Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        public virtual void GetMember(string serviceSid, string channelSid, 
            string memberSid, Action<Member> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MemberSid", memberSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MemberSid", memberSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Member.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual void CreateMember(string serviceSid, string channelSid, 
            string identity, string roleSid, Action<Member> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("Identity", identity);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates Member properties in a channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual void UpdateMember(string serviceSid, string channelSid, 
            string memberSid, string identity, string roleSid, 
            Action<Member> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MemberSid", memberSid);
            Require.Argument("RoleSid", roleSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MemberSid", memberSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            ExecuteAsync<Member>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Member identified by Member Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        public virtual void DeleteMember(string serviceSid, string channelSid, 
            string memberSid, Action<DeleteStatus> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MemberSid", memberSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MemberSid", memberSid);

            ExecuteAsync(request, (response) => { callback(
                response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}

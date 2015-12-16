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
        /// <returns>List of Members</returns>
        public virtual MemberResult ListMembers(string serviceSid, 
            string channelSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            return Execute<MemberResult>(request);
        }

        /// <summary>
        /// Retrieves a Member by Member Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        /// <returns>Member</returns>
        public virtual Member GetMember(string serviceSid, string channelSid, 
            string memberSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MemberSid", memberSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MemberSid", memberSid);

            return Execute<Member>(request);
        }

        /// <summary>
        /// Creates a Member.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        /// <returns>A new Member</returns>
        public virtual Member CreateMember(string serviceSid, string channelSid, 
            string identity, string roleSid)
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

            return Execute<Member>(request);
        }

        /// <summary>
        /// Updates Member properties in a channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        /// <returns>Updated Member</returns>
        public virtual Member UpdateMember(string serviceSid, string channelSid, 
            string memberSid, string identity, string roleSid)
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

            return Execute<Member>(request);
        }

        /// <summary>
        /// Deletes a Member identified by Member Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="memberSid">Member Sid</param>
        /// <returns>Member deletion status</returns>
        public virtual DeleteStatus DeleteMember(string serviceSid, 
            string channelSid, string memberSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MemberSid", memberSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MemberSid", memberSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? 
                DeleteStatus.Success : 
                DeleteStatus.Failed;
        }
    }
}

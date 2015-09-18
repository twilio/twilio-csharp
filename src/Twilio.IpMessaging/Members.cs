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
        public virtual MemberResult ListMembers()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            return Execute<MemberResult>(request);
        }

        /// <summary>
        /// Retrieves a Member by Member Sid.
        /// </summary>
        /// <param name="memberSid">Member Sid</param>
        public virtual Member GetMember(string memberSid)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";
            request.AddUrlSegment("MemberSid", memberSid);

            return Execute<Member>(request);
        }

        /// <summary>
        /// Creates a Member.
        /// </summary>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual Member CreateMember(string identity, string roleSid)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members";

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            return Execute<Member>(request);
        }

        /// <summary>
        /// Modifies Member properties in a channel.
        /// </summary>
        /// <param name="identity">Identity of the Member</param>
        /// <param name="roleSid">Role sid of member</param>
        public virtual Member ModifyMember(string identity,
          string roleSid)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";

            request.AddUrlSegment("MemberSid", memberSid);

            request.AddParameter("Identity", identity);
            request.AddParameter("RoleSid", roleSid);

            return Execute<Member>(request);
        }

        /// <summary>
        /// Deletes a Member identified by Member Sid.
        /// </summary>
        /// <param name="memberSid">Member Sid</param>
        public virtual DeleteStatus DeleteMember(string memberSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}/Members/{MemberSid}";
            request.AddUrlSegment("MemberSid", memberSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                                            DeleteStatus.Success :
                                            DeleteStatus.Failed;
        }
    }
}

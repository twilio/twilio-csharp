using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    /// <summary>
    /// FetchMemberOptions
    /// </summary>
    public class FetchMemberOptions : IOptions<MemberResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The channel_sid
        /// </summary>
        public string PathChannelSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new FetchMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchMemberOptions(string serviceSid, string channelSid, string sid)
        {
            PathServiceSid = serviceSid;
            PathChannelSid = channelSid;
            PathSid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// CreateMemberOptions
    /// </summary>
    public class CreateMemberOptions : IOptions<MemberResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The channel_sid
        /// </summary>
        public string PathChannelSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// The role_sid
        /// </summary>
        public string RoleSid { get; set; }
    
        /// <summary>
        /// Construct a new CreateMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="identity"> The identity </param>
        public CreateMemberOptions(string serviceSid, string channelSid, string identity)
        {
            PathServiceSid = serviceSid;
            PathChannelSid = channelSid;
            Identity = identity;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// ReadMemberOptions
    /// </summary>
    public class ReadMemberOptions : ReadOptions<MemberResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The channel_sid
        /// </summary>
        public string PathChannelSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public List<string> Identity { get; set; }
    
        /// <summary>
        /// Construct a new ReadMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        public ReadMemberOptions(string serviceSid, string channelSid)
        {
            PathServiceSid = serviceSid;
            PathChannelSid = channelSid;
            Identity = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop)));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    /// <summary>
    /// DeleteMemberOptions
    /// </summary>
    public class DeleteMemberOptions : IOptions<MemberResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The channel_sid
        /// </summary>
        public string PathChannelSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new DeleteMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteMemberOptions(string serviceSid, string channelSid, string sid)
        {
            PathServiceSid = serviceSid;
            PathChannelSid = channelSid;
            PathSid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// UpdateMemberOptions
    /// </summary>
    public class UpdateMemberOptions : IOptions<MemberResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The channel_sid
        /// </summary>
        public string PathChannelSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The role_sid
        /// </summary>
        public string RoleSid { get; set; }
        /// <summary>
        /// The last_consumed_message_index
        /// </summary>
        public int? LastConsumedMessageIndex { get; set; }
    
        /// <summary>
        /// Construct a new UpdateMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateMemberOptions(string serviceSid, string channelSid, string sid)
        {
            PathServiceSid = serviceSid;
            PathChannelSid = channelSid;
            PathSid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }
            
            if (LastConsumedMessageIndex != null)
            {
                p.Add(new KeyValuePair<string, string>("LastConsumedMessageIndex", LastConsumedMessageIndex.ToString()));
            }
            
            return p;
        }
    }

}
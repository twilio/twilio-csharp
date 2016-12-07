using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
{

    public class FetchMemberOptions : IOptions<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchMemberOptions(string serviceSid, string channelSid, string sid)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Sid = sid;
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

    public class CreateMemberOptions : IOptions<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Identity { get; }
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
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
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
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid));
            }
            
            return p;
        }
    }

    public class ReadMemberOptions : ReadOptions<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public List<string> Identity { get; set; }
    
        /// <summary>
        /// Construct a new ReadMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        public ReadMemberOptions(string serviceSid, string channelSid)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop.ToString())));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteMemberOptions : IOptions<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteMemberOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteMemberOptions(string serviceSid, string channelSid, string sid)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Sid = sid;
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

    public class UpdateMemberOptions : IOptions<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
        public string RoleSid { get; set; }
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
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid));
            }
            
            if (LastConsumedMessageIndex != null)
            {
                p.Add(new KeyValuePair<string, string>("LastConsumedMessageIndex", LastConsumedMessageIndex.ToString()));
            }
            
            return p;
        }
    }

}
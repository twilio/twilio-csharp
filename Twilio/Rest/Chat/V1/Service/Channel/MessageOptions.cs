using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class FetchMessageOptions : IOptions<MessageResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchMessageOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchMessageOptions(string serviceSid, string channelSid, string sid)
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

    public class CreateMessageOptions : IOptions<MessageResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Body { get; }
        public string From { get; set; }
        public string Attributes { get; set; }
    
        /// <summary>
        /// Construct a new CreateMessageOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="body"> The body </param>
        public CreateMessageOptions(string serviceSid, string channelSid, string body)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Body = body;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            return p;
        }
    }

    public class ReadMessageOptions : ReadOptions<MessageResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
    
        /// <summary>
        /// Construct a new ReadMessageOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        public ReadMessageOptions(string serviceSid, string channelSid)
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
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteMessageOptions : IOptions<MessageResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteMessageOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteMessageOptions(string serviceSid, string channelSid, string sid)
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

    public class UpdateMessageOptions : IOptions<MessageResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
        public string Body { get; }
        public string Attributes { get; set; }
    
        /// <summary>
        /// Construct a new UpdateMessageOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="body"> The body </param>
        public UpdateMessageOptions(string serviceSid, string channelSid, string sid, string body)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Sid = sid;
            Body = body;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            return p;
        }
    }

}
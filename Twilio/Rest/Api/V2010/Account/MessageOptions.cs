using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CreateMessageOptions : IOptions<MessageResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber To { get; }
        public Types.PhoneNumber From { get; set; }
        public string MessagingServiceSid { get; set; }
        public string Body { get; set; }
        public List<Uri> MediaUrl { get; set; }
        public Uri StatusCallback { get; set; }
        public string ApplicationSid { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? ProvideFeedback { get; set; }
    
        /// <summary>
        /// Construct a new CreateMessageOptions
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        public CreateMessageOptions(Types.PhoneNumber to)
        {
            To = to;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            
            if (MessagingServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid));
            }
            
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            
            if (MediaUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaUrl", MediaUrl.ToString()));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (ApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ApplicationSid", ApplicationSid));
            }
            
            if (MaxPrice != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxPrice", MaxPrice.ToString()));
            }
            
            if (ProvideFeedback != null)
            {
                p.Add(new KeyValuePair<string, string>("ProvideFeedback", ProvideFeedback.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteMessageOptions : IOptions<MessageResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteMessageOptions
        /// </summary>
        ///
        /// <param name="sid"> The message to delete </param>
        public DeleteMessageOptions(string sid)
        {
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

    public class FetchMessageOptions : IOptions<MessageResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchMessageOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique message Sid </param>
        public FetchMessageOptions(string sid)
        {
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

    public class ReadMessageOptions : ReadOptions<MessageResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber To { get; set; }
        public Types.PhoneNumber From { get; set; }
        public string DateSent { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            
            if (DateSent != null)
            {
                p.Add(new KeyValuePair<string, string>("DateSent", DateSent));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateMessageOptions : IOptions<MessageResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string Body { get; }
    
        /// <summary>
        /// Construct a new UpdateMessageOptions
        /// </summary>
        ///
        /// <param name="sid"> The message to redact </param>
        /// <param name="body"> The body </param>
        public UpdateMessageOptions(string sid, string body)
        {
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
            
            return p;
        }
    }

}
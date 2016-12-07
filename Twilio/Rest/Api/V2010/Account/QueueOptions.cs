using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchQueueOptions : IOptions<QueueResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchQueueOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique queue Sid </param>
        public FetchQueueOptions(string sid)
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

    public class UpdateQueueOptions : IOptions<QueueResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public int? MaxSize { get; set; }
    
        /// <summary>
        /// Construct a new UpdateQueueOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateQueueOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (MaxSize != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteQueueOptions : IOptions<QueueResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteQueueOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique queue Sid </param>
        public DeleteQueueOptions(string sid)
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

    public class ReadQueueOptions : ReadOptions<QueueResource> 
    {
        public string AccountSid { get; set; }
    
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

    public class CreateQueueOptions : IOptions<QueueResource> 
    {
        public string AccountSid { get; set; }
        public string FriendlyName { get; }
        public int? MaxSize { get; set; }
    
        /// <summary>
        /// Construct a new CreateQueueOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> A user-provided string that identifies this queue. </param>
        public CreateQueueOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (MaxSize != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.ToString()));
            }
            
            return p;
        }
    }

}
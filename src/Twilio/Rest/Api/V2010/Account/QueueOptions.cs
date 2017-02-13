using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchQueueOptions : IOptions<QueueResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Fetch by unique queue Sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// A human readable description of the queue
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The max number of members allowed in the queue
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.Value.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteQueueOptions : IOptions<QueueResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Delete by unique queue Sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
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
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// A user-provided string that identifies this queue.
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The max number of calls allowed in the queue
        /// </summary>
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
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.Value.ToString()));
            }
            
            return p;
        }
    }

}
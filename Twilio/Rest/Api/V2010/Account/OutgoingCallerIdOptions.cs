using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchOutgoingCallerIdOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique outgoing-caller-id Sid </param>
        public FetchOutgoingCallerIdOptions(string sid)
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

    public class UpdateOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateOutgoingCallerIdOptions
        /// </summary>
        ///
        /// <param name="sid"> Update by unique outgoing-caller-id Sid </param>
        public UpdateOutgoingCallerIdOptions(string sid)
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
            
            return p;
        }
    }

    public class DeleteOutgoingCallerIdOptions : IOptions<OutgoingCallerIdResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteOutgoingCallerIdOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique outgoing-caller-id Sid </param>
        public DeleteOutgoingCallerIdOptions(string sid)
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

    public class ReadOutgoingCallerIdOptions : ReadOptions<OutgoingCallerIdResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber PhoneNumber { get; set; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PhoneNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumber", PhoneNumber.ToString()));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
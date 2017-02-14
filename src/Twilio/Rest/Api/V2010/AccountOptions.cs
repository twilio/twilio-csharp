using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010 
{

    public class CreateAccountOptions : IOptions<AccountResource> 
    {
        /// <summary>
        /// A human readable description of the account
        /// </summary>
        public string FriendlyName { get; set; }
    
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

    public class FetchAccountOptions : IOptions<AccountResource> 
    {
        /// <summary>
        /// Fetch by unique Account Sid
        /// </summary>
        public string Sid { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class ReadAccountOptions : ReadOptions<AccountResource> 
    {
        /// <summary>
        /// FriendlyName to filter on
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Status to filter on
        /// </summary>
        public AccountResource.StatusEnum Status { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateAccountOptions : IOptions<AccountResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// FriendlyName to update
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Status to update the Account with
        /// </summary>
        public AccountResource.StatusEnum Status { get; set; }
    
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
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            return p;
        }
    }

}
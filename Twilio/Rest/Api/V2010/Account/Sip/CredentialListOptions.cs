using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class ReadCredentialListOptions : ReadOptions<CredentialListResource> 
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

    public class CreateCredentialListOptions : IOptions<CredentialListResource> 
    {
        public string AccountSid { get; set; }
        public string FriendlyName { get; }
    
        /// <summary>
        /// Construct a new CreateCredentialListOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateCredentialListOptions(string friendlyName)
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
            
            return p;
        }
    }

    public class FetchCredentialListOptions : IOptions<CredentialListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchCredentialListOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique credential Sid </param>
        public FetchCredentialListOptions(string sid)
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

    public class UpdateCredentialListOptions : IOptions<CredentialListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string FriendlyName { get; }
    
        /// <summary>
        /// Construct a new UpdateCredentialListOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public UpdateCredentialListOptions(string sid, string friendlyName)
        {
            Sid = sid;
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
            
            return p;
        }
    }

    public class DeleteCredentialListOptions : IOptions<CredentialListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteCredentialListOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique credential Sid </param>
        public DeleteCredentialListOptions(string sid)
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

}
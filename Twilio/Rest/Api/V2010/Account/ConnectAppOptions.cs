using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchConnectAppOptions : IOptions<ConnectAppResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchConnectAppOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique connect-app Sid </param>
        public FetchConnectAppOptions(string sid)
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

    public class UpdateConnectAppOptions : IOptions<ConnectAppResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public Uri AuthorizeRedirectUrl { get; set; }
        public string CompanyName { get; set; }
        public Twilio.Http.HttpMethod DeauthorizeCallbackMethod { get; set; }
        public Uri DeauthorizeCallbackUrl { get; set; }
        public string Description { get; set; }
        public string FriendlyName { get; set; }
        public Uri HomepageUrl { get; set; }
        public List<ConnectAppResource.PermissionEnum> Permissions { get; set; }
    
        /// <summary>
        /// Construct a new UpdateConnectAppOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateConnectAppOptions(string sid)
        {
            Sid = sid;
            Permissions = new List<ConnectAppResource.PermissionEnum>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (AuthorizeRedirectUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("AuthorizeRedirectUrl", AuthorizeRedirectUrl.ToString()));
            }
            
            if (CompanyName != null)
            {
                p.Add(new KeyValuePair<string, string>("CompanyName", CompanyName));
            }
            
            if (DeauthorizeCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("DeauthorizeCallbackMethod", DeauthorizeCallbackMethod.ToString()));
            }
            
            if (DeauthorizeCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("DeauthorizeCallbackUrl", DeauthorizeCallbackUrl.ToString()));
            }
            
            if (Description != null)
            {
                p.Add(new KeyValuePair<string, string>("Description", Description));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (HomepageUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("HomepageUrl", HomepageUrl.ToString()));
            }
            
            if (Permissions != null)
            {
                p.AddRange(Permissions.Select(prop => new KeyValuePair<string, string>("Permissions", prop.ToString())));
            }
            
            return p;
        }
    }

    public class ReadConnectAppOptions : ReadOptions<ConnectAppResource> 
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

}
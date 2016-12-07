using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class ReadDomainOptions : ReadOptions<DomainResource> 
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

    public class CreateDomainOptions : IOptions<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string DomainName { get; }
        public string FriendlyName { get; set; }
        public string AuthType { get; set; }
        public Uri VoiceUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceStatusCallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceStatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new CreateDomainOptions
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        public CreateDomainOptions(string domainName)
        {
            DomainName = domainName;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DomainName != null)
            {
                p.Add(new KeyValuePair<string, string>("DomainName", DomainName));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (AuthType != null)
            {
                p.Add(new KeyValuePair<string, string>("AuthType", AuthType));
            }
            
            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", VoiceUrl.ToString()));
            }
            
            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }
            
            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", VoiceFallbackUrl.ToString()));
            }
            
            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }
            
            if (VoiceStatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceStatusCallbackUrl", VoiceStatusCallbackUrl.ToString()));
            }
            
            if (VoiceStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceStatusCallbackMethod", VoiceStatusCallbackMethod.ToString()));
            }
            
            return p;
        }
    }

    public class FetchDomainOptions : IOptions<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchDomainOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Domain Sid </param>
        public FetchDomainOptions(string sid)
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

    public class UpdateDomainOptions : IOptions<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string AuthType { get; set; }
        public string FriendlyName { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Twilio.Http.HttpMethod VoiceStatusCallbackMethod { get; set; }
        public Uri VoiceStatusCallbackUrl { get; set; }
        public Uri VoiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new UpdateDomainOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateDomainOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (AuthType != null)
            {
                p.Add(new KeyValuePair<string, string>("AuthType", AuthType));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (VoiceFallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackMethod", VoiceFallbackMethod.ToString()));
            }
            
            if (VoiceFallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceFallbackUrl", VoiceFallbackUrl.ToString()));
            }
            
            if (VoiceMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceMethod", VoiceMethod.ToString()));
            }
            
            if (VoiceStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceStatusCallbackMethod", VoiceStatusCallbackMethod.ToString()));
            }
            
            if (VoiceStatusCallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceStatusCallbackUrl", VoiceStatusCallbackUrl.ToString()));
            }
            
            if (VoiceUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceUrl", VoiceUrl.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteDomainOptions : IOptions<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteDomainOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteDomainOptions(string sid)
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
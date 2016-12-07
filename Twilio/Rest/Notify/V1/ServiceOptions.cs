using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Notify.V1 
{

    public class CreateServiceOptions : IOptions<ServiceResource> 
    {
        public string FriendlyName { get; set; }
        public string ApnCredentialSid { get; set; }
        public string GcmCredentialSid { get; set; }
        public string MessagingServiceSid { get; set; }
        public string FacebookMessengerPageId { get; set; }
        public string DefaultApnNotificationProtocolVersion { get; set; }
        public string DefaultGcmNotificationProtocolVersion { get; set; }
    
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
            
            if (ApnCredentialSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ApnCredentialSid", ApnCredentialSid));
            }
            
            if (GcmCredentialSid != null)
            {
                p.Add(new KeyValuePair<string, string>("GcmCredentialSid", GcmCredentialSid));
            }
            
            if (MessagingServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid));
            }
            
            if (FacebookMessengerPageId != null)
            {
                p.Add(new KeyValuePair<string, string>("FacebookMessengerPageId", FacebookMessengerPageId));
            }
            
            if (DefaultApnNotificationProtocolVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultApnNotificationProtocolVersion", DefaultApnNotificationProtocolVersion));
            }
            
            if (DefaultGcmNotificationProtocolVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultGcmNotificationProtocolVersion", DefaultGcmNotificationProtocolVersion));
            }
            
            return p;
        }
    }

    public class DeleteServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteServiceOptions(string sid)
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

    public class FetchServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchServiceOptions(string sid)
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

    public class ReadServiceOptions : ReadOptions<ServiceResource> 
    {
        public string FriendlyName { get; set; }
    
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
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateServiceOptions : IOptions<ServiceResource> 
    {
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string ApnCredentialSid { get; set; }
        public string GcmCredentialSid { get; set; }
        public string MessagingServiceSid { get; set; }
        public string FacebookMessengerPageId { get; set; }
        public string DefaultApnNotificationProtocolVersion { get; set; }
        public string DefaultGcmNotificationProtocolVersion { get; set; }
    
        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateServiceOptions(string sid)
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
            
            if (ApnCredentialSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ApnCredentialSid", ApnCredentialSid));
            }
            
            if (GcmCredentialSid != null)
            {
                p.Add(new KeyValuePair<string, string>("GcmCredentialSid", GcmCredentialSid));
            }
            
            if (MessagingServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid));
            }
            
            if (FacebookMessengerPageId != null)
            {
                p.Add(new KeyValuePair<string, string>("FacebookMessengerPageId", FacebookMessengerPageId));
            }
            
            if (DefaultApnNotificationProtocolVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultApnNotificationProtocolVersion", DefaultApnNotificationProtocolVersion));
            }
            
            if (DefaultGcmNotificationProtocolVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("DefaultGcmNotificationProtocolVersion", DefaultGcmNotificationProtocolVersion));
            }
            
            return p;
        }
    }

}
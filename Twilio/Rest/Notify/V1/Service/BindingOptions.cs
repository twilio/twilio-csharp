using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Notify.V1.Service 
{

    public class FetchBindingOptions : IOptions<BindingResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchBindingOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchBindingOptions(string serviceSid, string sid)
        {
            ServiceSid = serviceSid;
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

    public class DeleteBindingOptions : IOptions<BindingResource> 
    {
        public string ServiceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteBindingOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteBindingOptions(string serviceSid, string sid)
        {
            ServiceSid = serviceSid;
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

    public class CreateBindingOptions : IOptions<BindingResource> 
    {
        public string ServiceSid { get; }
        public string Endpoint { get; }
        public string Identity { get; }
        public BindingResource.BindingTypeEnum BindingType { get; }
        public string Address { get; }
        public List<string> Tag { get; set; }
        public string NotificationProtocolVersion { get; set; }
        public string CredentialSid { get; set; }
    
        /// <summary>
        /// Construct a new CreateBindingOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        public CreateBindingOptions(string serviceSid, string endpoint, string identity, BindingResource.BindingTypeEnum bindingType, string address)
        {
            ServiceSid = serviceSid;
            Endpoint = endpoint;
            Identity = identity;
            BindingType = bindingType;
            Address = address;
            Tag = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Endpoint != null)
            {
                p.Add(new KeyValuePair<string, string>("Endpoint", Endpoint));
            }
            
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            
            if (BindingType != null)
            {
                p.Add(new KeyValuePair<string, string>("BindingType", BindingType.ToString()));
            }
            
            if (Address != null)
            {
                p.Add(new KeyValuePair<string, string>("Address", Address));
            }
            
            if (Tag != null)
            {
                p.AddRange(Tag.Select(prop => new KeyValuePair<string, string>("Tag", prop)));
            }
            
            if (NotificationProtocolVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("NotificationProtocolVersion", NotificationProtocolVersion));
            }
            
            if (CredentialSid != null)
            {
                p.Add(new KeyValuePair<string, string>("CredentialSid", CredentialSid.ToString()));
            }
            
            return p;
        }
    }

    public class ReadBindingOptions : ReadOptions<BindingResource> 
    {
        public string ServiceSid { get; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string> Identity { get; set; }
        public List<string> Tag { get; set; }
    
        /// <summary>
        /// Construct a new ReadBindingOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadBindingOptions(string serviceSid)
        {
            ServiceSid = serviceSid;
            Identity = new List<string>();
            Tag = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }
            
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss")));
            }
            
            if (Identity != null)
            {
                p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop)));
            }
            
            if (Tag != null)
            {
                p.AddRange(Tag.Select(prop => new KeyValuePair<string, string>("Tag", prop)));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}
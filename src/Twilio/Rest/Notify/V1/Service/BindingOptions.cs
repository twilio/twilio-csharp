using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Notify.V1.Service 
{

    /// <summary>
    /// FetchBindingOptions
    /// </summary>
    public class FetchBindingOptions : IOptions<BindingResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchBindingOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchBindingOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
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

    /// <summary>
    /// DeleteBindingOptions
    /// </summary>
    public class DeleteBindingOptions : IOptions<BindingResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteBindingOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> The sid </param>
        public DeleteBindingOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
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

    /// <summary>
    /// CreateBindingOptions
    /// </summary>
    public class CreateBindingOptions : IOptions<BindingResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The endpoint
        /// </summary>
        public string Endpoint { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// The binding_type
        /// </summary>
        public BindingResource.BindingTypeEnum BindingType { get; }
        /// <summary>
        /// The address
        /// </summary>
        public string Address { get; }
        /// <summary>
        /// The tag
        /// </summary>
        public List<string> Tag { get; set; }
        /// <summary>
        /// The notification_protocol_version
        /// </summary>
        public string NotificationProtocolVersion { get; set; }
        /// <summary>
        /// The credential_sid
        /// </summary>
        public string CredentialSid { get; set; }

        /// <summary>
        /// Construct a new CreateBindingOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="endpoint"> The endpoint </param>
        /// <param name="identity"> The identity </param>
        /// <param name="bindingType"> The binding_type </param>
        /// <param name="address"> The address </param>
        public CreateBindingOptions(string pathServiceSid, string endpoint, string identity, BindingResource.BindingTypeEnum bindingType, string address)
        {
            PathServiceSid = pathServiceSid;
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

    /// <summary>
    /// ReadBindingOptions
    /// </summary>
    public class ReadBindingOptions : ReadOptions<BindingResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The start_date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// The end_date
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// The identity
        /// </summary>
        public List<string> Identity { get; set; }
        /// <summary>
        /// The tag
        /// </summary>
        public List<string> Tag { get; set; }

        /// <summary>
        /// Construct a new ReadBindingOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        public ReadBindingOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd")));
            }

            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd")));
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
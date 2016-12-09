using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class FetchRoleOptions : IOptions<RoleResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchRoleOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchRoleOptions(string serviceSid, string sid)
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

    public class DeleteRoleOptions : IOptions<RoleResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteRoleOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteRoleOptions(string serviceSid, string sid)
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

    public class CreateRoleOptions : IOptions<RoleResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The type
        /// </summary>
        public RoleResource.RoleTypeEnum Type { get; }
        /// <summary>
        /// The permission
        /// </summary>
        public List<string> Permission { get; }
    
        /// <summary>
        /// Construct a new CreateRoleOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="type"> The type </param>
        /// <param name="permission"> The permission </param>
        public CreateRoleOptions(string serviceSid, string friendlyName, RoleResource.RoleTypeEnum type, List<string> permission)
        {
            ServiceSid = serviceSid;
            FriendlyName = friendlyName;
            Type = type;
            Permission = permission;
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
            
            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            
            if (Permission != null)
            {
                p.AddRange(Permission.Select(prop => new KeyValuePair<string, string>("Permission", prop)));
            }
            
            return p;
        }
    }

    public class ReadRoleOptions : ReadOptions<RoleResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
    
        /// <summary>
        /// Construct a new ReadRoleOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadRoleOptions(string serviceSid)
        {
            ServiceSid = serviceSid;
        }
    
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

    public class UpdateRoleOptions : IOptions<RoleResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The permission
        /// </summary>
        public List<string> Permission { get; }
    
        /// <summary>
        /// Construct a new UpdateRoleOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="permission"> The permission </param>
        public UpdateRoleOptions(string serviceSid, string sid, List<string> permission)
        {
            ServiceSid = serviceSid;
            Sid = sid;
            Permission = permission;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Permission != null)
            {
                p.AddRange(Permission.Select(prop => new KeyValuePair<string, string>("Permission", prop)));
            }
            
            return p;
        }
    }

}
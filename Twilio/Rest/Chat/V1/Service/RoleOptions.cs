using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Chat.V1.Service 
{

    public class FetchRoleOptions : IOptions<RoleResource> 
    {
        public string ServiceSid { get; }
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
        public string ServiceSid { get; }
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
        public string ServiceSid { get; }
        public string FriendlyName { get; }
        public RoleResource.RoleTypeEnum Type { get; }
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
                p.Add(new KeyValuePair<string, string>("Permission", Permission.ToString()));
            }
            
            return p;
        }
    }

    public class ReadRoleOptions : ReadOptions<RoleResource> 
    {
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
        public string ServiceSid { get; }
        public string Sid { get; }
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
                p.Add(new KeyValuePair<string, string>("Permission", Permission.ToString()));
            }
            
            return p;
        }
    }

}
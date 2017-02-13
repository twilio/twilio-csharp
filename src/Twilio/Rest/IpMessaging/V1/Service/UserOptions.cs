using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class FetchUserOptions : IOptions<UserResource> 
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
        /// Construct a new FetchUserOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchUserOptions(string serviceSid, string sid)
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

    public class DeleteUserOptions : IOptions<UserResource> 
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
        /// Construct a new DeleteUserOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteUserOptions(string serviceSid, string sid)
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

    public class CreateUserOptions : IOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// The role_sid
        /// </summary>
        public string RoleSid { get; set; }
        /// <summary>
        /// The attributes
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new CreateUserOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        public CreateUserOptions(string serviceSid, string identity)
        {
            ServiceSid = serviceSid;
            Identity = identity;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

    public class ReadUserOptions : ReadOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
    
        /// <summary>
        /// Construct a new ReadUserOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ReadUserOptions(string serviceSid)
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

    public class UpdateUserOptions : IOptions<UserResource> 
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
        /// The role_sid
        /// </summary>
        public string RoleSid { get; set; }
        /// <summary>
        /// The attributes
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateUserOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateUserOptions(string serviceSid, string sid)
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
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }
            
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

}
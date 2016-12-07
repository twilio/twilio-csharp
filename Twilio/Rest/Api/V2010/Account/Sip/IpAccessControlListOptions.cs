using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class ReadIpAccessControlListOptions : ReadOptions<IpAccessControlListResource> 
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

    public class CreateIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string AccountSid { get; set; }
        public string FriendlyName { get; }
    
        /// <summary>
        /// Construct a new CreateIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        public CreateIpAccessControlListOptions(string friendlyName)
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

    public class FetchIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique ip-access-control-list Sid </param>
        public FetchIpAccessControlListOptions(string sid)
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

    public class UpdateIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string FriendlyName { get; }
    
        /// <summary>
        /// Construct a new UpdateIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        public UpdateIpAccessControlListOptions(string sid, string friendlyName)
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

    public class DeleteIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique ip-access-control-list Sid </param>
        public DeleteIpAccessControlListOptions(string sid)
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
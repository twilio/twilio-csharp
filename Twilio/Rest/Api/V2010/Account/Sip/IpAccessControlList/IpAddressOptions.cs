using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList 
{

    public class ReadIpAddressOptions : ReadOptions<IpAddressResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ip_access_control_list_sid
        /// </summary>
        public string IpAccessControlListSid { get; }
    
        /// <summary>
        /// Construct a new ReadIpAddressOptions
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        public ReadIpAddressOptions(string ipAccessControlListSid)
        {
            IpAccessControlListSid = ipAccessControlListSid;
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

    public class CreateIpAddressOptions : IOptions<IpAddressResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ip_access_control_list_sid
        /// </summary>
        public string IpAccessControlListSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The ip_address
        /// </summary>
        public string IpAddress { get; }
    
        /// <summary>
        /// Construct a new CreateIpAddressOptions
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ipAddress"> The ip_address </param>
        public CreateIpAddressOptions(string ipAccessControlListSid, string friendlyName, string ipAddress)
        {
            IpAccessControlListSid = ipAccessControlListSid;
            FriendlyName = friendlyName;
            IpAddress = ipAddress;
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
            
            if (IpAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("IpAddress", IpAddress));
            }
            
            return p;
        }
    }

    public class FetchIpAddressOptions : IOptions<IpAddressResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ip_access_control_list_sid
        /// </summary>
        public string IpAccessControlListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchIpAddressOptions
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchIpAddressOptions(string ipAccessControlListSid, string sid)
        {
            IpAccessControlListSid = ipAccessControlListSid;
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

    public class UpdateIpAddressOptions : IOptions<IpAddressResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ip_access_control_list_sid
        /// </summary>
        public string IpAccessControlListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The ip_address
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new UpdateIpAddressOptions
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateIpAddressOptions(string ipAccessControlListSid, string sid)
        {
            IpAccessControlListSid = ipAccessControlListSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (IpAddress != null)
            {
                p.Add(new KeyValuePair<string, string>("IpAddress", IpAddress));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            return p;
        }
    }

    public class DeleteIpAddressOptions : IOptions<IpAddressResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The ip_access_control_list_sid
        /// </summary>
        public string IpAccessControlListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteIpAddressOptions
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteIpAddressOptions(string ipAccessControlListSid, string sid)
        {
            IpAccessControlListSid = ipAccessControlListSid;
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
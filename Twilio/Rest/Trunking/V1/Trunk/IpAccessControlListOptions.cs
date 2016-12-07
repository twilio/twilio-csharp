using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class FetchIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchIpAccessControlListOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
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

    public class DeleteIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteIpAccessControlListOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
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

    public class CreateIpAccessControlListOptions : IOptions<IpAccessControlListResource> 
    {
        public string TrunkSid { get; }
        public string IpAccessControlListSid { get; }
    
        /// <summary>
        /// Construct a new CreateIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        public CreateIpAccessControlListOptions(string trunkSid, string ipAccessControlListSid)
        {
            TrunkSid = trunkSid;
            IpAccessControlListSid = ipAccessControlListSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (IpAccessControlListSid != null)
            {
                p.Add(new KeyValuePair<string, string>("IpAccessControlListSid", IpAccessControlListSid));
            }
            
            return p;
        }
    }

    public class ReadIpAccessControlListOptions : ReadOptions<IpAccessControlListResource> 
    {
        public string TrunkSid { get; }
    
        /// <summary>
        /// Construct a new ReadIpAccessControlListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        public ReadIpAccessControlListOptions(string trunkSid)
        {
            TrunkSid = trunkSid;
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

}
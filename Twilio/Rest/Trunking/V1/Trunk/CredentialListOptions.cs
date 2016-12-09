using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class FetchCredentialListOptions : IOptions<CredentialListResource> 
    {
        /// <summary>
        /// The trunk_sid
        /// </summary>
        public string TrunkSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchCredentialListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchCredentialListOptions(string trunkSid, string sid)
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

    public class DeleteCredentialListOptions : IOptions<CredentialListResource> 
    {
        /// <summary>
        /// The trunk_sid
        /// </summary>
        public string TrunkSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteCredentialListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteCredentialListOptions(string trunkSid, string sid)
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

    public class CreateCredentialListOptions : IOptions<CredentialListResource> 
    {
        /// <summary>
        /// The trunk_sid
        /// </summary>
        public string TrunkSid { get; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
    
        /// <summary>
        /// Construct a new CreateCredentialListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="credentialListSid"> The credential_list_sid </param>
        public CreateCredentialListOptions(string trunkSid, string credentialListSid)
        {
            TrunkSid = trunkSid;
            CredentialListSid = credentialListSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CredentialListSid != null)
            {
                p.Add(new KeyValuePair<string, string>("CredentialListSid", CredentialListSid.ToString()));
            }
            
            return p;
        }
    }

    public class ReadCredentialListOptions : ReadOptions<CredentialListResource> 
    {
        /// <summary>
        /// The trunk_sid
        /// </summary>
        public string TrunkSid { get; }
    
        /// <summary>
        /// Construct a new ReadCredentialListOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        public ReadCredentialListOptions(string trunkSid)
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
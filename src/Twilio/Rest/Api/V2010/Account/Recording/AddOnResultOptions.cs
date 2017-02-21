using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Recording 
{

    /// <summary>
    /// Fetch an instance of an Add-on result
    /// </summary>
    public class FetchAddOnResultOptions : IOptions<AddOnResultResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
        /// <summary>
        /// Fetch by unique result Sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new FetchAddOnResultOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        /// <param name="sid"> Fetch by unique result Sid </param>
        public FetchAddOnResultOptions(string referenceSid, string sid)
        {
            PathReferenceSid = referenceSid;
            PathSid = sid;
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
    /// Retrieve a list of results belonging to the recording
    /// </summary>
    public class ReadAddOnResultOptions : ReadOptions<AddOnResultResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
    
        /// <summary>
        /// Construct a new ReadAddOnResultOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        public ReadAddOnResultOptions(string referenceSid)
        {
            PathReferenceSid = referenceSid;
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

    /// <summary>
    /// Delete a result and purge all associated Payloads
    /// </summary>
    public class DeleteAddOnResultOptions : IOptions<AddOnResultResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The reference_sid
        /// </summary>
        public string PathReferenceSid { get; }
        /// <summary>
        /// Delete by unique result Sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new DeleteAddOnResultOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        /// <param name="sid"> Delete by unique result Sid </param>
        public DeleteAddOnResultOptions(string referenceSid, string sid)
        {
            PathReferenceSid = referenceSid;
            PathSid = sid;
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
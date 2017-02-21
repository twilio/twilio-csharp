using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Recording.AddOnResult 
{

    /// <summary>
    /// Fetch an instance of a result payload
    /// </summary>
    public class FetchPayloadOptions : IOptions<PayloadResource> 
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
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }
        /// <summary>
        /// Fetch by unique payload Sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new FetchPayloadOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        /// <param name="addOnResultSid"> The add_on_result_sid </param>
        /// <param name="sid"> Fetch by unique payload Sid </param>
        public FetchPayloadOptions(string referenceSid, string addOnResultSid, string sid)
        {
            PathReferenceSid = referenceSid;
            PathAddOnResultSid = addOnResultSid;
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
    /// Retrieve a list of payloads belonging to the Add-on result
    /// </summary>
    public class ReadPayloadOptions : ReadOptions<PayloadResource> 
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
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }
    
        /// <summary>
        /// Construct a new ReadPayloadOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        /// <param name="addOnResultSid"> The add_on_result_sid </param>
        public ReadPayloadOptions(string referenceSid, string addOnResultSid)
        {
            PathReferenceSid = referenceSid;
            PathAddOnResultSid = addOnResultSid;
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
    /// Delete a payload from the result along with all associated Data
    /// </summary>
    public class DeletePayloadOptions : IOptions<PayloadResource> 
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
        /// The add_on_result_sid
        /// </summary>
        public string PathAddOnResultSid { get; }
        /// <summary>
        /// Delete by unique payload Sid
        /// </summary>
        public string PathSid { get; }
    
        /// <summary>
        /// Construct a new DeletePayloadOptions
        /// </summary>
        ///
        /// <param name="referenceSid"> The reference_sid </param>
        /// <param name="addOnResultSid"> The add_on_result_sid </param>
        /// <param name="sid"> Delete by unique payload Sid </param>
        public DeletePayloadOptions(string referenceSid, string addOnResultSid, string sid)
        {
            PathReferenceSid = referenceSid;
            PathAddOnResultSid = addOnResultSid;
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
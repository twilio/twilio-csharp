using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Recording 
{

    /// <summary>
    /// FetchTranscriptionOptions
    /// </summary>
    public class FetchTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The recording_sid
        /// </summary>
        public string RecordingSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTranscriptionOptions
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchTranscriptionOptions(string recordingSid, string sid)
        {
            RecordingSid = recordingSid;
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

    /// <summary>
    /// DeleteTranscriptionOptions
    /// </summary>
    public class DeleteTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The recording_sid
        /// </summary>
        public string RecordingSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTranscriptionOptions
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteTranscriptionOptions(string recordingSid, string sid)
        {
            RecordingSid = recordingSid;
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

    /// <summary>
    /// ReadTranscriptionOptions
    /// </summary>
    public class ReadTranscriptionOptions : ReadOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The recording_sid
        /// </summary>
        public string RecordingSid { get; }
    
        /// <summary>
        /// Construct a new ReadTranscriptionOptions
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        public ReadTranscriptionOptions(string recordingSid)
        {
            RecordingSid = recordingSid;
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
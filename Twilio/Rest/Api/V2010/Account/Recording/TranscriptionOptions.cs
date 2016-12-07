using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Recording 
{

    public class FetchTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        public string AccountSid { get; set; }
        public string RecordingSid { get; }
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

    public class DeleteTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        public string AccountSid { get; set; }
        public string RecordingSid { get; }
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

    public class ReadTranscriptionOptions : ReadOptions<TranscriptionResource> 
    {
        public string AccountSid { get; set; }
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
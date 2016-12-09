using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class FetchTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Fetch by unique transcription Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTranscriptionOptions
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique transcription Sid </param>
        public FetchTranscriptionOptions(string sid)
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

    public class DeleteTranscriptionOptions : IOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// Delete by unique transcription Sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTranscriptionOptions
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique transcription Sid </param>
        public DeleteTranscriptionOptions(string sid)
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

    public class ReadTranscriptionOptions : ReadOptions<TranscriptionResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
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

}
using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Video.V1 
{

    /// <summary>
    /// FetchRecordingOptions
    /// </summary>
    public class FetchRecordingOptions : IOptions<RecordingResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchRecordingOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchRecordingOptions(string pathSid)
        {
            PathSid = pathSid;
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
    /// ReadRecordingOptions
    /// </summary>
    public class ReadRecordingOptions : ReadOptions<RecordingResource> 
    {
        /// <summary>
        /// The status
        /// </summary>
        public RecordingResource.StatusEnum Status { get; set; }
        /// <summary>
        /// The source_sid
        /// </summary>
        public string SourceSid { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }

            if (SourceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SourceSid", SourceSid.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// DeleteRecordingOptions
    /// </summary>
    public class DeleteRecordingOptions : IOptions<RecordingResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteRecordingOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public DeleteRecordingOptions(string pathSid)
        {
            PathSid = pathSid;
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
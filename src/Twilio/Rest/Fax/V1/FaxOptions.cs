using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Fax.V1 
{

    /// <summary>
    /// FetchFaxOptions
    /// </summary>
    public class FetchFaxOptions : IOptions<FaxResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchFaxOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchFaxOptions(string pathSid)
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
    /// ReadFaxOptions
    /// </summary>
    public class ReadFaxOptions : ReadOptions<FaxResource> 
    {
        /// <summary>
        /// The from
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// The to
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// CreateFaxOptions
    /// </summary>
    public class CreateFaxOptions : IOptions<FaxResource> 
    {
        /// <summary>
        /// The from
        /// </summary>
        public string From { get; }
        /// <summary>
        /// The to
        /// </summary>
        public string To { get; }
        /// <summary>
        /// The media_url
        /// </summary>
        public Uri MediaUrl { get; }
        /// <summary>
        /// The quality
        /// </summary>
        public FaxResource.QualityEnum Quality { get; set; }
        /// <summary>
        /// The status_callback
        /// </summary>
        public Uri StatusCallback { get; set; }

        /// <summary>
        /// Construct a new CreateFaxOptions
        /// </summary>
        ///
        /// <param name="from"> The from </param>
        /// <param name="to"> The to </param>
        /// <param name="mediaUrl"> The media_url </param>
        public CreateFaxOptions(string from, string to, Uri mediaUrl)
        {
            From = from;
            To = to;
            MediaUrl = mediaUrl;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To));
            }

            if (MediaUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("MediaUrl", MediaUrl.ToString()));
            }

            if (Quality != null)
            {
                p.Add(new KeyValuePair<string, string>("Quality", Quality.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// UpdateFaxOptions
    /// </summary>
    public class UpdateFaxOptions : IOptions<FaxResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The status
        /// </summary>
        public FaxResource.UpdateStatusEnum Status { get; set; }

        /// <summary>
        /// Construct a new UpdateFaxOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateFaxOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }

            return p;
        }
    }

}
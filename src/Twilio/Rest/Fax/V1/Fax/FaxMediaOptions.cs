using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Fax.V1.Fax 
{

    /// <summary>
    /// FetchFaxMediaOptions
    /// </summary>
    public class FetchFaxMediaOptions : IOptions<FaxMediaResource> 
    {
        /// <summary>
        /// The fax_sid
        /// </summary>
        public string PathFaxSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        public FetchFaxMediaOptions(string pathFaxSid, string pathSid)
        {
            PathFaxSid = pathFaxSid;
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
    /// ReadFaxMediaOptions
    /// </summary>
    public class ReadFaxMediaOptions : ReadOptions<FaxMediaResource> 
    {
        /// <summary>
        /// The fax_sid
        /// </summary>
        public string PathFaxSid { get; }

        /// <summary>
        /// Construct a new ReadFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        public ReadFaxMediaOptions(string pathFaxSid)
        {
            PathFaxSid = pathFaxSid;
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
    /// DeleteFaxMediaOptions
    /// </summary>
    public class DeleteFaxMediaOptions : IOptions<FaxMediaResource> 
    {
        /// <summary>
        /// The fax_sid
        /// </summary>
        public string PathFaxSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> The fax_sid </param>
        /// <param name="pathSid"> The sid </param>
        public DeleteFaxMediaOptions(string pathFaxSid, string pathSid)
        {
            PathFaxSid = pathFaxSid;
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
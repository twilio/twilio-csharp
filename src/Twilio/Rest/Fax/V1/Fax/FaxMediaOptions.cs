using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Fax.V1.Fax 
{

    /// <summary>
    /// Fetch a specific fax media instance.
    /// </summary>
    public class FetchFaxMediaOptions : IOptions<FaxMediaResource> 
    {
        /// <summary>
        /// Fax SID
        /// </summary>
        public string PathFaxSid { get; }
        /// <summary>
        /// A string that uniquely identifies this fax media
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> Fax SID </param>
        /// <param name="pathSid"> A string that uniquely identifies this fax media </param>
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
    /// Retrieve a list of all fax media instances for the specified fax.
    /// </summary>
    public class ReadFaxMediaOptions : ReadOptions<FaxMediaResource> 
    {
        /// <summary>
        /// Fax SID
        /// </summary>
        public string PathFaxSid { get; }

        /// <summary>
        /// Construct a new ReadFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> Fax SID </param>
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
    /// Delete a specific fax media instance.
    /// </summary>
    public class DeleteFaxMediaOptions : IOptions<FaxMediaResource> 
    {
        /// <summary>
        /// Fax SID
        /// </summary>
        public string PathFaxSid { get; }
        /// <summary>
        /// A string that uniquely identifies this fax media
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteFaxMediaOptions
        /// </summary>
        ///
        /// <param name="pathFaxSid"> Fax SID </param>
        /// <param name="pathSid"> A string that uniquely identifies this fax media </param>
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
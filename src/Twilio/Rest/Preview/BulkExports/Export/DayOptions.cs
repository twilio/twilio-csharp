using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.BulkExports.Export 
{

    /// <summary>
    /// ReadDayOptions
    /// </summary>
    public class ReadDayOptions : ReadOptions<DayResource> 
    {
        /// <summary>
        /// The resource_type
        /// </summary>
        public string PathResourceType { get; }

        /// <summary>
        /// Construct a new ReadDayOptions
        /// </summary>
        ///
        /// <param name="pathResourceType"> The resource_type </param>
        public ReadDayOptions(string pathResourceType)
        {
            PathResourceType = pathResourceType;
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
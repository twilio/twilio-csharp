using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.BulkExports 
{

    /// <summary>
    /// FetchExportOptions
    /// </summary>
    public class FetchExportOptions : IOptions<ExportResource> 
    {
        /// <summary>
        /// The resource_type
        /// </summary>
        public string PathResourceType { get; }

        /// <summary>
        /// Construct a new FetchExportOptions
        /// </summary>
        ///
        /// <param name="pathResourceType"> The resource_type </param>
        public FetchExportOptions(string pathResourceType)
        {
            PathResourceType = pathResourceType;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Model
{
    public class ListMeta
    {
        /// <summary>
        /// The plural name of this resource collection
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Page number of this result page, counting from 0
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The size of this result page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// URL of the next page in this list
        /// </summary>
        public Uri NextPageUrl { get; set; }

        /// <summary>
        /// URL of the previous page in this list
        /// </summary>
        public Uri PreviousPageUrl { get; set; }

        /// <summary>
        /// URL of the first page in this list
        /// </summary>
        public Uri FirstPageUrl { get; set; }

        /// <summary>
        /// URL for this page
        /// </summary>
        public Uri Url { get; set; }
    }
}

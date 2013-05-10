using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public sealed class AccountResult
    {
        /// <summary>
        /// The current page number. Zero-indexed, so the first page is 0.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int NumPages { get; set; }
        /// <summary>
        /// How many items are in each page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// The total number of items in the list.
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The position in the overall list of the first item in this page.
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// The position in the overall list of the last item in this page.
        /// </summary>
        public int End { get; set; }
        /// <summary>
        /// The URI for the first page of this list.
        /// </summary>
        public Uri FirstPageUri { get; set; }
        /// <summary>
        /// The URI for the next page of this list.
        /// </summary>
        public Uri NextPageUri { get; set; }
        /// <summary>
        /// The URI for the previous page of this list.
        /// </summary>
        public Uri PreviousPageUri { get; set; }
        /// <summary>
        /// The URI for the last page of this list.
        /// </summary>
        public Uri LastPageUri { get; set; }


        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }
        /// <summary>
        /// The URI for this resource, relative to https://api.twilio.com
        /// </summary>
        public Uri Uri { get; set; }


        /// <summary>
        /// List of accounts returned by API
        /// </summary>
        public IList<Account> Accounts { get; set; }
    }
}

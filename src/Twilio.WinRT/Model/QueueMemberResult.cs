using System;
using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public sealed class QueueMemberResult //: TwilioListBase
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
        /// List of QueueMember instances returned by the API
        /// </summary>
        public IList<QueueMember> QueueMembers { get; set; }
    }
}

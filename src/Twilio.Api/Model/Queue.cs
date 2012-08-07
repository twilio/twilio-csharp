using System;

namespace Twilio
{
    /// <summary>
    /// An Queue instance resource
    /// </summary>
    public class Queue : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// A user provided string that identifies this queue.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// A count of the current number of calls in the Queue
        /// </summary>
        public int? CurrentSize { get; set; }

        /// <summary>
        /// The average (in seconds) that all calls in the queue have waited
        /// </summary>
        public int? AverageWaitTime { get; set; }

        /// <summary>
        /// The maximum number of calls allowed in this queue
        /// </summary>
        public int? MaxSize { get; set; }
        
        /// <summary>
		/// The date that this resource was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		
        /// <summary>
		/// The date that this resource was last updated, given as GMT 
		/// </summary>
		public DateTime DateUpdated { get; set; }
    }
}

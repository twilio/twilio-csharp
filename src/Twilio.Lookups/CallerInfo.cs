using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Lookups
{
    public class CallerInfo
    {
        /// <summary>
        /// String indicating the name of the owner of the phone number. If not available, this will return null.
        /// </summary>
        public string CallerName { get; set; }

        /// <summary>
        /// String indicating whether this caller is a business or consumer. Possible values are business, consumer. If not available, this will return unavailable.
        /// </summary>
        public string CallerType { get; set; }

        /// <summary>
        /// The error code, if any, associated with your request.
        /// </summary>
        public string ErrorCode { get; set; }
    }
}

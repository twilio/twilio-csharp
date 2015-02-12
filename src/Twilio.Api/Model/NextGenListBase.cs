using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Model
{
    public class NextGenListBase : TwilioBase
    {
        /// <summary>
        /// Metadata about this list resource representation.
        /// Includes resource name and paging information.
        /// </summary>
        public ListMeta Meta { get; set; }

    }
}

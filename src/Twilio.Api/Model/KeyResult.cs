using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class KeyResult : TwilioListBase
    {
        /// <summary>
        /// A list of Key instances returned by the API.
        /// </summary>
        public List<Key> Keys { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Trunking.Model
{
    public class OriginationUrlResult : NextGenListBase
    {
        /// <summary>
        /// List of OriginationUrls.
        /// </summary>
        public List<OriginationUrl> OriginationUrls { get; set; }
    }
}

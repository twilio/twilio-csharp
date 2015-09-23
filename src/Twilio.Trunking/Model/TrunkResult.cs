using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Trunking.Model
{
    public class TrunkResult : NextGenListBase
    {
        /// <summary>
        /// List of SIP Trunks.
        /// </summary>
        public List<Trunk> Trunks { get; set; }
    }
}

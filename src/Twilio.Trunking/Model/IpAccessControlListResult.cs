using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Trunking.Model
{
    public class IpAccessControlListResult : NextGenListBase
    {
        /// <summary>
        /// List of IpAccessControlLists.
        /// </summary>
        public List<IpAccessControlList> IpAccessControlLists { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Trunking.Model
{
    public class CredentialListResult : NextGenListBase
    {
        /// <summary>
        /// List of CredentialLists.
        /// </summary>
        public List<CredentialList> CredentialLists { get; set; }
    }
}

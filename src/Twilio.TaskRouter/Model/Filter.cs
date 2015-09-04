using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Twilio.TaskRouter
{
    [DataContract]
    public class Filter
    {
        public Filter()
        {
            this.Targets = new List<Target>();
        }

        [DataMember(EmitDefaultValue = false, Name="friendly_name")]
        public string FriendlyName { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "expression")]
        public string Expression { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "targets")]
        public List<Target> Targets { get; set; }
    }
}

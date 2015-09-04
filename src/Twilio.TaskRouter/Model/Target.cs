using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Twilio.TaskRouter
{
    [DataContract]
    public class Target
    {
        [DataMember(EmitDefaultValue = false, Name = "queue")]
        public string Queue { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "priority")]
        public string Priority { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "timeout")]
        public string Timeout { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "expression")]
        public string Expression { get; set; }
    }
}

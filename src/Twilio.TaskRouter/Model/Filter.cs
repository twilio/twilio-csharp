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
        private string filterFriendlyName; 

        public Filter()
        {
            this.Targets = new List<Target>();
        }
         
        [DataMember(EmitDefaultValue = false, Name="friendly_name")]
        public string FriendlyName { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "filter_friendly_name")]
        public string FilterFriendlyName {
            get {
                return filterFriendlyName;
            }
            set {
                FriendlyName = value;
                filterFriendlyName = FriendlyName;
            }
        }

        [DataMember(EmitDefaultValue = false, Name = "expression")]
        public string Expression { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "targets")]
        public List<Target> Targets { get; set; }

        [OnSerializing()]
        private void SetFilterFriendlyNameOnSerializing(StreamingContext context) {
            filterFriendlyName = null;
        }

        [OnSerialized()]
        private void SetFilterFriendlyNameOnSerialized(StreamingContext context) {
            filterFriendlyName = FriendlyName;
        }
    }
}

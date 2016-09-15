
namespace Twilio.Rest {
    public sealed class Domains {
        public const string API = "api";
        public const string CHAT = "ip-messaging";
        public const string IP_MESSAGING = "ip-messaging";
        public const string LOOKUPS = "lookups";
        public const string MONITOR = "monitor";
        public const string NOTIFY = "notify";
        public const string PREVIEW = "preview";
        public const string PRICING = "pricing";
        public const string TASKROUTER = "taskrouter";
        public const string TRUNKING = "trunking";
        
        private readonly string value;
        
        public Domains(string value) {
            this.value = value;
        }
        
        public override string ToString() {
            return value;
        }
        
        public static implicit operator Domains(string value) {
            return new Domains(value);
        }
        
        public static implicit operator string(Domains value) {
            return value.ToString();
        }
    }
}
using Twilio.Types;

namespace Twilio.Rest 
{

    public sealed class Domains : StringEnum 
    {
        private Domains(string value) : base(value) {}
        public Domains() {}
    
        public static Domains Api = new Domains("api");
        public static Domains Chat = new Domains("ip-messaging");
        public static Domains IpMessaging = new Domains("ip-messaging");
        public static Domains Lookups = new Domains("lookups");
        public static Domains Monitor = new Domains("monitor");
        public static Domains Notify = new Domains("notify");
        public static Domains Preview = new Domains("preview");
        public static Domains Pricing = new Domains("pricing");
        public static Domains Taskrouter = new Domains("taskrouter");
        public static Domains Trunking = new Domains("trunking");
    }
}
/*
* This code was generated by
* ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
*  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
*  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
*
* NOTE: This class is auto generated by OpenAPI Generator.
* https://openapi-generator.tech
* Do not edit the class manually.
*/
using Twilio.Types;

namespace Twilio.Rest
{

    public sealed class Domain : StringEnum
    {
        private Domain(string value) : base(value) {}
        public Domain() {}
        public static implicit operator Domain(string value)
        {
            return new Domain(value);
        }

        public static readonly Domain Accounts = new Domain("accounts");
        public static readonly Domain Api = new Domain("api");
        public static readonly Domain PreviewIam = new Domain("preview-iam");
        public static readonly Domain Assistants = new Domain("assistants");
        public static readonly Domain Bulkexports = new Domain("bulkexports");
        public static readonly Domain Chat = new Domain("chat");
        public static readonly Domain Content = new Domain("content");
        public static readonly Domain Conversations = new Domain("conversations");
        public static readonly Domain Events = new Domain("events");
        public static readonly Domain FlexApi = new Domain("flex-api");
        public static readonly Domain FrontlineApi = new Domain("frontline-api");
        public static readonly Domain Iam = new Domain("iam");
        public static readonly Domain Insights = new Domain("insights");
        public static readonly Domain Intelligence = new Domain("intelligence");
        public static readonly Domain IpMessaging = new Domain("ip-messaging");
        public static readonly Domain Lookups = new Domain("lookups");
        public static readonly Domain Marketplace = new Domain("marketplace");
        public static readonly Domain Messaging = new Domain("messaging");
        public static readonly Domain Microvisor = new Domain("microvisor");
        public static readonly Domain Monitor = new Domain("monitor");
        public static readonly Domain Notify = new Domain("notify");
        public static readonly Domain Numbers = new Domain("numbers");
        public static readonly Domain Oauth = new Domain("oauth");
        public static readonly Domain Preview = new Domain("preview");
        public static readonly Domain Pricing = new Domain("pricing");
        public static readonly Domain Proxy = new Domain("proxy");
        public static readonly Domain Routes = new Domain("routes");
        public static readonly Domain Serverless = new Domain("serverless");
        public static readonly Domain Studio = new Domain("studio");
        public static readonly Domain Supersim = new Domain("supersim");
        public static readonly Domain Sync = new Domain("sync");
        public static readonly Domain Taskrouter = new Domain("taskrouter");
        public static readonly Domain Trunking = new Domain("trunking");
        public static readonly Domain Trusthub = new Domain("trusthub");
        public static readonly Domain Verify = new Domain("verify");
        public static readonly Domain Video = new Domain("video");
        public static readonly Domain Voice = new Domain("voice");
        public static readonly Domain Wireless = new Domain("wireless");
    }

}

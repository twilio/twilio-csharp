using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Trunking.V1.Trunk;
using Twilio.Deleters.Trunking.V1.Trunk;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1.Trunk;
using Twilio.Http;
using Twilio.Readers.Trunking.V1.Trunk;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Trunking.V1.Trunk {

    public class IpAccessControlList : SidResource {
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return IpAccessControlListFetcher capable of executing the fetch
         */
        public static IpAccessControlListFetcher fetch(String trunkSid, String sid) {
            return new IpAccessControlListFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return IpAccessControlListDeleter capable of executing the delete
         */
        public static IpAccessControlListDeleter delete(String trunkSid, String sid) {
            return new IpAccessControlListDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAccessControlListCreator capable of executing the create
         */
        public static IpAccessControlListCreator create(String trunkSid, String ipAccessControlListSid) {
            return new IpAccessControlListCreator(trunkSid, ipAccessControlListSid);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return IpAccessControlListReader capable of executing the read
         */
        public static IpAccessControlListReader read(String trunkSid) {
            return new IpAccessControlListReader(trunkSid);
        }
    
        /**
         * Converts a JSON string into a IpAccessControlList object
         * 
         * @param json Raw JSON string
         * @return IpAccessControlList object represented by the provided JSON
         */
        public static IpAccessControlList fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAccessControlList>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("trunk_sid")]
        private readonly String trunkSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("url")]
        private readonly URI url;
    
        private IpAccessControlList([JsonProperty("account_sid")]
                                    String accountSid, 
                                    [JsonProperty("sid")]
                                    String sid, 
                                    [JsonProperty("trunk_sid")]
                                    String trunkSid, 
                                    [JsonProperty("friendly_name")]
                                    String friendlyName, 
                                    [JsonProperty("date_created")]
                                    String dateCreated, 
                                    [JsonProperty("date_updated")]
                                    String dateUpdated, 
                                    [JsonProperty("url")]
                                    URI url) {
            this.accountSid = accountSid;
            this.sid = sid;
            this.trunkSid = trunkSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.url = url;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The trunk_sid
         */
        public String GetTrunkSid() {
            return this.trunkSid;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}
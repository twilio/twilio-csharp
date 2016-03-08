using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip.Domain;
using Twilio.Deleters.Api.V2010.Account.Sip.Domain;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.Domain;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.Domain;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip.Domain {

    public class IpAccessControlListMapping : SidResource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingFetcher capable of executing the fetch
         */
        public static IpAccessControlListMappingFetcher fetch(String accountSid, String domainSid, String sid) {
            return new IpAccessControlListMappingFetcher(accountSid, domainSid, sid);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAccessControlListMappingCreator capable of executing the create
         */
        public static IpAccessControlListMappingCreator create(String accountSid, String domainSid, String ipAccessControlListSid) {
            return new IpAccessControlListMappingCreator(accountSid, domainSid, ipAccessControlListSid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @return IpAccessControlListMappingReader capable of executing the read
         */
        public static IpAccessControlListMappingReader read(String accountSid, String domainSid) {
            return new IpAccessControlListMappingReader(accountSid, domainSid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param sid The sid
         * @return IpAccessControlListMappingDeleter capable of executing the delete
         */
        public static IpAccessControlListMappingDeleter delete(String accountSid, String domainSid, String sid) {
            return new IpAccessControlListMappingDeleter(accountSid, domainSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAccessControlListMapping object
         * 
         * @param json Raw JSON string
         * @return IpAccessControlListMapping object represented by the provided JSON
         */
        public static IpAccessControlListMapping fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAccessControlListMapping>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private IpAccessControlListMapping([JsonProperty("account_sid")]
                                           String accountSid, 
                                           [JsonProperty("date_created")]
                                           String dateCreated, 
                                           [JsonProperty("date_updated")]
                                           String dateUpdated, 
                                           [JsonProperty("friendly_name")]
                                           String friendlyName, 
                                           [JsonProperty("sid")]
                                           String sid, 
                                           [JsonProperty("uri")]
                                           String uri) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
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
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
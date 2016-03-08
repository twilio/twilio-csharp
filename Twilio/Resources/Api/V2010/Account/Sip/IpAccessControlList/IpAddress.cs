using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Deleters.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip.IpAccessControlList;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Sip.Ipaccesscontrollist {

    public class IpAddress : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAddressReader capable of executing the read
         */
        public static IpAddressReader read(String accountSid, String ipAccessControlListSid) {
            return new IpAddressReader(accountSid, ipAccessControlListSid);
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param friendlyName The friendly_name
         * @param ipAddress The ip_address
         * @return IpAddressCreator capable of executing the create
         */
        public static IpAddressCreator create(String accountSid, String ipAccessControlListSid, String friendlyName, String ipAddress) {
            return new IpAddressCreator(accountSid, ipAccessControlListSid, friendlyName, ipAddress);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param sid The sid
         * @return IpAddressFetcher capable of executing the fetch
         */
        public static IpAddressFetcher fetch(String accountSid, String ipAccessControlListSid, String sid) {
            return new IpAddressFetcher(accountSid, ipAccessControlListSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param sid The sid
         * @param ipAddress The ip_address
         * @param friendlyName The friendly_name
         * @return IpAddressUpdater capable of executing the update
         */
        public static IpAddressUpdater update(String accountSid, String ipAccessControlListSid, String sid, String ipAddress, String friendlyName) {
            return new IpAddressUpdater(accountSid, ipAccessControlListSid, sid, ipAddress, friendlyName);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @param sid The sid
         * @return IpAddressDeleter capable of executing the delete
         */
        public static IpAddressDeleter delete(String accountSid, String ipAccessControlListSid, String sid) {
            return new IpAddressDeleter(accountSid, ipAccessControlListSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAddress object
         * 
         * @param json Raw JSON string
         * @return IpAddress object represented by the provided JSON
         */
        public static IpAddress fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAddress>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("ip_address")]
        private readonly String ipAddress;
        [JsonProperty("ip_access_control_list_sid")]
        private readonly String ipAccessControlListSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private IpAddress([JsonProperty("sid")]
                          String sid, 
                          [JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("friendly_name")]
                          String friendlyName, 
                          [JsonProperty("ip_address")]
                          String ipAddress, 
                          [JsonProperty("ip_access_control_list_sid")]
                          String ipAccessControlListSid, 
                          [JsonProperty("date_created")]
                          String dateCreated, 
                          [JsonProperty("date_updated")]
                          String dateUpdated, 
                          [JsonProperty("uri")]
                          String uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.ipAddress = ipAddress;
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The ip_address
         */
        public String GetIpAddress() {
            return this.ipAddress;
        }
    
        /**
         * @return The ip_access_control_list_sid
         */
        public String GetIpAccessControlListSid() {
            return this.ipAccessControlListSid;
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
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}
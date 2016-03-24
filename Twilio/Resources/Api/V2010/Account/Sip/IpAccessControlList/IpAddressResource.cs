using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Deleters.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Sip.IpAccessControlList;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account.Sip.IpAccessControlList;

namespace Twilio.Resources.Api.V2010.Account.Sip.Ipaccesscontrollist {

    public class IpAddressResource : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param ipAccessControlListSid The ip_access_control_list_sid
         * @return IpAddressReader capable of executing the read
         */
        public static IpAddressReader read(string accountSid, string ipAccessControlListSid) {
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
        public static IpAddressCreator create(string accountSid, string ipAccessControlListSid, string friendlyName, string ipAddress) {
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
        public static IpAddressFetcher fetch(string accountSid, string ipAccessControlListSid, string sid) {
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
        public static IpAddressUpdater update(string accountSid, string ipAccessControlListSid, string sid, string ipAddress, string friendlyName) {
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
        public static IpAddressDeleter delete(string accountSid, string ipAccessControlListSid, string sid) {
            return new IpAddressDeleter(accountSid, ipAccessControlListSid, sid);
        }
    
        /**
         * Converts a JSON string into a IpAddressResource object
         * 
         * @param json Raw JSON string
         * @return IpAddressResource object represented by the provided JSON
         */
        public static IpAddressResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IpAddressResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("ip_address")]
        private readonly string ipAddress;
        [JsonProperty("ip_access_control_list_sid")]
        private readonly string ipAccessControlListSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private IpAddressResource([JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("ip_address")]
                                  string ipAddress, 
                                  [JsonProperty("ip_access_control_list_sid")]
                                  string ipAccessControlListSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("uri")]
                                  string uri) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.ipAddress = ipAddress;
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The ip_address
         */
        public string GetIpAddress() {
            return this.ipAddress;
        }
    
        /**
         * @return The ip_access_control_list_sid
         */
        public string GetIpAccessControlListSid() {
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
        public string GetUri() {
            return this.uri;
        }
    }
}
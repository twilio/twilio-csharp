using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList {

    public class IpAddressResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAddressReader capable of executing the read </returns> 
        public static IpAddressReader Reader(string accountSid, string ipAccessControlListSid) {
            return new IpAddressReader(accountSid, ipAccessControlListSid);
        }
    
        /// <summary>
        /// Create a IpAddressReader to execute read.
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <returns> IpAddressReader capable of executing the read </returns> 
        public static IpAddressReader Reader(string ipAccessControlListSid) {
            return new IpAddressReader(ipAccessControlListSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ipAddress"> The ip_address </param>
        /// <returns> IpAddressCreator capable of executing the create </returns> 
        public static IpAddressCreator Creator(string accountSid, string ipAccessControlListSid, string friendlyName, string ipAddress) {
            return new IpAddressCreator(accountSid, ipAccessControlListSid, friendlyName, ipAddress);
        }
    
        /// <summary>
        /// Create a IpAddressCreator to execute create.
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ipAddress"> The ip_address </param>
        /// <returns> IpAddressCreator capable of executing the create </returns> 
        public static IpAddressCreator Creator(string ipAccessControlListSid, 
                                               string friendlyName, 
                                               string ipAddress) {
            return new IpAddressCreator(ipAccessControlListSid, friendlyName, ipAddress);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressFetcher capable of executing the fetch </returns> 
        public static IpAddressFetcher Fetcher(string accountSid, string ipAccessControlListSid, string sid) {
            return new IpAddressFetcher(accountSid, ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// Create a IpAddressFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressFetcher capable of executing the fetch </returns> 
        public static IpAddressFetcher Fetcher(string ipAccessControlListSid, 
                                               string sid) {
            return new IpAddressFetcher(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressUpdater capable of executing the update </returns> 
        public static IpAddressUpdater Updater(string accountSid, string ipAccessControlListSid, string sid) {
            return new IpAddressUpdater(accountSid, ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// Create a IpAddressUpdater to execute update.
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressUpdater capable of executing the update </returns> 
        public static IpAddressUpdater Updater(string ipAccessControlListSid, 
                                               string sid) {
            return new IpAddressUpdater(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressDeleter capable of executing the delete </returns> 
        public static IpAddressDeleter Deleter(string accountSid, string ipAccessControlListSid, string sid) {
            return new IpAddressDeleter(accountSid, ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// Create a IpAddressDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IpAddressDeleter capable of executing the delete </returns> 
        public static IpAddressDeleter Deleter(string ipAccessControlListSid, 
                                               string sid) {
            return new IpAddressDeleter(ipAccessControlListSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAddressResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAddressResource object represented by the provided JSON </returns> 
        public static IpAddressResource FromJson(string json) {
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
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public IpAddressResource() {
        
        }
    
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
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The ip_address </returns> 
        public string GetIpAddress() {
            return this.ipAddress;
        }
    
        /// <returns> The ip_access_control_list_sid </returns> 
        public string GetIpAccessControlListSid() {
            return this.ipAccessControlListSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The uri </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}
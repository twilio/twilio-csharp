using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 {

    public class ServiceResource : SidResource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <returns> ServiceCreator capable of executing the create </returns> 
        public static ServiceCreator Creator() {
            return new ServiceCreator();
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceDeleter capable of executing the delete </returns> 
        public static ServiceDeleter Deleter(string sid) {
            return new ServiceDeleter(sid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceFetcher capable of executing the fetch </returns> 
        public static ServiceFetcher Fetcher(string sid) {
            return new ServiceFetcher(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> ServiceReader capable of executing the read </returns> 
        public static ServiceReader Reader() {
            return new ServiceReader();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ServiceUpdater capable of executing the update </returns> 
        public static ServiceUpdater Updater(string sid) {
            return new ServiceUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns> 
        public static ServiceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
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
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("apn_credential_sid")]
        private readonly string apnCredentialSid;
        [JsonProperty("gcm_credential_sid")]
        private readonly string gcmCredentialSid;
        [JsonProperty("messaging_service_sid")]
        private readonly string messagingServiceSid;
        [JsonProperty("facebook_messenger_page_id")]
        private readonly string facebookMessengerPageId;
        [JsonProperty("default_apn_notification_protocol_version")]
        private readonly string defaultApnNotificationProtocolVersion;
        [JsonProperty("default_gcm_notification_protocol_version")]
        private readonly string defaultGcmNotificationProtocolVersion;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
    
        public ServiceResource() {
        
        }
    
        private ServiceResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("apn_credential_sid")]
                                string apnCredentialSid, 
                                [JsonProperty("gcm_credential_sid")]
                                string gcmCredentialSid, 
                                [JsonProperty("messaging_service_sid")]
                                string messagingServiceSid, 
                                [JsonProperty("facebook_messenger_page_id")]
                                string facebookMessengerPageId, 
                                [JsonProperty("default_apn_notification_protocol_version")]
                                string defaultApnNotificationProtocolVersion, 
                                [JsonProperty("default_gcm_notification_protocol_version")]
                                string defaultGcmNotificationProtocolVersion, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.apnCredentialSid = apnCredentialSid;
            this.gcmCredentialSid = gcmCredentialSid;
            this.messagingServiceSid = messagingServiceSid;
            this.facebookMessengerPageId = facebookMessengerPageId;
            this.defaultApnNotificationProtocolVersion = defaultApnNotificationProtocolVersion;
            this.defaultGcmNotificationProtocolVersion = defaultGcmNotificationProtocolVersion;
            this.url = url;
            this.links = links;
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
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The apn_credential_sid </returns> 
        public string GetApnCredentialSid() {
            return this.apnCredentialSid;
        }
    
        /// <returns> The gcm_credential_sid </returns> 
        public string GetGcmCredentialSid() {
            return this.gcmCredentialSid;
        }
    
        /// <returns> The messaging_service_sid </returns> 
        public string GetMessagingServiceSid() {
            return this.messagingServiceSid;
        }
    
        /// <returns> The facebook_messenger_page_id </returns> 
        public string GetFacebookMessengerPageId() {
            return this.facebookMessengerPageId;
        }
    
        /// <returns> The default_apn_notification_protocol_version </returns> 
        public string GetDefaultApnNotificationProtocolVersion() {
            return this.defaultApnNotificationProtocolVersion;
        }
    
        /// <returns> The default_gcm_notification_protocol_version </returns> 
        public string GetDefaultGcmNotificationProtocolVersion() {
            return this.defaultGcmNotificationProtocolVersion;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    }
}
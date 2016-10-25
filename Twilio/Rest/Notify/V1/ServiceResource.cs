using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Notify.V1 {

    public class ServiceResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <returns> ServiceCreator capable of executing the create </returns> 
        public static ServiceCreator Creator(string friendlyName=null, string apnCredentialSid=null, string gcmCredentialSid=null, string messagingServiceSid=null, string facebookMessengerPageId=null, string defaultApnNotificationProtocolVersion=null, string defaultGcmNotificationProtocolVersion=null) {
            return new ServiceCreator(friendlyName:friendlyName, apnCredentialSid:apnCredentialSid, gcmCredentialSid:gcmCredentialSid, messagingServiceSid:messagingServiceSid, facebookMessengerPageId:facebookMessengerPageId, defaultApnNotificationProtocolVersion:defaultApnNotificationProtocolVersion, defaultGcmNotificationProtocolVersion:defaultGcmNotificationProtocolVersion);
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
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> ServiceReader capable of executing the read </returns> 
        public static ServiceReader Reader(string friendlyName=null) {
            return new ServiceReader(friendlyName:friendlyName);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="apnCredentialSid"> The apn_credential_sid </param>
        /// <param name="gcmCredentialSid"> The gcm_credential_sid </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="facebookMessengerPageId"> The facebook_messenger_page_id </param>
        /// <param name="defaultApnNotificationProtocolVersion"> The default_apn_notification_protocol_version </param>
        /// <param name="defaultGcmNotificationProtocolVersion"> The default_gcm_notification_protocol_version </param>
        /// <returns> ServiceUpdater capable of executing the update </returns> 
        public static ServiceUpdater Updater(string sid, string friendlyName=null, string apnCredentialSid=null, string gcmCredentialSid=null, string messagingServiceSid=null, string facebookMessengerPageId=null, string defaultApnNotificationProtocolVersion=null, string defaultGcmNotificationProtocolVersion=null) {
            return new ServiceUpdater(sid, friendlyName:friendlyName, apnCredentialSid:apnCredentialSid, gcmCredentialSid:gcmCredentialSid, messagingServiceSid:messagingServiceSid, facebookMessengerPageId:facebookMessengerPageId, defaultApnNotificationProtocolVersion:defaultApnNotificationProtocolVersion, defaultGcmNotificationProtocolVersion:defaultGcmNotificationProtocolVersion);
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("apn_credential_sid")]
        public string apnCredentialSid { get; }
        [JsonProperty("gcm_credential_sid")]
        public string gcmCredentialSid { get; }
        [JsonProperty("messaging_service_sid")]
        public string messagingServiceSid { get; }
        [JsonProperty("facebook_messenger_page_id")]
        public string facebookMessengerPageId { get; }
        [JsonProperty("default_apn_notification_protocol_version")]
        public string defaultApnNotificationProtocolVersion { get; }
        [JsonProperty("default_gcm_notification_protocol_version")]
        public string defaultGcmNotificationProtocolVersion { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; }
    
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
    }
}
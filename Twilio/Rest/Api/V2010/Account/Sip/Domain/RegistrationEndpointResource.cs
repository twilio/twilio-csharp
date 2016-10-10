using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class RegistrationEndpointResource : Resource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param region The region
         * @param registrant The registrant
         * @return RegistrationEndpointReader capable of executing the read
         */
        public static RegistrationEndpointReader Reader(string accountSid, string domainSid, string region, string registrant) {
            return new RegistrationEndpointReader(accountSid, domainSid, region, registrant);
        }
    
        /**
         * Create a RegistrationEndpointReader to execute read.
         * 
         * @param domainSid The domain_sid
         * @param region The region
         * @param registrant The registrant
         * @return RegistrationEndpointReader capable of executing the read
         */
        public static RegistrationEndpointReader Reader(string domainSid, 
                                                        string region, 
                                                        string registrant) {
            return new RegistrationEndpointReader(domainSid, region, registrant);
        }
    
        /**
         * Converts a JSON string into a RegistrationEndpointResource object
         * 
         * @param json Raw JSON string
         * @return RegistrationEndpointResource object represented by the provided JSON
         */
        public static RegistrationEndpointResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RegistrationEndpointResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("address_of_record")]
        private readonly string addressOfRecord;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("date_expires")]
        private readonly DateTime? dateExpires;
        [JsonProperty("sip_call_id")]
        private readonly string sipCallId;
        [JsonProperty("sip_contact")]
        private readonly string sipContact;
        [JsonProperty("sip_cseq")]
        private readonly int? sipCseq;
        [JsonProperty("sip_path")]
        private readonly string sipPath;
        [JsonProperty("sip_via")]
        private readonly string sipVia;
        [JsonProperty("user_agent")]
        private readonly string userAgent;
        [JsonProperty("channel_type")]
        private readonly string channelType;
        [JsonProperty("display_name")]
        private readonly string displayName;
    
        public RegistrationEndpointResource() {
        
        }
    
        private RegistrationEndpointResource([JsonProperty("address_of_record")]
                                             string addressOfRecord, 
                                             [JsonProperty("date_created")]
                                             string dateCreated, 
                                             [JsonProperty("date_updated")]
                                             string dateUpdated, 
                                             [JsonProperty("date_expires")]
                                             string dateExpires, 
                                             [JsonProperty("sip_call_id")]
                                             string sipCallId, 
                                             [JsonProperty("sip_contact")]
                                             string sipContact, 
                                             [JsonProperty("sip_cseq")]
                                             int? sipCseq, 
                                             [JsonProperty("sip_path")]
                                             string sipPath, 
                                             [JsonProperty("sip_via")]
                                             string sipVia, 
                                             [JsonProperty("user_agent")]
                                             string userAgent, 
                                             [JsonProperty("channel_type")]
                                             string channelType, 
                                             [JsonProperty("display_name")]
                                             string displayName) {
            this.addressOfRecord = addressOfRecord;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.dateExpires = MarshalConverter.DateTimeFromString(dateExpires);
            this.sipCallId = sipCallId;
            this.sipContact = sipContact;
            this.sipCseq = sipCseq;
            this.sipPath = sipPath;
            this.sipVia = sipVia;
            this.userAgent = userAgent;
            this.channelType = channelType;
            this.displayName = displayName;
        }
    
        /**
         * @return The address_of_record
         */
        public string GetAddressOfRecord() {
            return this.addressOfRecord;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The date_expires
         */
        public DateTime? GetDateExpires() {
            return this.dateExpires;
        }
    
        /**
         * @return The sip_call_id
         */
        public string GetSipCallId() {
            return this.sipCallId;
        }
    
        /**
         * @return The sip_contact
         */
        public string GetSipContact() {
            return this.sipContact;
        }
    
        /**
         * @return The sip_cseq
         */
        public int? GetSipCseq() {
            return this.sipCseq;
        }
    
        /**
         * @return The sip_path
         */
        public string GetSipPath() {
            return this.sipPath;
        }
    
        /**
         * @return The sip_via
         */
        public string GetSipVia() {
            return this.sipVia;
        }
    
        /**
         * @return The user_agent
         */
        public string GetUserAgent() {
            return this.userAgent;
        }
    
        /**
         * @return The channel_type
         */
        public string GetChannelType() {
            return this.channelType;
        }
    
        /**
         * @return The display_name
         */
        public string GetDisplayName() {
            return this.displayName;
        }
    }
}
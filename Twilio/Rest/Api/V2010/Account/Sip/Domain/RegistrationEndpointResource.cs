using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class RegistrationEndpointResource : Resource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="region"> The region </param>
        /// <param name="registrant"> The registrant </param>
        /// <returns> RegistrationEndpointReader capable of executing the read </returns> 
        public static RegistrationEndpointReader Reader(string accountSid, string domainSid, string region, string registrant) {
            return new RegistrationEndpointReader(accountSid, domainSid, region, registrant);
        }
    
        /// <summary>
        /// Create a RegistrationEndpointReader to execute read.
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="region"> The region </param>
        /// <param name="registrant"> The registrant </param>
        /// <returns> RegistrationEndpointReader capable of executing the read </returns> 
        public static RegistrationEndpointReader Reader(string domainSid, 
                                                        string region, 
                                                        string registrant) {
            return new RegistrationEndpointReader(domainSid, region, registrant);
        }
    
        /// <summary>
        /// Converts a JSON string into a RegistrationEndpointResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RegistrationEndpointResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The address_of_record </returns> 
        public string GetAddressOfRecord() {
            return this.addressOfRecord;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The date_expires </returns> 
        public DateTime? GetDateExpires() {
            return this.dateExpires;
        }
    
        /// <returns> The sip_call_id </returns> 
        public string GetSipCallId() {
            return this.sipCallId;
        }
    
        /// <returns> The sip_contact </returns> 
        public string GetSipContact() {
            return this.sipContact;
        }
    
        /// <returns> The sip_cseq </returns> 
        public int? GetSipCseq() {
            return this.sipCseq;
        }
    
        /// <returns> The sip_path </returns> 
        public string GetSipPath() {
            return this.sipPath;
        }
    
        /// <returns> The sip_via </returns> 
        public string GetSipVia() {
            return this.sipVia;
        }
    
        /// <returns> The user_agent </returns> 
        public string GetUserAgent() {
            return this.userAgent;
        }
    
        /// <returns> The channel_type </returns> 
        public string GetChannelType() {
            return this.channelType;
        }
    
        /// <returns> The display_name </returns> 
        public string GetDisplayName() {
            return this.displayName;
        }
    }
}
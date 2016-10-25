using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class RegistrationEndpointResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="region"> The region </param>
        /// <param name="registrant"> The registrant </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> RegistrationEndpointReader capable of executing the read </returns> 
        public static RegistrationEndpointReader Reader(string domainSid, string region, string registrant, string accountSid=null)
        {
            return new RegistrationEndpointReader(domainSid, region, registrant, accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a RegistrationEndpointResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RegistrationEndpointResource object represented by the provided JSON </returns> 
        public static RegistrationEndpointResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RegistrationEndpointResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("address_of_record")]
        public string addressOfRecord { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("date_expires")]
        public DateTime? dateExpires { get; }
        [JsonProperty("sip_call_id")]
        public string sipCallId { get; }
        [JsonProperty("sip_contact")]
        public string sipContact { get; }
        [JsonProperty("sip_cseq")]
        public int? sipCseq { get; }
        [JsonProperty("sip_path")]
        public string sipPath { get; }
        [JsonProperty("sip_via")]
        public string sipVia { get; }
        [JsonProperty("user_agent")]
        public string userAgent { get; }
        [JsonProperty("channel_type")]
        public string channelType { get; }
        [JsonProperty("display_name")]
        public string displayName { get; }
    
        public RegistrationEndpointResource()
        {
        
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
                                             string displayName)
                                             {
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
    }
}
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
        /// <returns> RegistrationEndpointReader capable of executing the read </returns> 
        public static RegistrationEndpointReader Reader(string domainSid, string region, string registrant)
        {
            return new RegistrationEndpointReader(domainSid, region, registrant);
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
        public string AddressOfRecord { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("date_expires")]
        public DateTime? DateExpires { get; set; }
        [JsonProperty("sip_call_id")]
        public string SipCallId { get; set; }
        [JsonProperty("sip_contact")]
        public string SipContact { get; set; }
        [JsonProperty("sip_cseq")]
        public int? SipCseq { get; set; }
        [JsonProperty("sip_path")]
        public string SipPath { get; set; }
        [JsonProperty("sip_via")]
        public string SipVia { get; set; }
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    
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
            AddressOfRecord = addressOfRecord;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            DateExpires = MarshalConverter.DateTimeFromString(dateExpires);
            SipCallId = sipCallId;
            SipContact = sipContact;
            SipCseq = sipCseq;
            SipPath = sipPath;
            SipVia = sipVia;
            UserAgent = userAgent;
            ChannelType = channelType;
            DisplayName = displayName;
        }
    }
}
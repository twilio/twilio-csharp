using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class RegistrationEndpointResource : Resource 
    {
        private static Request BuildReadRequest(ReadRegistrationEndpointOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/Domains/" + options.DomainSid + "/Registrations/" + options.Region + "/" + options.Registrant + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RegistrationEndpointResource> Read(ReadRegistrationEndpointOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<RegistrationEndpointResource>.FromJson("registrations", response.Content);
            return new ResourceSet<RegistrationEndpointResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RegistrationEndpointResource>> ReadAsync(ReadRegistrationEndpointOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<RegistrationEndpointResource>.FromJson("registrations", response.Content);
            return new ResourceSet<RegistrationEndpointResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RegistrationEndpointResource> Read(string domainSid, string region, string registrant, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRegistrationEndpointOptions(domainSid, region, registrant){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RegistrationEndpointResource>> ReadAsync(string domainSid, string region, string registrant, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRegistrationEndpointOptions(domainSid, region, registrant){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<RegistrationEndpointResource> NextPage(Page<RegistrationEndpointResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<RegistrationEndpointResource>.FromJson("registrations", response.Content);
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
        public string AddressOfRecord { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("date_expires")]
        public DateTime? DateExpires { get; private set; }
        [JsonProperty("sip_call_id")]
        public string SipCallId { get; private set; }
        [JsonProperty("sip_contact")]
        public string SipContact { get; private set; }
        [JsonProperty("sip_cseq")]
        public int? SipCseq { get; private set; }
        [JsonProperty("sip_path")]
        public string SipPath { get; private set; }
        [JsonProperty("sip_via")]
        public string SipVia { get; private set; }
        [JsonProperty("user_agent")]
        public string UserAgent { get; private set; }
        [JsonProperty("channel_type")]
        public string ChannelType { get; private set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; private set; }
    
        private RegistrationEndpointResource()
        {
        
        }
    }

}
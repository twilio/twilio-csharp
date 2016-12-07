using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class NumberResource : Resource 
    {
        private static Request BuildFetchRequest(FetchNumberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Pricing,
                "/v1/Voice/Numbers/" + options.Number + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static NumberResource Fetch(FetchNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NumberResource> FetchAsync(FetchNumberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static NumberResource Fetch(Types.PhoneNumber number, ITwilioRestClient client = null)
        {
            var options = new FetchNumberOptions(number);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NumberResource> FetchAsync(Types.PhoneNumber number, ITwilioRestClient client = null)
        {
            var options = new FetchNumberOptions(number);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a NumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NumberResource object represented by the provided JSON </returns> 
        public static NumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NumberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber Number { get; private set; }
        [JsonProperty("country")]
        public string Country { get; private set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }
        [JsonProperty("outbound_call_price")]
        public OutboundCallPrice OutboundCallPrice { get; private set; }
        [JsonProperty("inbound_call_price")]
        public InboundCallPrice InboundCallPrice { get; private set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private NumberResource()
        {
        
        }
    }

}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class NewKeyResource : Resource 
    {
        private static Request BuildCreateRequest(CreateNewKeyOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Keys.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static NewKeyResource Create(CreateNewKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NewKeyResource> CreateAsync(CreateNewKeyOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static NewKeyResource Create(string accountSid = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateNewKeyOptions{AccountSid = accountSid, FriendlyName = friendlyName};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NewKeyResource> CreateAsync(string accountSid = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateNewKeyOptions{AccountSid = accountSid, FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a NewKeyResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewKeyResource object represented by the provided JSON </returns> 
        public static NewKeyResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NewKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("secret")]
        public string Secret { get; private set; }
    
        private NewKeyResource()
        {
        
        }
    }

}
/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Iam
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Iam.V1
{
    public class GetApiKeysResource : Resource
    {
    

    

        
        private static Request BuildReadRequest(ReadGetApiKeysOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Keys";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Iam,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Keys for a account. </summary>
        /// <param name="options"> Read GetApiKeys parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of GetApiKeys </returns>
        public static ResourceSet<GetApiKeysResource> Read(ReadGetApiKeysOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<GetApiKeysResource>.FromJson("keys", response.Content);
            return new ResourceSet<GetApiKeysResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Keys for a account. </summary>
        /// <param name="options"> Read GetApiKeys parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of GetApiKeys </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<GetApiKeysResource>> ReadAsync(ReadGetApiKeysOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<GetApiKeysResource>.FromJson("keys", response.Content);
            return new ResourceSet<GetApiKeysResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Keys for a account. </summary>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Payments resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of GetApiKeys </returns>
        public static ResourceSet<GetApiKeysResource> Read(
                                                     string accountSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadGetApiKeysOptions(accountSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Keys for a account. </summary>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Payments resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of GetApiKeys </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<GetApiKeysResource>> ReadAsync(
                                                                                             string accountSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadGetApiKeysOptions(accountSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<GetApiKeysResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<GetApiKeysResource>.FromJson("keys", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<GetApiKeysResource> NextPage(Page<GetApiKeysResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<GetApiKeysResource>.FromJson("keys", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<GetApiKeysResource> PreviousPage(Page<GetApiKeysResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<GetApiKeysResource>.FromJson("keys", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a GetApiKeysResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> GetApiKeysResource object represented by the provided JSON </returns>
        public static GetApiKeysResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<GetApiKeysResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique string that we created to identify the Key resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The date and time in GMT that the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }



        private GetApiKeysResource() {

        }
    }
}


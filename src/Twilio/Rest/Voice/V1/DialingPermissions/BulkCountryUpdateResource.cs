/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Voice
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



namespace Twilio.Rest.Voice.V1.DialingPermissions
{
    public class BulkCountryUpdateResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateBulkCountryUpdateOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/DialingPermissions/BulkCountryUpdates";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Voice,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a bulk update request to change voice dialing country permissions of one or more countries identified by the corresponding [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) </summary>
        /// <param name="options"> Create BulkCountryUpdate parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BulkCountryUpdate </returns>
        public static BulkCountryUpdateResource Create(CreateBulkCountryUpdateOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a bulk update request to change voice dialing country permissions of one or more countries identified by the corresponding [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) </summary>
        /// <param name="options"> Create BulkCountryUpdate parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BulkCountryUpdate </returns>
        public static async System.Threading.Tasks.Task<BulkCountryUpdateResource> CreateAsync(CreateBulkCountryUpdateOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a bulk update request to change voice dialing country permissions of one or more countries identified by the corresponding [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) </summary>
        /// <param name="updateRequest"> URL encoded JSON array of update objects. example : `[ { \\\"iso_code\\\": \\\"GB\\\", \\\"low_risk_numbers_enabled\\\": \\\"true\\\", \\\"high_risk_special_numbers_enabled\\\":\\\"true\\\", \\\"high_risk_tollfraud_numbers_enabled\\\": \\\"false\\\" } ]` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BulkCountryUpdate </returns>
        public static BulkCountryUpdateResource Create(
                                          string updateRequest,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateBulkCountryUpdateOptions(updateRequest){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a bulk update request to change voice dialing country permissions of one or more countries identified by the corresponding [ISO country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) </summary>
        /// <param name="updateRequest"> URL encoded JSON array of update objects. example : `[ { \\\"iso_code\\\": \\\"GB\\\", \\\"low_risk_numbers_enabled\\\": \\\"true\\\", \\\"high_risk_special_numbers_enabled\\\":\\\"true\\\", \\\"high_risk_tollfraud_numbers_enabled\\\": \\\"false\\\" } ]` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BulkCountryUpdate </returns>
        public static async System.Threading.Tasks.Task<BulkCountryUpdateResource> CreateAsync(
                                                                                  string updateRequest,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateBulkCountryUpdateOptions(updateRequest){  };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a BulkCountryUpdateResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BulkCountryUpdateResource object represented by the provided JSON </returns>
        public static BulkCountryUpdateResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BulkCountryUpdateResource>(json);
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

    
        ///<summary> The number of countries updated </summary> 
        [JsonProperty("update_count")]
        public int? UpdateCount { get; private set; }

        ///<summary> A bulk update request to change voice dialing country permissions stored as a URL-encoded, JSON array of update objects. For example : `[ { \"iso_code\": \"GB\", \"low_risk_numbers_enabled\": \"true\", \"high_risk_special_numbers_enabled\":\"true\", \"high_risk_tollfraud_numbers_enabled\": \"false\" } ]` </summary> 
        [JsonProperty("update_request")]
        public string UpdateRequest { get; private set; }



        private BulkCountryUpdateResource() {

        }
    }
}


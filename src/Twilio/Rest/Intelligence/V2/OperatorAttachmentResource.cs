/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Intelligence
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





namespace Twilio.Rest.Intelligence.V2
{
    public class OperatorAttachmentResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateOperatorAttachmentOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Operators/{OperatorSid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathOperatorSid = options.PathOperatorSid;
            path = path.Replace("{"+"OperatorSid"+"}", PathOperatorSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Intelligence,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Attach an Operator to a Service. </summary>
        /// <param name="options"> Create OperatorAttachment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorAttachment </returns>
        public static OperatorAttachmentResource Create(CreateOperatorAttachmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Attach an Operator to a Service. </summary>
        /// <param name="options"> Create OperatorAttachment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorAttachment </returns>
        public static async System.Threading.Tasks.Task<OperatorAttachmentResource> CreateAsync(CreateOperatorAttachmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Attach an Operator to a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathOperatorSid"> The unique SID identifier of the Operator. Allows both Custom and Pre-built Operators. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorAttachment </returns>
        public static OperatorAttachmentResource Create(
                                          string pathServiceSid,
                                          string pathOperatorSid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateOperatorAttachmentOptions(pathServiceSid, pathOperatorSid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Attach an Operator to a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathOperatorSid"> The unique SID identifier of the Operator. Allows both Custom and Pre-built Operators. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorAttachment </returns>
        public static async System.Threading.Tasks.Task<OperatorAttachmentResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string pathOperatorSid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateOperatorAttachmentOptions(pathServiceSid, pathOperatorSid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Detach an Operator from a Service. </summary>
        /// <param name="options"> Delete OperatorAttachment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorAttachment </returns>
        private static Request BuildDeleteRequest(DeleteOperatorAttachmentOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Operators/{OperatorSid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathOperatorSid = options.PathOperatorSid;
            path = path.Replace("{"+"OperatorSid"+"}", PathOperatorSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Detach an Operator from a Service. </summary>
        /// <param name="options"> Delete OperatorAttachment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorAttachment </returns>
        public static bool Delete(DeleteOperatorAttachmentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Detach an Operator from a Service. </summary>
        /// <param name="options"> Delete OperatorAttachment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorAttachment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteOperatorAttachmentOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Detach an Operator from a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathOperatorSid"> The unique SID identifier of the Operator. Allows both Custom and Pre-built Operators. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorAttachment </returns>
        public static bool Delete(string pathServiceSid, string pathOperatorSid, ITwilioRestClient client = null)
        {
            var options = new DeleteOperatorAttachmentOptions(pathServiceSid, pathOperatorSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Detach an Operator from a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathOperatorSid"> The unique SID identifier of the Operator. Allows both Custom and Pre-built Operators. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorAttachment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathOperatorSid, ITwilioRestClient client = null)
        {
            var options = new DeleteOperatorAttachmentOptions(pathServiceSid, pathOperatorSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a OperatorAttachmentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OperatorAttachmentResource object represented by the provided JSON </returns>
        public static OperatorAttachmentResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<OperatorAttachmentResource>(json);
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

    
        ///<summary> The unique SID identifier of the Service. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The unique SID identifier of the Operator. </summary> 
        [JsonProperty("operator_sid")]
        public string OperatorSid { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private OperatorAttachmentResource() {

        }
    }
}


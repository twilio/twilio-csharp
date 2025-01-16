/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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



namespace Twilio.Rest.Numbers.V1
{
    public class PortingPortInResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreatePortingPortInOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Porting/PortIn";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Allows to create a new port in request </summary>
        /// <param name="options"> Create PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static PortingPortInResource Create(CreatePortingPortInOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Allows to create a new port in request </summary>
        /// <param name="options"> Create PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<PortingPortInResource> CreateAsync(CreatePortingPortInOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Allows to create a new port in request </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static PortingPortInResource Create(
                                            ITwilioRestClient client = null)
        {
            var options = new CreatePortingPortInOptions(){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Allows to create a new port in request </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<PortingPortInResource> CreateAsync(
                                                                                    ITwilioRestClient client = null,
                                                                                    System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreatePortingPortInOptions(){  };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
        
        /// <summary> Allows to cancel a port in request by SID </summary>
        /// <param name="options"> Delete PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        private static Request BuildDeleteRequest(DeletePortingPortInOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Porting/PortIn/{PortInRequestSid}";

            string PathPortInRequestSid = options.PathPortInRequestSid;
            path = path.Replace("{"+"PortInRequestSid"+"}", PathPortInRequestSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Allows to cancel a port in request by SID </summary>
        /// <param name="options"> Delete PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static bool Delete(DeletePortingPortInOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Allows to cancel a port in request by SID </summary>
        /// <param name="options"> Delete PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePortingPortInOptions options, 
                                                                        ITwilioRestClient client = null,
                                                                        System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client), cancellationToken);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Allows to cancel a port in request by SID </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static bool Delete(string pathPortInRequestSid, ITwilioRestClient client = null)
        {
            var options = new DeletePortingPortInOptions(pathPortInRequestSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Allows to cancel a port in request by SID </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathPortInRequestSid, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new DeletePortingPortInOptions(pathPortInRequestSid) ;
            return await DeleteAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchPortingPortInOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Porting/PortIn/{PortInRequestSid}";

            string PathPortInRequestSid = options.PathPortInRequestSid;
            path = path.Replace("{"+"PortInRequestSid"+"}", PathPortInRequestSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a port in request by SID </summary>
        /// <param name="options"> Fetch PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static PortingPortInResource Fetch(FetchPortingPortInOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a port in request by SID </summary>
        /// <param name="options"> Fetch PortingPortIn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<PortingPortInResource> FetchAsync(FetchPortingPortInOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a port in request by SID </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PortingPortIn </returns>
        public static PortingPortInResource Fetch(
                                         string pathPortInRequestSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchPortingPortInOptions(pathPortInRequestSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a port in request by SID </summary>
        /// <param name="pathPortInRequestSid"> The SID of the Port In request. This is a unique identifier of the port in request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PortingPortIn </returns>
        public static async System.Threading.Tasks.Task<PortingPortInResource> FetchAsync(string pathPortInRequestSid, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new FetchPortingPortInOptions(pathPortInRequestSid){  };
            return await FetchAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a PortingPortInResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PortingPortInResource object represented by the provided JSON </returns>
        public static PortingPortInResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PortingPortInResource>(json);
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

    
        ///<summary> The SID of the Port In request. This is a unique identifier of the port in request. </summary> 
        [JsonProperty("port_in_request_sid")]
        public string PortInRequestSid { get; private set; }

        ///<summary> The URL of this Port In request </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Account Sid or subaccount where the phone number(s) will be Ported </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Additional emails to send a copy of the signed LOA to. </summary> 
        [JsonProperty("notification_emails")]
        public List<string> NotificationEmails { get; private set; }

        ///<summary> Target date to port the number. We cannot guarantee that this date will be honored by the other carriers, please work with Ops to get a confirmation of the firm order commitment (FOC) date. Expected format is ISO Local Date, example: ‘2011-12-03`. This date must be at least 7 days in the future for US ports and 10 days in the future for Japanese ports. (This value is only available for custom porting customers.) </summary> 
        [JsonProperty("target_port_in_date")]
        public DateTime? TargetPortInDate { get; private set; }

        ///<summary> The earliest time that the port should occur on the target port in date. Expected format is ISO Offset Time, example: ‘10:15:00-08:00'. (This value is only available for custom porting customers.) </summary> 
        [JsonProperty("target_port_in_time_range_start")]
        public string TargetPortInTimeRangeStart { get; private set; }

        ///<summary> The latest time that the port should occur on the target port in date. Expected format is ISO Offset Time, example: ‘10:15:00-08:00'.  (This value is only available for custom porting customers.) </summary> 
        [JsonProperty("target_port_in_time_range_end")]
        public string TargetPortInTimeRangeEnd { get; private set; }

        ///<summary> The status of the port in request. The possible values are: In progress, Completed, Expired, In review, Waiting for Signature, Action Required, and Canceled. </summary> 
        [JsonProperty("port_in_request_status")]
        public string PortInRequestStatus { get; private set; }

        ///<summary> Details regarding the customer’s information with the losing carrier. These values will be used to generate the letter of authorization and should match the losing carrier’s data as closely as possible to ensure the port is accepted. </summary> 
        [JsonProperty("losing_carrier_information")]
        public object LosingCarrierInformation { get; private set; }

        ///<summary> The phone_numbers </summary> 
        [JsonProperty("phone_numbers")]
        public List<object> PhoneNumbers { get; private set; }

        ///<summary> List of document SIDs for all phone numbers included in the port in request. At least one document SID referring to a document of the type Utility Bill is required. </summary> 
        [JsonProperty("documents")]
        public List<string> Documents { get; private set; }

        ///<summary> The date_created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }



        private PortingPortInResource() {

        }
    }
}


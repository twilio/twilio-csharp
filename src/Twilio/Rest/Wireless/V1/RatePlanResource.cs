/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Wireless
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
using Twilio.Types;


namespace Twilio.Rest.Wireless.V1
{
    public class RatePlanResource : Resource
    {
    

    
        public sealed class DataLimitStrategyEnum : StringEnum
        {
            private DataLimitStrategyEnum(string value) : base(value) {}
            public DataLimitStrategyEnum() {}
            public static implicit operator DataLimitStrategyEnum(string value)
            {
                return new DataLimitStrategyEnum(value);
            }
            public static readonly DataLimitStrategyEnum Block = new DataLimitStrategyEnum("block");
            public static readonly DataLimitStrategyEnum Throttle = new DataLimitStrategyEnum("throttle");

        }

        
        private static Request BuildCreateRequest(CreateRatePlanOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/RatePlans";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Wireless,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Create(CreateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<RatePlanResource> CreateAsync(CreateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It does not have to be unique. </param>
        /// <param name="dataEnabled"> Whether SIMs can use GPRS/3G/4G/LTE data connectivity. </param>
        /// <param name="dataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on the home network (T-Mobile USA). The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB and the default value is `1000`. </param>
        /// <param name="dataMetering"> The model used to meter data usage. Can be: `payg` and `quota-1`, `quota-10`, and `quota-50`. Learn more about the available [data metering models](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#payg-vs-quota-data-plans). </param>
        /// <param name="messagingEnabled"> Whether SIMs can make, send, and receive SMS using [Commands](https://www.twilio.com/docs/iot/wireless/api/command-resource). </param>
        /// <param name="voiceEnabled"> Deprecated. </param>
        /// <param name="nationalRoamingEnabled"> Whether SIMs can roam on networks other than the home network (T-Mobile USA) in the United States. See [national roaming](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#national-roaming). </param>
        /// <param name="internationalRoaming"> The list of services that SIMs capable of using GPRS/3G/4G/LTE data connectivity can use outside of the United States. Can contain: `data` and `messaging`. </param>
        /// <param name="nationalRoamingDataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on non-home networks in the United States. The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB. See [national roaming](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#national-roaming) for more info. </param>
        /// <param name="internationalRoamingDataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month when roaming outside the United States. Can be up to 2TB. </param>
        /// <param name="dataLimitStrategy">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Create(
                                          string uniqueName = null,
                                          string friendlyName = null,
                                          bool? dataEnabled = null,
                                          int? dataLimit = null,
                                          string dataMetering = null,
                                          bool? messagingEnabled = null,
                                          bool? voiceEnabled = null,
                                          bool? nationalRoamingEnabled = null,
                                          List<string> internationalRoaming = null,
                                          int? nationalRoamingDataLimit = null,
                                          int? internationalRoamingDataLimit = null,
                                          RatePlanResource.DataLimitStrategyEnum dataLimitStrategy = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateRatePlanOptions(){  UniqueName = uniqueName, FriendlyName = friendlyName, DataEnabled = dataEnabled, DataLimit = dataLimit, DataMetering = dataMetering, MessagingEnabled = messagingEnabled, VoiceEnabled = voiceEnabled, NationalRoamingEnabled = nationalRoamingEnabled, InternationalRoaming = internationalRoaming, NationalRoamingDataLimit = nationalRoamingDataLimit, InternationalRoamingDataLimit = internationalRoamingDataLimit, DataLimitStrategy = dataLimitStrategy };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It does not have to be unique. </param>
        /// <param name="dataEnabled"> Whether SIMs can use GPRS/3G/4G/LTE data connectivity. </param>
        /// <param name="dataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on the home network (T-Mobile USA). The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB and the default value is `1000`. </param>
        /// <param name="dataMetering"> The model used to meter data usage. Can be: `payg` and `quota-1`, `quota-10`, and `quota-50`. Learn more about the available [data metering models](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#payg-vs-quota-data-plans). </param>
        /// <param name="messagingEnabled"> Whether SIMs can make, send, and receive SMS using [Commands](https://www.twilio.com/docs/iot/wireless/api/command-resource). </param>
        /// <param name="voiceEnabled"> Deprecated. </param>
        /// <param name="nationalRoamingEnabled"> Whether SIMs can roam on networks other than the home network (T-Mobile USA) in the United States. See [national roaming](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#national-roaming). </param>
        /// <param name="internationalRoaming"> The list of services that SIMs capable of using GPRS/3G/4G/LTE data connectivity can use outside of the United States. Can contain: `data` and `messaging`. </param>
        /// <param name="nationalRoamingDataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on non-home networks in the United States. The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB. See [national roaming](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#national-roaming) for more info. </param>
        /// <param name="internationalRoamingDataLimit"> The total data usage (download and upload combined) in Megabytes that the Network allows during one month when roaming outside the United States. Can be up to 2TB. </param>
        /// <param name="dataLimitStrategy">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<RatePlanResource> CreateAsync(
                                                                                  string uniqueName = null,
                                                                                  string friendlyName = null,
                                                                                  bool? dataEnabled = null,
                                                                                  int? dataLimit = null,
                                                                                  string dataMetering = null,
                                                                                  bool? messagingEnabled = null,
                                                                                  bool? voiceEnabled = null,
                                                                                  bool? nationalRoamingEnabled = null,
                                                                                  List<string> internationalRoaming = null,
                                                                                  int? nationalRoamingDataLimit = null,
                                                                                  int? internationalRoamingDataLimit = null,
                                                                                  RatePlanResource.DataLimitStrategyEnum dataLimitStrategy = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateRatePlanOptions(){  UniqueName = uniqueName, FriendlyName = friendlyName, DataEnabled = dataEnabled, DataLimit = dataLimit, DataMetering = dataMetering, MessagingEnabled = messagingEnabled, VoiceEnabled = voiceEnabled, NationalRoamingEnabled = nationalRoamingEnabled, InternationalRoaming = internationalRoaming, NationalRoamingDataLimit = nationalRoamingDataLimit, InternationalRoamingDataLimit = internationalRoamingDataLimit, DataLimitStrategy = dataLimitStrategy };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        private static Request BuildDeleteRequest(DeleteRatePlanOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/RatePlans/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Wireless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static bool Delete(DeleteRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRatePlanOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteRatePlanOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteRatePlanOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchRatePlanOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/RatePlans/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Fetch(FetchRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<RatePlanResource> FetchAsync(FetchRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchRatePlanOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<RatePlanResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchRatePlanOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadRatePlanOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/RatePlans";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static ResourceSet<RatePlanResource> Read(ReadRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<RatePlanResource>.FromJson("rate_plans", response.Content);
            return new ResourceSet<RatePlanResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RatePlanResource>> ReadAsync(ReadRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<RatePlanResource>.FromJson("rate_plans", response.Content);
            return new ResourceSet<RatePlanResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static ResourceSet<RatePlanResource> Read(
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadRatePlanOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RatePlanResource>> ReadAsync(
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadRatePlanOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<RatePlanResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<RatePlanResource>.FromJson("rate_plans", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<RatePlanResource> NextPage(Page<RatePlanResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RatePlanResource>.FromJson("rate_plans", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<RatePlanResource> PreviousPage(Page<RatePlanResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RatePlanResource>.FromJson("rate_plans", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateRatePlanOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/RatePlans/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Wireless,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Update(UpdateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update RatePlan parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<RatePlanResource> UpdateAsync(UpdateRatePlanOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to update. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It does not have to be unique. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RatePlan </returns>
        public static RatePlanResource Update(
                                          string pathSid,
                                          string uniqueName = null,
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateRatePlanOptions(pathSid){ UniqueName = uniqueName, FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the RatePlan resource to update. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It does not have to be unique. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RatePlan </returns>
        public static async System.Threading.Tasks.Task<RatePlanResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string uniqueName = null,
                                                                              string friendlyName = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateRatePlanOptions(pathSid){ UniqueName = uniqueName, FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a RatePlanResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RatePlanResource object represented by the provided JSON </returns>
        public static RatePlanResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RatePlanResource>(json);
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

    
        ///<summary> The unique string that we created to identify the RatePlan resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the RatePlan resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Whether SIMs can use GPRS/3G/4G/LTE data connectivity. </summary> 
        [JsonProperty("data_enabled")]
        public bool? DataEnabled { get; private set; }

        ///<summary> The model used to meter data usage. Can be: `payg` and `quota-1`, `quota-10`, and `quota-50`. Learn more about the available [data metering models](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#payg-vs-quota-data-plans). </summary> 
        [JsonProperty("data_metering")]
        public string DataMetering { get; private set; }

        ///<summary> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on the home network (T-Mobile USA). The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB. </summary> 
        [JsonProperty("data_limit")]
        public int? DataLimit { get; private set; }

        ///<summary> Whether SIMs can make, send, and receive SMS using [Commands](https://www.twilio.com/docs/iot/wireless/api/command-resource). </summary> 
        [JsonProperty("messaging_enabled")]
        public bool? MessagingEnabled { get; private set; }

        ///<summary> Deprecated. Whether SIMs can make and receive voice calls. </summary> 
        [JsonProperty("voice_enabled")]
        public bool? VoiceEnabled { get; private set; }

        ///<summary> Whether SIMs can roam on networks other than the home network (T-Mobile USA) in the United States. See [national roaming](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource#national-roaming). </summary> 
        [JsonProperty("national_roaming_enabled")]
        public bool? NationalRoamingEnabled { get; private set; }

        ///<summary> The total data usage (download and upload combined) in Megabytes that the Network allows during one month on non-home networks in the United States. The metering period begins the day of activation and ends on the same day in the following month. Can be up to 2TB. </summary> 
        [JsonProperty("national_roaming_data_limit")]
        public int? NationalRoamingDataLimit { get; private set; }

        ///<summary> The list of services that SIMs capable of using GPRS/3G/4G/LTE data connectivity can use outside of the United States. Can contain: `data` and `messaging`. </summary> 
        [JsonProperty("international_roaming")]
        public List<string> InternationalRoaming { get; private set; }

        ///<summary> The total data usage (download and upload combined) in Megabytes that the Network allows during one month when roaming outside the United States. Can be up to 2TB. </summary> 
        [JsonProperty("international_roaming_data_limit")]
        public int? InternationalRoamingDataLimit { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private RatePlanResource() {

        }
    }
}


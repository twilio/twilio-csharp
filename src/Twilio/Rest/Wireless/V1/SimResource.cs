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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Wireless.V1
{
    public class SimResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum New = new StatusEnum("new");
            public static readonly StatusEnum Ready = new StatusEnum("ready");
            public static readonly StatusEnum Active = new StatusEnum("active");
            public static readonly StatusEnum Suspended = new StatusEnum("suspended");
            public static readonly StatusEnum Deactivated = new StatusEnum("deactivated");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
            public static readonly StatusEnum Scheduled = new StatusEnum("scheduled");
            public static readonly StatusEnum Updating = new StatusEnum("updating");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ResetStatusEnum : StringEnum
        {
            private ResetStatusEnum(string value) : base(value) {}
            public ResetStatusEnum() {}
            public static implicit operator ResetStatusEnum(string value)
            {
                return new ResetStatusEnum(value);
            }
            public static readonly ResetStatusEnum Resetting = new ResetStatusEnum("resetting");

        }

        
        /// <summary> Delete a Sim resource on your Account. </summary>
        /// <param name="options"> Delete Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        private static Request BuildDeleteRequest(DeleteSimOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Sims/{Sid}";

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

        /// <summary> Delete a Sim resource on your Account. </summary>
        /// <param name="options"> Delete Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static bool Delete(DeleteSimOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a Sim resource on your Account. </summary>
        /// <param name="options"> Delete Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSimOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSimOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSimOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchSimOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Sims/{Sid}";

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

        /// <summary> Fetch a Sim resource on your Account. </summary>
        /// <param name="options"> Fetch Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static SimResource Fetch(FetchSimOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a Sim resource on your Account. </summary>
        /// <param name="options"> Fetch Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<SimResource> FetchAsync(FetchSimOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static SimResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchSimOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<SimResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSimOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSimOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Sims";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of Sim resources on your Account. </summary>
        /// <param name="options"> Read Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static ResourceSet<SimResource> Read(ReadSimOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SimResource>.FromJson("sims", response.Content);
            return new ResourceSet<SimResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Sim resources on your Account. </summary>
        /// <param name="options"> Read Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SimResource>> ReadAsync(ReadSimOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SimResource>.FromJson("sims", response.Content);
            return new ResourceSet<SimResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of Sim resources on your Account. </summary>
        /// <param name="status"> Only return Sim resources with this status. </param>
        /// <param name="iccid"> Only return Sim resources with this ICCID. This will return a list with a maximum size of 1. </param>
        /// <param name="ratePlan"> The SID or unique name of a [RatePlan resource](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource). Only return Sim resources assigned to this RatePlan resource. </param>
        /// <param name="eId"> Deprecated. </param>
        /// <param name="simRegistrationCode"> Only return Sim resources with this registration code. This will return a list with a maximum size of 1. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static ResourceSet<SimResource> Read(
                                                     SimResource.StatusEnum status = null,
                                                     string iccid = null,
                                                     string ratePlan = null,
                                                     string eId = null,
                                                     string simRegistrationCode = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadSimOptions(){ Status = status, Iccid = iccid, RatePlan = ratePlan, EId = eId, SimRegistrationCode = simRegistrationCode, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Sim resources on your Account. </summary>
        /// <param name="status"> Only return Sim resources with this status. </param>
        /// <param name="iccid"> Only return Sim resources with this ICCID. This will return a list with a maximum size of 1. </param>
        /// <param name="ratePlan"> The SID or unique name of a [RatePlan resource](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource). Only return Sim resources assigned to this RatePlan resource. </param>
        /// <param name="eId"> Deprecated. </param>
        /// <param name="simRegistrationCode"> Only return Sim resources with this registration code. This will return a list with a maximum size of 1. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SimResource>> ReadAsync(
                                                                                             SimResource.StatusEnum status = null,
                                                                                             string iccid = null,
                                                                                             string ratePlan = null,
                                                                                             string eId = null,
                                                                                             string simRegistrationCode = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadSimOptions(){ Status = status, Iccid = iccid, RatePlan = ratePlan, EId = eId, SimRegistrationCode = simRegistrationCode, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SimResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SimResource>.FromJson("sims", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SimResource> NextPage(Page<SimResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SimResource>.FromJson("sims", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SimResource> PreviousPage(Page<SimResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SimResource>.FromJson("sims", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateSimOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Sims/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Wireless,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Updates the given properties of a Sim resource on your Account. </summary>
        /// <param name="options"> Update Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static SimResource Update(UpdateSimOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Updates the given properties of a Sim resource on your Account. </summary>
        /// <param name="options"> Update Sim parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<SimResource> UpdateAsync(UpdateSimOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Updates the given properties of a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to update. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the `sid` in the URL path to address the resource. </param>
        /// <param name="callbackMethod"> The HTTP method we should use to call `callback_url`. Can be: `POST` or `GET`. The default is `POST`. </param>
        /// <param name="callbackUrl"> The URL we should call using the `callback_url` when the SIM has finished updating. When the SIM transitions from `new` to `ready` or from any status to `deactivated`, we call this URL when the status changes to an intermediate status (`ready` or `deactivated`) and again when the status changes to its final status (`active` or `canceled`). </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Sim resource. It does not need to be unique. </param>
        /// <param name="ratePlan"> The SID or unique name of the [RatePlan resource](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource) to which the Sim resource should be assigned. </param>
        /// <param name="status">  </param>
        /// <param name="commandsCallbackMethod"> The HTTP method we should use to call `commands_callback_url`. Can be: `POST` or `GET`. The default is `POST`. </param>
        /// <param name="commandsCallbackUrl"> The URL we should call using the `commands_callback_method` when the SIM sends a [Command](https://www.twilio.com/docs/iot/wireless/api/command-resource). Your server should respond with an HTTP status code in the 200 range; any response body is ignored. </param>
        /// <param name="smsFallbackMethod"> The HTTP method we should use to call `sms_fallback_url`. Can be: `GET` or `POST`. Default is `POST`. </param>
        /// <param name="smsFallbackUrl"> The URL we should call using the `sms_fallback_method` when an error occurs while retrieving or executing the TwiML requested from `sms_url`. </param>
        /// <param name="smsMethod"> The HTTP method we should use to call `sms_url`. Can be: `GET` or `POST`. Default is `POST`. </param>
        /// <param name="smsUrl"> The URL we should call using the `sms_method` when the SIM-connected device sends an SMS message that is not a [Command](https://www.twilio.com/docs/iot/wireless/api/command-resource). </param>
        /// <param name="voiceFallbackMethod"> Deprecated. </param>
        /// <param name="voiceFallbackUrl"> Deprecated. </param>
        /// <param name="voiceMethod"> Deprecated. </param>
        /// <param name="voiceUrl"> Deprecated. </param>
        /// <param name="resetStatus">  </param>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) to which the Sim resource should belong. The Account SID can only be that of the requesting Account or that of a [Subaccount](https://www.twilio.com/docs/iam/api/subaccounts) of the requesting Account. Only valid when the Sim resource's status is `new`. For more information, see the [Move SIMs between Subaccounts documentation](https://www.twilio.com/docs/iot/wireless/api/sim-resource#move-sims-between-subaccounts). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sim </returns>
        public static SimResource Update(
                                          string pathSid,
                                          string uniqueName = null,
                                          Twilio.Http.HttpMethod callbackMethod = null,
                                          Uri callbackUrl = null,
                                          string friendlyName = null,
                                          string ratePlan = null,
                                          SimResource.StatusEnum status = null,
                                          Twilio.Http.HttpMethod commandsCallbackMethod = null,
                                          Uri commandsCallbackUrl = null,
                                          Twilio.Http.HttpMethod smsFallbackMethod = null,
                                          Uri smsFallbackUrl = null,
                                          Twilio.Http.HttpMethod smsMethod = null,
                                          Uri smsUrl = null,
                                          Twilio.Http.HttpMethod voiceFallbackMethod = null,
                                          Uri voiceFallbackUrl = null,
                                          Twilio.Http.HttpMethod voiceMethod = null,
                                          Uri voiceUrl = null,
                                          SimResource.ResetStatusEnum resetStatus = null,
                                          string accountSid = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateSimOptions(pathSid){ UniqueName = uniqueName, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, ResetStatus = resetStatus, AccountSid = accountSid };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Updates the given properties of a Sim resource on your Account. </summary>
        /// <param name="pathSid"> The SID or the `unique_name` of the Sim resource to update. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used in place of the `sid` in the URL path to address the resource. </param>
        /// <param name="callbackMethod"> The HTTP method we should use to call `callback_url`. Can be: `POST` or `GET`. The default is `POST`. </param>
        /// <param name="callbackUrl"> The URL we should call using the `callback_url` when the SIM has finished updating. When the SIM transitions from `new` to `ready` or from any status to `deactivated`, we call this URL when the status changes to an intermediate status (`ready` or `deactivated`) and again when the status changes to its final status (`active` or `canceled`). </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Sim resource. It does not need to be unique. </param>
        /// <param name="ratePlan"> The SID or unique name of the [RatePlan resource](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource) to which the Sim resource should be assigned. </param>
        /// <param name="status">  </param>
        /// <param name="commandsCallbackMethod"> The HTTP method we should use to call `commands_callback_url`. Can be: `POST` or `GET`. The default is `POST`. </param>
        /// <param name="commandsCallbackUrl"> The URL we should call using the `commands_callback_method` when the SIM sends a [Command](https://www.twilio.com/docs/iot/wireless/api/command-resource). Your server should respond with an HTTP status code in the 200 range; any response body is ignored. </param>
        /// <param name="smsFallbackMethod"> The HTTP method we should use to call `sms_fallback_url`. Can be: `GET` or `POST`. Default is `POST`. </param>
        /// <param name="smsFallbackUrl"> The URL we should call using the `sms_fallback_method` when an error occurs while retrieving or executing the TwiML requested from `sms_url`. </param>
        /// <param name="smsMethod"> The HTTP method we should use to call `sms_url`. Can be: `GET` or `POST`. Default is `POST`. </param>
        /// <param name="smsUrl"> The URL we should call using the `sms_method` when the SIM-connected device sends an SMS message that is not a [Command](https://www.twilio.com/docs/iot/wireless/api/command-resource). </param>
        /// <param name="voiceFallbackMethod"> Deprecated. </param>
        /// <param name="voiceFallbackUrl"> Deprecated. </param>
        /// <param name="voiceMethod"> Deprecated. </param>
        /// <param name="voiceUrl"> Deprecated. </param>
        /// <param name="resetStatus">  </param>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) to which the Sim resource should belong. The Account SID can only be that of the requesting Account or that of a [Subaccount](https://www.twilio.com/docs/iam/api/subaccounts) of the requesting Account. Only valid when the Sim resource's status is `new`. For more information, see the [Move SIMs between Subaccounts documentation](https://www.twilio.com/docs/iot/wireless/api/sim-resource#move-sims-between-subaccounts). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sim </returns>
        public static async System.Threading.Tasks.Task<SimResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string uniqueName = null,
                                                                              Twilio.Http.HttpMethod callbackMethod = null,
                                                                              Uri callbackUrl = null,
                                                                              string friendlyName = null,
                                                                              string ratePlan = null,
                                                                              SimResource.StatusEnum status = null,
                                                                              Twilio.Http.HttpMethod commandsCallbackMethod = null,
                                                                              Uri commandsCallbackUrl = null,
                                                                              Twilio.Http.HttpMethod smsFallbackMethod = null,
                                                                              Uri smsFallbackUrl = null,
                                                                              Twilio.Http.HttpMethod smsMethod = null,
                                                                              Uri smsUrl = null,
                                                                              Twilio.Http.HttpMethod voiceFallbackMethod = null,
                                                                              Uri voiceFallbackUrl = null,
                                                                              Twilio.Http.HttpMethod voiceMethod = null,
                                                                              Uri voiceUrl = null,
                                                                              SimResource.ResetStatusEnum resetStatus = null,
                                                                              string accountSid = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateSimOptions(pathSid){ UniqueName = uniqueName, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl, SmsFallbackMethod = smsFallbackMethod, SmsFallbackUrl = smsFallbackUrl, SmsMethod = smsMethod, SmsUrl = smsUrl, VoiceFallbackMethod = voiceFallbackMethod, VoiceFallbackUrl = voiceFallbackUrl, VoiceMethod = voiceMethod, VoiceUrl = voiceUrl, ResetStatus = resetStatus, AccountSid = accountSid };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SimResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SimResource object represented by the provided JSON </returns>
        public static SimResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SimResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the Sim resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) to which the Sim resource belongs. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [RatePlan resource](https://www.twilio.com/docs/iot/wireless/api/rateplan-resource) to which the Sim resource is assigned. </summary> 
        [JsonProperty("rate_plan_sid")]
        public string RatePlanSid { get; private set; }

        ///<summary> The string that you assigned to describe the Sim resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The [ICCID](https://en.wikipedia.org/wiki/SIM_card#ICCID) associated with the SIM. </summary> 
        [JsonProperty("iccid")]
        public string Iccid { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("e_id")]
        public string EId { get; private set; }

        
        [JsonProperty("status")]
        public SimResource.StatusEnum Status { get; private set; }

        
        [JsonProperty("reset_status")]
        public SimResource.ResetStatusEnum ResetStatus { get; private set; }

        ///<summary> The URL we call using the `commands_callback_method` when the SIM originates a machine-to-machine [Command](https://www.twilio.com/docs/iot/wireless/api/command-resource). Your server should respond with an HTTP status code in the 200 range; any response body will be ignored. </summary> 
        [JsonProperty("commands_callback_url")]
        public Uri CommandsCallbackUrl { get; private set; }

        ///<summary> The HTTP method we use to call `commands_callback_url`.  Can be: `POST` or `GET`. Default is `POST`. </summary> 
        [JsonProperty("commands_callback_method")]
        public Twilio.Http.HttpMethod CommandsCallbackMethod { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("sms_fallback_method")]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("sms_method")]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }

        ///<summary> Deprecated. The HTTP method we use to call `voice_fallback_url`. Can be: `GET` or `POST`. Default is `POST`. </summary> 
        [JsonProperty("voice_fallback_method")]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; private set; }

        ///<summary> Deprecated. The URL we call using the `voice_fallback_method` when an error occurs while retrieving or executing the TwiML requested from `voice_url`. </summary> 
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; private set; }

        ///<summary> Deprecated. The HTTP method we use to call `voice_url`. Can be: `GET` or `POST`. Default is `POST`. </summary> 
        [JsonProperty("voice_method")]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }

        ///<summary> Deprecated. The URL we call using the `voice_method` when the SIM-connected device makes a voice call. </summary> 
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the Sim resource was last updated specified in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of related subresources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> Deprecated. </summary> 
        [JsonProperty("ip_address")]
        public string IpAddress { get; private set; }



        private SimResource() {

        }
    }
}


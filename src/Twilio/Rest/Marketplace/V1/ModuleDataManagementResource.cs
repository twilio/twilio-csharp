/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Marketplace
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



namespace Twilio.Rest.Marketplace.V1
{
    public class ModuleDataManagementResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchModuleDataManagementOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Listing/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Marketplace,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch ModuleDataManagement parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ModuleDataManagement </returns>
        public static ModuleDataManagementResource Fetch(FetchModuleDataManagementOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch ModuleDataManagement parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ModuleDataManagement </returns>
        public static async System.Threading.Tasks.Task<ModuleDataManagementResource> FetchAsync(FetchModuleDataManagementOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ModuleDataManagement </returns>
        public static ModuleDataManagementResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchModuleDataManagementOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ModuleDataManagement </returns>
        public static async System.Threading.Tasks.Task<ModuleDataManagementResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchModuleDataManagementOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateModuleDataManagementOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Listing/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Marketplace,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update ModuleDataManagement parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ModuleDataManagement </returns>
        public static ModuleDataManagementResource Update(UpdateModuleDataManagementOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update ModuleDataManagement parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ModuleDataManagement </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ModuleDataManagementResource> UpdateAsync(UpdateModuleDataManagementOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid">  </param>
        /// <param name="moduleInfo">  </param>
        /// <param name="description">  </param>
        /// <param name="documentation">  </param>
        /// <param name="policies">  </param>
        /// <param name="support">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ModuleDataManagement </returns>
        public static ModuleDataManagementResource Update(
                                          string pathSid,
                                          string moduleInfo = null,
                                          string description = null,
                                          string documentation = null,
                                          string policies = null,
                                          string support = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateModuleDataManagementOptions(pathSid){ ModuleInfo = moduleInfo, Description = description, Documentation = documentation, Policies = policies, Support = support };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid">  </param>
        /// <param name="moduleInfo">  </param>
        /// <param name="description">  </param>
        /// <param name="documentation">  </param>
        /// <param name="policies">  </param>
        /// <param name="support">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ModuleDataManagement </returns>
        public static async System.Threading.Tasks.Task<ModuleDataManagementResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string moduleInfo = null,
                                                                              string description = null,
                                                                              string documentation = null,
                                                                              string policies = null,
                                                                              string support = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateModuleDataManagementOptions(pathSid){ ModuleInfo = moduleInfo, Description = description, Documentation = documentation, Policies = policies, Support = support };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ModuleDataManagementResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ModuleDataManagementResource object represented by the provided JSON </returns>
        public static ModuleDataManagementResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ModuleDataManagementResource>(json);
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

    
        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The sid </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The description </summary> 
        [JsonProperty("description")]
        public object Description { get; private set; }

        ///<summary> The support </summary> 
        [JsonProperty("support")]
        public object Support { get; private set; }

        ///<summary> The policies </summary> 
        [JsonProperty("policies")]
        public object Policies { get; private set; }

        ///<summary> The module_info </summary> 
        [JsonProperty("module_info")]
        public object ModuleInfo { get; private set; }

        ///<summary> The documentation </summary> 
        [JsonProperty("documentation")]
        public object Documentation { get; private set; }



        private ModuleDataManagementResource() {

        }
    }
}


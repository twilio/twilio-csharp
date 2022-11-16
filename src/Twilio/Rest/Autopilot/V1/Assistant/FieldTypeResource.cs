/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Autopilot
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



namespace Twilio.Rest.Autopilot.V1.Assistant
{
    public class FieldTypeResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateFieldTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/FieldTypes";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Autopilot,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Create(CreateFieldTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<FieldTypeResource> CreateAsync(CreateFieldTypeOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the new resource. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the new resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Create(
                                          string pathAssistantSid,
                                          string uniqueName,
                                          string friendlyName = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateFieldTypeOptions(pathAssistantSid, uniqueName){  FriendlyName = friendlyName };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the new resource. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the new resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<FieldTypeResource> CreateAsync(
                                                                                  string pathAssistantSid,
                                                                                  string uniqueName,
                                                                                  string friendlyName = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateFieldTypeOptions(pathAssistantSid, uniqueName){  FriendlyName = friendlyName };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        private static Request BuildDeleteRequest(DeleteFieldTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/FieldTypes/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static bool Delete(DeleteFieldTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFieldTypeOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static bool Delete(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFieldTypeOptions(pathAssistantSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFieldTypeOptions(pathAssistantSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchFieldTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/FieldTypes/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Fetch(FetchFieldTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<FieldTypeResource> FetchAsync(FetchFieldTypeOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Fetch(
                                         string pathAssistantSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchFieldTypeOptions(pathAssistantSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<FieldTypeResource> FetchAsync(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFieldTypeOptions(pathAssistantSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadFieldTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/FieldTypes";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static ResourceSet<FieldTypeResource> Read(ReadFieldTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<FieldTypeResource>.FromJson("field_types", response.Content);
            return new ResourceSet<FieldTypeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<FieldTypeResource>> ReadAsync(ReadFieldTypeOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<FieldTypeResource>.FromJson("field_types", response.Content);
            return new ResourceSet<FieldTypeResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of FieldType </returns>
        public static ResourceSet<FieldTypeResource> Read(
                                                     string pathAssistantSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadFieldTypeOptions(pathAssistantSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<FieldTypeResource>> ReadAsync(
                                                                                             string pathAssistantSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadFieldTypeOptions(pathAssistantSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<FieldTypeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<FieldTypeResource>.FromJson("field_types", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<FieldTypeResource> NextPage(Page<FieldTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<FieldTypeResource>.FromJson("field_types", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<FieldTypeResource> PreviousPage(Page<FieldTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<FieldTypeResource>.FromJson("field_types", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateFieldTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/FieldTypes/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Autopilot,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Update(UpdateFieldTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update FieldType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<FieldTypeResource> UpdateAsync(UpdateFieldTypeOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FieldType </returns>
        public static FieldTypeResource Update(
                                          string pathAssistantSid,
                                          string pathSid,
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateFieldTypeOptions(pathAssistantSid, pathSid){ FriendlyName = friendlyName, UniqueName = uniqueName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the FieldType resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FieldType </returns>
        public static async System.Threading.Tasks.Task<FieldTypeResource> UpdateAsync(
                                                                              string pathAssistantSid,
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              string uniqueName = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateFieldTypeOptions(pathAssistantSid, pathSid){ FriendlyName = friendlyName, UniqueName = uniqueName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FieldTypeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FieldTypeResource object represented by the provided JSON </returns>
        public static FieldTypeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<FieldTypeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The SID of the Account that created the resource </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT when the resource was created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT when the resource was last updated </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The string that you assigned to describe the resource </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A list of the URLs of related resources </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The SID of the Assistant that is the parent of the resource </summary> 
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }

        ///<summary> The unique string that identifies the resource </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The absolute URL of the FieldType resource </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private FieldTypeResource() {

        }
    }
}


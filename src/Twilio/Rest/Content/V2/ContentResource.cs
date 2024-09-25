/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Content
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





namespace Twilio.Rest.Content.V2
{
    public class ContentResource : Resource
    {
    

    

        
        private static Request BuildReadRequest(ReadContentOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Content";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Content,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of Contents belonging to the account used to make the request </summary>
        /// <param name="options"> Read Content parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Content </returns>
        public static ResourceSet<ContentResource> Read(ReadContentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ContentResource>.FromJson("contents", response.Content);
            return new ResourceSet<ContentResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Contents belonging to the account used to make the request </summary>
        /// <param name="options"> Read Content parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Content </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ContentResource>> ReadAsync(ReadContentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ContentResource>.FromJson("contents", response.Content);
            return new ResourceSet<ContentResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of Contents belonging to the account used to make the request </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="sortByDate"> Whether to sort by ascending or descending date updated </param>
        /// <param name="sortByContentName"> Whether to sort by ascending or descending content name </param>
        /// <param name="dateCreatedAfter"> Filter by >=[date-time] </param>
        /// <param name="dateCreatedBefore"> Filter by <=[date-time] </param>
        /// <param name="contentName"> Filter by Regex Pattern in content name </param>
        /// <param name="content"> Filter by Regex Pattern in template content </param>
        /// <param name="language"> Filter by array of valid language(s) </param>
        /// <param name="contentType"> Filter by array of contentType(s) </param>
        /// <param name="channelEligibility"> Filter by array of ChannelEligibility(s), where ChannelEligibility=<channel>:<status> </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Content </returns>
        public static ResourceSet<ContentResource> Read(
                                                     int? pageSize = null,
                                                     string sortByDate = null,
                                                     string sortByContentName = null,
                                                     DateTime? dateCreatedAfter = null,
                                                     DateTime? dateCreatedBefore = null,
                                                     string contentName = null,
                                                     string content = null,
                                                     List<string> language = null,
                                                     List<string> contentType = null,
                                                     List<string> channelEligibility = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadContentOptions(){ PageSize = pageSize, SortByDate = sortByDate, SortByContentName = sortByContentName, DateCreatedAfter = dateCreatedAfter, DateCreatedBefore = dateCreatedBefore, ContentName = contentName, Content = content, Language = language, ContentType = contentType, ChannelEligibility = channelEligibility, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Contents belonging to the account used to make the request </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="sortByDate"> Whether to sort by ascending or descending date updated </param>
        /// <param name="sortByContentName"> Whether to sort by ascending or descending content name </param>
        /// <param name="dateCreatedAfter"> Filter by >=[date-time] </param>
        /// <param name="dateCreatedBefore"> Filter by <=[date-time] </param>
        /// <param name="contentName"> Filter by Regex Pattern in content name </param>
        /// <param name="content"> Filter by Regex Pattern in template content </param>
        /// <param name="language"> Filter by array of valid language(s) </param>
        /// <param name="contentType"> Filter by array of contentType(s) </param>
        /// <param name="channelEligibility"> Filter by array of ChannelEligibility(s), where ChannelEligibility=<channel>:<status> </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Content </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ContentResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             string sortByDate = null,
                                                                                             string sortByContentName = null,
                                                                                             DateTime? dateCreatedAfter = null,
                                                                                             DateTime? dateCreatedBefore = null,
                                                                                             string contentName = null,
                                                                                             string content = null,
                                                                                             List<string> language = null,
                                                                                             List<string> contentType = null,
                                                                                             List<string> channelEligibility = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadContentOptions(){ PageSize = pageSize, SortByDate = sortByDate, SortByContentName = sortByContentName, DateCreatedAfter = dateCreatedAfter, DateCreatedBefore = dateCreatedBefore, ContentName = contentName, Content = content, Language = language, ContentType = contentType, ChannelEligibility = channelEligibility, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ContentResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ContentResource>.FromJson("contents", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ContentResource> NextPage(Page<ContentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ContentResource>.FromJson("contents", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ContentResource> PreviousPage(Page<ContentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ContentResource>.FromJson("contents", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ContentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ContentResource object represented by the provided JSON </returns>
        public static ContentResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ContentResource>(json);
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

    
        ///<summary> The date and time in GMT that the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The unique string that that we created to identify the Content resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/usage/api/account) that created Content resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> A string name used to describe the Content resource. Not visible to the end recipient. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Two-letter (ISO 639-1) language code (e.g., en) identifying the language the Content resource is in. </summary> 
        [JsonProperty("language")]
        public string Language { get; private set; }

        ///<summary> Defines the default placeholder values for variables included in the Content resource. e.g. {\"1\": \"Customer_Name\"}. </summary> 
        [JsonProperty("variables")]
        public object Variables { get; private set; }

        ///<summary> The [Content types](https://www.twilio.com/docs/content/content-types-overview) (e.g. twilio/text) for this Content resource. </summary> 
        [JsonProperty("types")]
        public object Types { get; private set; }

        ///<summary> The URL of the resource, relative to `https://content.twilio.com`. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> A list of links related to the Content resource, such as approval_fetch and approval_create </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ContentResource() {

        }
    }
}


/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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



namespace Twilio.Rest.Api.V2010.Account.Call
{
    public class EventResource : Resource
    {
    

    

        
        private static Request BuildReadRequest(ReadEventOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Events.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all events for a call. </summary>
        /// <param name="options"> Read Event parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Event </returns>
        public static ResourceSet<EventResource> Read(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all events for a call. </summary>
        /// <param name="options"> Read Event parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Event </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(ReadEventOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<EventResource>.FromJson("events", response.Content);
            return new ResourceSet<EventResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all events for a call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="pathAccountSid"> The unique SID identifier of the Account. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Event </returns>
        public static ResourceSet<EventResource> Read(
                                                     string pathCallSid,
                                                     string pathAccountSid = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(pathCallSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all events for a call. </summary>
        /// <param name="pathCallSid"> The unique SID identifier of the Call. </param>
        /// <param name="pathAccountSid"> The unique SID identifier of the Account. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Event </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(
                                                                                             string pathCallSid,
                                                                                             string pathAccountSid = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadEventOptions(pathCallSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<EventResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<EventResource> PreviousPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventResource>.FromJson("events", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a EventResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventResource object represented by the provided JSON </returns>
        public static EventResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EventResource>(json);
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

    
        ///<summary> Contains a dictionary representing the request of the call. </summary> 
        [JsonProperty("request")]
        public object Request { get; private set; }

        ///<summary> Contains a dictionary representing the call response, including a list of the call events. </summary> 
        [JsonProperty("response")]
        public object Response { get; private set; }



        private EventResource() {

        }
    }
}


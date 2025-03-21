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



namespace Twilio.Rest.Api.V2010.Account.Queue
{
    public class MemberResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchMemberOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathQueueSid = options.PathQueueSid;
            path = path.Replace("{"+"QueueSid"+"}", PathQueueSid);
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

        /// <summary> Fetch a specific member from the queue </summary>
        /// <param name="options"> Fetch Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Fetch(FetchMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific member from the queue </summary>
        /// <param name="options"> Fetch Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(FetchMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific member from the queue </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members to fetch. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource(s) to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Fetch(
                                         string pathQueueSid, 
                                         string pathCallSid, 
                                         string pathAccountSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(pathQueueSid, pathCallSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific member from the queue </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members to fetch. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource(s) to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(string pathQueueSid, string pathCallSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(pathQueueSid, pathCallSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadMemberOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Queues/{QueueSid}/Members.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathQueueSid = options.PathQueueSid;
            path = path.Replace("{"+"QueueSid"+"}", PathQueueSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve the members of the queue </summary>
        /// <param name="options"> Read Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static ResourceSet<MemberResource> Read(ReadMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<MemberResource>.FromJson("queue_members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve the members of the queue </summary>
        /// <param name="options"> Read Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(ReadMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<MemberResource>.FromJson("queue_members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve the members of the queue </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static ResourceSet<MemberResource> Read(
                                                     string pathQueueSid,
                                                     string pathAccountSid = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(pathQueueSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve the members of the queue </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(
                                                                                             string pathQueueSid,
                                                                                             string pathAccountSid = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(pathQueueSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<MemberResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("queue_members", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<MemberResource> NextPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("queue_members", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<MemberResource> PreviousPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<MemberResource>.FromJson("queue_members", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateMemberOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathQueueSid = options.PathQueueSid;
            path = path.Replace("{"+"QueueSid"+"}", PathQueueSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL </summary>
        /// <param name="options"> Update Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Update(UpdateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL </summary>
        /// <param name="options"> Update Member parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(UpdateMemberOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members to update. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource(s) to update. </param>
        /// <param name="url"> The absolute URL of the Queue resource. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to update. </param>
        /// <param name="method"> How to pass the update request data. Can be `GET` or `POST` and the default is `POST`. `POST` sends the data as encoded form data and `GET` sends the data as query parameters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Member </returns>
        public static MemberResource Update(
                                          string pathQueueSid,
                                          string pathCallSid,
                                          Uri url,
                                          string pathAccountSid = null,
                                          Twilio.Http.HttpMethod method = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(pathQueueSid, pathCallSid, url){ PathAccountSid = pathAccountSid, Method = method };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL </summary>
        /// <param name="pathQueueSid"> The SID of the Queue in which to find the members to update. </param>
        /// <param name="pathCallSid"> The [Call](https://www.twilio.com/docs/voice/api/call-resource) SID of the resource(s) to update. </param>
        /// <param name="url"> The absolute URL of the Queue resource. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Member resource(s) to update. </param>
        /// <param name="method"> How to pass the update request data. Can be `GET` or `POST` and the default is `POST`. `POST` sends the data as encoded form data and `GET` sends the data as query parameters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Member </returns>
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(
                                                                              string pathQueueSid,
                                                                              string pathCallSid,
                                                                              Uri url,
                                                                              string pathAccountSid = null,
                                                                              Twilio.Http.HttpMethod method = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(pathQueueSid, pathCallSid, url){ PathAccountSid = pathAccountSid, Method = method };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns>
        public static MemberResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
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

    
        ///<summary> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Member resource is associated with. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> The date that the member was enqueued, given in RFC 2822 format. </summary> 
        [JsonProperty("date_enqueued")]
        public DateTime? DateEnqueued { get; private set; }

        ///<summary> This member's current position in the queue. </summary> 
        [JsonProperty("position")]
        public int? Position { get; private set; }

        ///<summary> The URI of the resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        ///<summary> The number of seconds the member has been in the queue. </summary> 
        [JsonProperty("wait_time")]
        public int? WaitTime { get; private set; }

        ///<summary> The SID of the Queue the member is in. </summary> 
        [JsonProperty("queue_sid")]
        public string QueueSid { get; private set; }



        private MemberResource() {

        }
    }
}


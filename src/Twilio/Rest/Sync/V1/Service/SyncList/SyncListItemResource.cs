/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Sync
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


namespace Twilio.Rest.Sync.V1.Service.SyncList
{
    public class SyncListItemResource : Resource
    {
    
        public sealed class QueryFromBoundTypeEnum : StringEnum
        {
            private QueryFromBoundTypeEnum(string value) : base(value) {}
            public QueryFromBoundTypeEnum() {}
            public static implicit operator QueryFromBoundTypeEnum(string value)
            {
                return new QueryFromBoundTypeEnum(value);
            }
            public static readonly QueryFromBoundTypeEnum Inclusive = new QueryFromBoundTypeEnum("inclusive");
            public static readonly QueryFromBoundTypeEnum Exclusive = new QueryFromBoundTypeEnum("exclusive");

        }
        public sealed class QueryResultOrderEnum : StringEnum
        {
            private QueryResultOrderEnum(string value) : base(value) {}
            public QueryResultOrderEnum() {}
            public static implicit operator QueryResultOrderEnum(string value)
            {
                return new QueryResultOrderEnum(value);
            }
            public static readonly QueryResultOrderEnum Asc = new QueryResultOrderEnum("asc");
            public static readonly QueryResultOrderEnum Desc = new QueryResultOrderEnum("desc");

        }

        
        private static Request BuildCreateRequest(CreateSyncListItemOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Lists/{ListSid}/Items";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathListSid = options.PathListSid;
            path = path.Replace("{"+"ListSid"+"}", PathListSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Create(CreateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<SyncListItemResource> CreateAsync(CreateSyncListItemOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the new List Item in. </param>
        /// <param name="pathListSid"> The SID of the Sync List to add the new List Item to. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the List Item stores. Can be up to 16 KiB in length. </param>
        /// <param name="ttl"> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </param>
        /// <param name="itemTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item expires (time-to-live) and is deleted. </param>
        /// <param name="collectionTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item's parent Sync List expires (time-to-live) and is deleted. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Create(
                                          string pathServiceSid,
                                          string pathListSid,
                                          object data,
                                          int? ttl = null,
                                          int? itemTtl = null,
                                          int? collectionTtl = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateSyncListItemOptions(pathServiceSid, pathListSid, data){  Ttl = ttl, ItemTtl = itemTtl, CollectionTtl = collectionTtl };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the new List Item in. </param>
        /// <param name="pathListSid"> The SID of the Sync List to add the new List Item to. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the List Item stores. Can be up to 16 KiB in length. </param>
        /// <param name="ttl"> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </param>
        /// <param name="itemTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item expires (time-to-live) and is deleted. </param>
        /// <param name="collectionTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item's parent Sync List expires (time-to-live) and is deleted. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<SyncListItemResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string pathListSid,
                                                                                  object data,
                                                                                  int? ttl = null,
                                                                                  int? itemTtl = null,
                                                                                  int? collectionTtl = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateSyncListItemOptions(pathServiceSid, pathListSid, data){  Ttl = ttl, ItemTtl = itemTtl, CollectionTtl = collectionTtl };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        private static Request BuildDeleteRequest(DeleteSyncListItemOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Lists/{ListSid}/Items/{Index}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathListSid = options.PathListSid;
            path = path.Replace("{"+"ListSid"+"}", PathListSid);
            string PathIndex = options.PathIndex.ToString();
            path = path.Replace("{"+"Index"+"}", PathIndex);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static bool Delete(DeleteSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncListItemOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to delete. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to delete. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to delete. </param>
        /// <param name="ifMatch"> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static bool Delete(string pathServiceSid, string pathListSid, int? pathIndex, string ifMatch = null, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListItemOptions(pathServiceSid, pathListSid, pathIndex)            { IfMatch = ifMatch }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to delete. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to delete. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to delete. </param>
        /// <param name="ifMatch"> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathListSid, int? pathIndex, string ifMatch = null, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListItemOptions(pathServiceSid, pathListSid, pathIndex)  { IfMatch = ifMatch };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchSyncListItemOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Lists/{ListSid}/Items/{Index}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathListSid = options.PathListSid;
            path = path.Replace("{"+"ListSid"+"}", PathListSid);
            string PathIndex = options.PathIndex.ToString();
            path = path.Replace("{"+"Index"+"}", PathIndex);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Fetch(FetchSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<SyncListItemResource> FetchAsync(FetchSyncListItemOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to fetch. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to fetch. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Fetch(
                                         string pathServiceSid, 
                                         string pathListSid, 
                                         int? pathIndex, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchSyncListItemOptions(pathServiceSid, pathListSid, pathIndex){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to fetch. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to fetch. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<SyncListItemResource> FetchAsync(string pathServiceSid, string pathListSid, int? pathIndex, ITwilioRestClient client = null)
        {
            var options = new FetchSyncListItemOptions(pathServiceSid, pathListSid, pathIndex){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSyncListItemOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Lists/{ListSid}/Items";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathListSid = options.PathListSid;
            path = path.Replace("{"+"ListSid"+"}", PathListSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static ResourceSet<SyncListItemResource> Read(ReadSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SyncListItemResource>.FromJson("items", response.Content);
            return new ResourceSet<SyncListItemResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListItemResource>> ReadAsync(ReadSyncListItemOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SyncListItemResource>.FromJson("items", response.Content);
            return new ResourceSet<SyncListItemResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the List Item resources to read. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the List Items to read. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="order"> How to order the List Items returned by their `index` value. Can be: `asc` (ascending) or `desc` (descending) and the default is ascending. </param>
        /// <param name="from"> The `index` of the first Sync List Item resource to read. See also `bounds`. </param>
        /// <param name="bounds"> Whether to include the List Item referenced by the `from` parameter. Can be: `inclusive` to include the List Item referenced by the `from` parameter or `exclusive` to start with the next List Item. The default value is `inclusive`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static ResourceSet<SyncListItemResource> Read(
                                                     string pathServiceSid,
                                                     string pathListSid,
                                                     SyncListItemResource.QueryResultOrderEnum order = null,
                                                     string from = null,
                                                     SyncListItemResource.QueryFromBoundTypeEnum bounds = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadSyncListItemOptions(pathServiceSid, pathListSid){ Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the List Item resources to read. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the List Items to read. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="order"> How to order the List Items returned by their `index` value. Can be: `asc` (ascending) or `desc` (descending) and the default is ascending. </param>
        /// <param name="from"> The `index` of the first Sync List Item resource to read. See also `bounds`. </param>
        /// <param name="bounds"> Whether to include the List Item referenced by the `from` parameter. Can be: `inclusive` to include the List Item referenced by the `from` parameter or `exclusive` to start with the next List Item. The default value is `inclusive`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListItemResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             string pathListSid,
                                                                                             SyncListItemResource.QueryResultOrderEnum order = null,
                                                                                             string from = null,
                                                                                             SyncListItemResource.QueryFromBoundTypeEnum bounds = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadSyncListItemOptions(pathServiceSid, pathListSid){ Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SyncListItemResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SyncListItemResource>.FromJson("items", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SyncListItemResource> NextPage(Page<SyncListItemResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SyncListItemResource>.FromJson("items", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SyncListItemResource> PreviousPage(Page<SyncListItemResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SyncListItemResource>.FromJson("items", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateSyncListItemOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Lists/{ListSid}/Items/{Index}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathListSid = options.PathListSid;
            path = path.Replace("{"+"ListSid"+"}", PathListSid);
            string PathIndex = options.PathIndex.ToString();
            path = path.Replace("{"+"Index"+"}", PathIndex);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Update(UpdateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update SyncListItem parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<SyncListItemResource> UpdateAsync(UpdateSyncListItemOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to update. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to update. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to update. </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the List Item stores. Can be up to 16 KiB in length. </param>
        /// <param name="ttl"> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </param>
        /// <param name="itemTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item expires (time-to-live) and is deleted. </param>
        /// <param name="collectionTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item's parent Sync List expires (time-to-live) and is deleted. This parameter can only be used when the List Item's `data` or `ttl` is updated in the same request. </param>
        /// <param name="ifMatch"> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListItem </returns>
        public static SyncListItemResource Update(
                                          string pathServiceSid,
                                          string pathListSid,
                                          int? pathIndex,
                                          object data = null,
                                          int? ttl = null,
                                          int? itemTtl = null,
                                          int? collectionTtl = null,
                                          string ifMatch = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListItemOptions(pathServiceSid, pathListSid, pathIndex){ Data = data, Ttl = ttl, ItemTtl = itemTtl, CollectionTtl = collectionTtl, IfMatch = ifMatch };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync List Item resource to update. </param>
        /// <param name="pathListSid"> The SID of the Sync List with the Sync List Item resource to update. Can be the Sync List resource's `sid` or its `unique_name`. </param>
        /// <param name="pathIndex"> The index of the Sync List Item resource to update. </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the List Item stores. Can be up to 16 KiB in length. </param>
        /// <param name="ttl"> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </param>
        /// <param name="itemTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item expires (time-to-live) and is deleted. </param>
        /// <param name="collectionTtl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the List Item's parent Sync List expires (time-to-live) and is deleted. This parameter can only be used when the List Item's `data` or `ttl` is updated in the same request. </param>
        /// <param name="ifMatch"> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListItem </returns>
        public static async System.Threading.Tasks.Task<SyncListItemResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathListSid,
                                                                              int? pathIndex,
                                                                              object data = null,
                                                                              int? ttl = null,
                                                                              int? itemTtl = null,
                                                                              int? collectionTtl = null,
                                                                              string ifMatch = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListItemOptions(pathServiceSid, pathListSid, pathIndex){ Data = data, Ttl = ttl, ItemTtl = itemTtl, CollectionTtl = collectionTtl, IfMatch = ifMatch };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncListItemResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListItemResource object represented by the provided JSON </returns>
        public static SyncListItemResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SyncListItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The automatically generated index of the List Item. The `index` values of the List Items in a Sync List can have gaps in their sequence. </summary> 
        [JsonProperty("index")]
        public int? Index { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the List Item resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The SID of the Sync List that contains the List Item. </summary> 
        [JsonProperty("list_sid")]
        public string ListSid { get; private set; }

        ///<summary> The absolute URL of the List Item resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The current revision of the item, represented as a string. </summary> 
        [JsonProperty("revision")]
        public string Revision { get; private set; }

        ///<summary> An arbitrary, schema-less object that the List Item stores. Can be up to 16 KiB in length. </summary> 
        [JsonProperty("data")]
        public object Data { get; private set; }

        ///<summary> The date and time in GMT when the List Item expires and will be deleted, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. If the List Item does not expire, this value is `null`. The List Item resource might not be deleted immediately after it expires. </summary> 
        [JsonProperty("date_expires")]
        public DateTime? DateExpires { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The identity of the List Item's creator. If the item is created from the client SDK, the value matches the Access Token's `identity` field. If the item was created from the REST API, the value is `system`. </summary> 
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }



        private SyncListItemResource() {

        }
    }
}


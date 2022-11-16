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


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Sync.V1.Service.SyncMap
{

    /// <summary> create </summary>
    public class CreateSyncMapItemOptions : IOptions<SyncMapItemResource>
    {
        
        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the Map Item in. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Sync Map to add the new Map Item to. Can be the Sync Map resource's `sid` or its `unique_name`. </summary> 
        public string PathMapSid { get; }

        ///<summary> The unique, user-defined key for the Map Item. Can be up to 320 characters long. </summary> 
        public string Key { get; }

        ///<summary> A JSON string that represents an arbitrary, schema-less object that the Map Item stores. Can be up to 16 KiB in length. </summary> 
        public object Data { get; }

        ///<summary> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </summary> 
        public int? Ttl { get; set; }

        ///<summary> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Map Item expires (time-to-live) and is deleted. </summary> 
        public int? ItemTtl { get; set; }

        ///<summary> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Map Item's parent Sync Map expires (time-to-live) and is deleted. </summary> 
        public int? CollectionTtl { get; set; }


        /// <summary> Construct a new CreateSyncMapItemOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the Map Item in. </param>
        /// <param name="pathMapSid"> The SID of the Sync Map to add the new Map Item to. Can be the Sync Map resource's `sid` or its `unique_name`. </param>
        /// <param name="key"> The unique, user-defined key for the Map Item. Can be up to 320 characters long. </param>
        /// <param name="data"> A JSON string that represents an arbitrary, schema-less object that the Map Item stores. Can be up to 16 KiB in length. </param>

        public CreateSyncMapItemOptions(string pathServiceSid, string pathMapSid, string key, object data)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            Key = key;
            Data = data;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Key != null)
            {
                p.Add(new KeyValuePair<string, string>("Key", Key));
            }
            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
            }
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.ToString()));
            }
            if (ItemTtl != null)
            {
                p.Add(new KeyValuePair<string, string>("ItemTtl", ItemTtl.ToString()));
            }
            if (CollectionTtl != null)
            {
                p.Add(new KeyValuePair<string, string>("CollectionTtl", CollectionTtl.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteSyncMapItemOptions : IOptions<SyncMapItemResource>
    {
        
        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to delete. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Sync Map with the Sync Map Item resource to delete. Can be the Sync Map resource's `sid` or its `unique_name`. </summary> 
        public string PathMapSid { get; }

        ///<summary> The `key` value of the Sync Map Item resource to delete. </summary> 
        public string PathKey { get; }

        ///<summary> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </summary> 
        public string IfMatch { get; set; }



        /// <summary> Construct a new DeleteSyncMapItemOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to delete. </param>
        /// <param name="pathMapSid"> The SID of the Sync Map with the Sync Map Item resource to delete. Can be the Sync Map resource's `sid` or its `unique_name`. </param>
        /// <param name="pathKey"> The `key` value of the Sync Map Item resource to delete. </param>

        public DeleteSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (IfMatch != null)
        {
            p.Add(new KeyValuePair<string, string>("If-Match", IfMatch));
        }
        return p;
    }

    }


    /// <summary> fetch </summary>
    public class FetchSyncMapItemOptions : IOptions<SyncMapItemResource>
    {
    
        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to fetch. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Sync Map with the Sync Map Item resource to fetch. Can be the Sync Map resource's `sid` or its `unique_name`. </summary> 
        public string PathMapSid { get; }

        ///<summary> The `key` value of the Sync Map Item resource to fetch. </summary> 
        public string PathKey { get; }



        /// <summary> Construct a new FetchSyncMapItemOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to fetch. </param>
        /// <param name="pathMapSid"> The SID of the Sync Map with the Sync Map Item resource to fetch. Can be the Sync Map resource's `sid` or its `unique_name`. </param>
        /// <param name="pathKey"> The `key` value of the Sync Map Item resource to fetch. </param>

        public FetchSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadSyncMapItemOptions : ReadOptions<SyncMapItemResource>
    {
    
        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Map Item resources to read. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Sync Map with the Sync Map Item resource to fetch. Can be the Sync Map resource's `sid` or its `unique_name`. </summary> 
        public string PathMapSid { get; }

        ///<summary> How to order the Map Items returned by their `key` value. Can be: `asc` (ascending) or `desc` (descending) and the default is ascending. Map Items are [ordered lexicographically](https://en.wikipedia.org/wiki/Lexicographical_order) by Item key. </summary> 
        public SyncMapItemResource.QueryResultOrderEnum Order { get; set; }

        ///<summary> The `key` of the first Sync Map Item resource to read. See also `bounds`. </summary> 
        public string From { get; set; }

        ///<summary> Whether to include the Map Item referenced by the `from` parameter. Can be: `inclusive` to include the Map Item referenced by the `from` parameter or `exclusive` to start with the next Map Item. The default value is `inclusive`. </summary> 
        public SyncMapItemResource.QueryFromBoundTypeEnum Bounds { get; set; }



        /// <summary> Construct a new ListSyncMapItemOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Map Item resources to read. </param>
        /// <param name="pathMapSid"> The SID of the Sync Map with the Sync Map Item resource to fetch. Can be the Sync Map resource's `sid` or its `unique_name`. </param>

        public ReadSyncMapItemOptions(string pathServiceSid, string pathMapSid)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Order != null)
            {
                p.Add(new KeyValuePair<string, string>("Order", Order.ToString()));
            }
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }
            if (Bounds != null)
            {
                p.Add(new KeyValuePair<string, string>("Bounds", Bounds.ToString()));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> update </summary>
    public class UpdateSyncMapItemOptions : IOptions<SyncMapItemResource>
    {
    
        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to update. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Sync Map with the Sync Map Item resource to update. Can be the Sync Map resource's `sid` or its `unique_name`. </summary> 
        public string PathMapSid { get; }

        ///<summary> The `key` value of the Sync Map Item resource to update.  </summary> 
        public string PathKey { get; }

        ///<summary> If provided, applies this mutation if (and only if) the “revision” field of this [map item] matches the provided value. This matches the semantics of (and is implemented with) the HTTP [If-Match header](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/If-Match). </summary> 
        public string IfMatch { get; set; }

        ///<summary> A JSON string that represents an arbitrary, schema-less object that the Map Item stores. Can be up to 16 KiB in length. </summary> 
        public object Data { get; set; }

        ///<summary> An alias for `item_ttl`. If both parameters are provided, this value is ignored. </summary> 
        public int? Ttl { get; set; }

        ///<summary> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Map Item expires (time-to-live) and is deleted. </summary> 
        public int? ItemTtl { get; set; }

        ///<summary> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Map Item's parent Sync Map expires (time-to-live) and is deleted. This parameter can only be used when the Map Item's `data` or `ttl` is updated in the same request. </summary> 
        public int? CollectionTtl { get; set; }



        /// <summary> Construct a new UpdateSyncMapItemOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Map Item resource to update. </param>
        /// <param name="pathMapSid"> The SID of the Sync Map with the Sync Map Item resource to update. Can be the Sync Map resource's `sid` or its `unique_name`. </param>
        /// <param name="pathKey"> The `key` value of the Sync Map Item resource to update.  </param>

        public UpdateSyncMapItemOptions(string pathServiceSid, string pathMapSid, string pathKey)
        {
            PathServiceSid = pathServiceSid;
            PathMapSid = pathMapSid;
            PathKey = pathKey;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
            }
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.ToString()));
            }
            if (ItemTtl != null)
            {
                p.Add(new KeyValuePair<string, string>("ItemTtl", ItemTtl.ToString()));
            }
            if (CollectionTtl != null)
            {
                p.Add(new KeyValuePair<string, string>("CollectionTtl", CollectionTtl.ToString()));
            }
            return p;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (IfMatch != null)
        {
            p.Add(new KeyValuePair<string, string>("If-Match", IfMatch));
        }
        return p;
    }

    }


}


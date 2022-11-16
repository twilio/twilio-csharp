/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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




namespace Twilio.Rest.Preview.Sync.Service.SyncList
{

    /// <summary> create </summary>
    public class CreateSyncListItemOptions : IOptions<SyncListItemResource>
    {
        
        
        public string PathServiceSid { get; }

        
        public string PathListSid { get; }

        
        public object Data { get; }


        /// <summary> Construct a new CreateSyncSyncListItemOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid">  </param>
        /// <param name="data">  </param>
        public CreateSyncListItemOptions(string pathServiceSid, string pathListSid, object data)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            Data = data;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteSyncListItemOptions : IOptions<SyncListItemResource>
    {
        
        
        public string PathServiceSid { get; }

        
        public string PathListSid { get; }

        
        public int? PathIndex { get; }

        ///<summary> The If-Match HTTP request header </summary> 
        public string IfMatch { get; set; }



        /// <summary> Construct a new DeleteSyncSyncListItemOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid">  </param>
        /// <param name="pathIndex">  </param>
        public DeleteSyncListItemOptions(string pathServiceSid, string pathListSid, int? pathIndex)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIndex = pathIndex;
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
    public class FetchSyncListItemOptions : IOptions<SyncListItemResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathListSid { get; }

        
        public int? PathIndex { get; }



        /// <summary> Construct a new FetchSyncSyncListItemOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid">  </param>
        /// <param name="pathIndex">  </param>
        public FetchSyncListItemOptions(string pathServiceSid, string pathListSid, int? pathIndex)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIndex = pathIndex;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadSyncListItemOptions : ReadOptions<SyncListItemResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathListSid { get; }

        
        public SyncListItemResource.QueryResultOrderEnum Order { get; set; }

        
        public string From { get; set; }

        
        public SyncListItemResource.QueryFromBoundTypeEnum Bounds { get; set; }



        /// <summary> Construct a new ListSyncSyncListItemOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid">  </param>
        public ReadSyncListItemOptions(string pathServiceSid, string pathListSid)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
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
    public class UpdateSyncListItemOptions : IOptions<SyncListItemResource>
    {
    
        
        public string PathServiceSid { get; }

        
        public string PathListSid { get; }

        
        public int? PathIndex { get; }

        
        public object Data { get; }

        ///<summary> The If-Match HTTP request header </summary> 
        public string IfMatch { get; set; }



        /// <summary> Construct a new UpdateSyncSyncListItemOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid">  </param>
        /// <param name="pathIndex">  </param>
        /// <param name="data">  </param>
        public UpdateSyncListItemOptions(string pathServiceSid, string pathListSid, int? pathIndex, object data)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIndex = pathIndex;
            Data = data;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Data != null)
            {
                p.Add(new KeyValuePair<string, string>("Data", Serializers.JsonObject(Data)));
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


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
    /// <summary> Delete a specific Sync List Permission. </summary>
    public class DeleteSyncListPermissionOptions : IOptions<SyncListPermissionResource>
    {
        
        
        public string PathServiceSid { get; }

        ///<summary> Identifier of the Sync List. Either a SID or a unique name. </summary> 
        public string PathListSid { get; }

        ///<summary> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </summary> 
        public string PathIdentity { get; }



        /// <summary> Construct a new DeleteSyncSyncListPermissionOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid"> Identifier of the Sync List. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        public DeleteSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch a specific Sync List Permission. </summary>
    public class FetchSyncListPermissionOptions : IOptions<SyncListPermissionResource>
    {
    
        
        public string PathServiceSid { get; }

        ///<summary> Identifier of the Sync List. Either a SID or a unique name. </summary> 
        public string PathListSid { get; }

        ///<summary> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </summary> 
        public string PathIdentity { get; }



        /// <summary> Construct a new FetchSyncSyncListPermissionOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid"> Identifier of the Sync List. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        public FetchSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of all Permissions applying to a Sync List. </summary>
    public class ReadSyncListPermissionOptions : ReadOptions<SyncListPermissionResource>
    {
    
        
        public string PathServiceSid { get; }

        ///<summary> Identifier of the Sync List. Either a SID or a unique name. </summary> 
        public string PathListSid { get; }



        /// <summary> Construct a new ListSyncSyncListPermissionOptions </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathListSid"> Identifier of the Sync List. Either a SID or a unique name. </param>
        public ReadSyncListPermissionOptions(string pathServiceSid, string pathListSid)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update an identity's access to a specific Sync List. </summary>
    public class UpdateSyncListPermissionOptions : IOptions<SyncListPermissionResource>
    {
    
        ///<summary> The unique SID identifier of the Sync Service Instance. </summary> 
        public string PathServiceSid { get; }

        ///<summary> Identifier of the Sync List. Either a SID or a unique name. </summary> 
        public string PathListSid { get; }

        ///<summary> Arbitrary string identifier representing a human user associated with an FPA token, assigned by the developer. </summary> 
        public string PathIdentity { get; }

        ///<summary> Boolean flag specifying whether the identity can read the Sync List. </summary> 
        public bool? Read { get; }

        ///<summary> Boolean flag specifying whether the identity can create, update and delete Items of the Sync List. </summary> 
        public bool? Write { get; }

        ///<summary> Boolean flag specifying whether the identity can delete the Sync List. </summary> 
        public bool? Manage { get; }



        /// <summary> Construct a new UpdateSyncSyncListPermissionOptions </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Sync Service Instance. </param>
        /// <param name="pathListSid"> Identifier of the Sync List. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a human user associated with an FPA token, assigned by the developer. </param>
        /// <param name="read"> Boolean flag specifying whether the identity can read the Sync List. </param>
        /// <param name="write"> Boolean flag specifying whether the identity can create, update and delete Items of the Sync List. </param>
        /// <param name="manage"> Boolean flag specifying whether the identity can delete the Sync List. </param>
        public UpdateSyncListPermissionOptions(string pathServiceSid, string pathListSid, string pathIdentity, bool? read, bool? write, bool? manage)
        {
            PathServiceSid = pathServiceSid;
            PathListSid = pathListSid;
            PathIdentity = pathIdentity;
            Read = read;
            Write = write;
            Manage = manage;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Read != null)
            {
                p.Add(new KeyValuePair<string, string>("Read", Read.Value.ToString().ToLower()));
            }
            if (Write != null)
            {
                p.Add(new KeyValuePair<string, string>("Write", Write.Value.ToString().ToLower()));
            }
            if (Manage != null)
            {
                p.Add(new KeyValuePair<string, string>("Manage", Manage.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }


}


using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class FetchSyncMapPermissionOptions : IOptions<SyncMapPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Map SID or unique name.
        /// </summary>
        public string MapSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Map Permission applies.
        /// </summary>
        public string Identity { get; }
    
        /// <summary>
        /// Construct a new FetchSyncMapPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        public FetchSyncMapPermissionOptions(string serviceSid, string mapSid, string identity)
        {
            ServiceSid = serviceSid;
            MapSid = mapSid;
            Identity = identity;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class DeleteSyncMapPermissionOptions : IOptions<SyncMapPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Map SID or unique name.
        /// </summary>
        public string MapSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Map Permission applies.
        /// </summary>
        public string Identity { get; }
    
        /// <summary>
        /// Construct a new DeleteSyncMapPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        public DeleteSyncMapPermissionOptions(string serviceSid, string mapSid, string identity)
        {
            ServiceSid = serviceSid;
            MapSid = mapSid;
            Identity = identity;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class ReadSyncMapPermissionOptions : ReadOptions<SyncMapPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Map SID or unique name.
        /// </summary>
        public string MapSid { get; }
    
        /// <summary>
        /// Construct a new ReadSyncMapPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        public ReadSyncMapPermissionOptions(string serviceSid, string mapSid)
        {
            ServiceSid = serviceSid;
            MapSid = mapSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateSyncMapPermissionOptions : IOptions<SyncMapPermissionResource> 
    {
        /// <summary>
        /// Sync Service Instance SID.
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Map SID or unique name.
        /// </summary>
        public string MapSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Map Permission applies.
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// Read access.
        /// </summary>
        public bool? Read { get; }
        /// <summary>
        /// Write access.
        /// </summary>
        public bool? Write { get; }
        /// <summary>
        /// Manage access.
        /// </summary>
        public bool? Manage { get; }
    
        /// <summary>
        /// Construct a new UpdateSyncMapPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        public UpdateSyncMapPermissionOptions(string serviceSid, string mapSid, string identity, bool? read, bool? write, bool? manage)
        {
            ServiceSid = serviceSid;
            MapSid = mapSid;
            Identity = identity;
            Read = read;
            Write = write;
            Manage = manage;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Read != null)
            {
                p.Add(new KeyValuePair<string, string>("Read", Read.Value.ToString()));
            }
            
            if (Write != null)
            {
                p.Add(new KeyValuePair<string, string>("Write", Write.Value.ToString()));
            }
            
            if (Manage != null)
            {
                p.Add(new KeyValuePair<string, string>("Manage", Manage.Value.ToString()));
            }
            
            return p;
        }
    }

}
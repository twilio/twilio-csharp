using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Preview.Sync.Service.Document 
{

    /// <summary>
    /// Fetch a specific Sync Document Permission.
    /// </summary>
    public class FetchDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string DocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
        /// </summary>
        public string Identity { get; }
    
        /// <summary>
        /// Construct a new FetchDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        public FetchDocumentPermissionOptions(string serviceSid, string documentSid, string identity)
        {
            ServiceSid = serviceSid;
            DocumentSid = documentSid;
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

    /// <summary>
    /// Delete a specific Sync Document Permission.
    /// </summary>
    public class DeleteDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string DocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
        /// </summary>
        public string Identity { get; }
    
        /// <summary>
        /// Construct a new DeleteDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        public DeleteDocumentPermissionOptions(string serviceSid, string documentSid, string identity)
        {
            ServiceSid = serviceSid;
            DocumentSid = documentSid;
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

    /// <summary>
    /// Retrieve a list of all Permissions applying to a Sync Document.
    /// </summary>
    public class ReadDocumentPermissionOptions : ReadOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string DocumentSid { get; }
    
        /// <summary>
        /// Construct a new ReadDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        public ReadDocumentPermissionOptions(string serviceSid, string documentSid)
        {
            ServiceSid = serviceSid;
            DocumentSid = documentSid;
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

    /// <summary>
    /// Update an identity's access to a specific Sync Document.
    /// </summary>
    public class UpdateDocumentPermissionOptions : IOptions<DocumentPermissionResource> 
    {
        /// <summary>
        /// Sync Service Instance SID.
        /// </summary>
        public string ServiceSid { get; }
        /// <summary>
        /// Sync Document SID or unique name.
        /// </summary>
        public string DocumentSid { get; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
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
        /// Construct a new UpdateDocumentPermissionOptions
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        public UpdateDocumentPermissionOptions(string serviceSid, string documentSid, string identity, bool? read, bool? write, bool? manage)
        {
            ServiceSid = serviceSid;
            DocumentSid = documentSid;
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
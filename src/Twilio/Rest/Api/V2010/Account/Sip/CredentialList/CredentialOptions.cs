using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList 
{

    public class ReadCredentialOptions : ReadOptions<CredentialResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
    
        /// <summary>
        /// Construct a new ReadCredentialOptions
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        public ReadCredentialOptions(string credentialListSid)
        {
            CredentialListSid = credentialListSid;
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

    public class CreateCredentialOptions : IOptions<CredentialResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; }
    
        /// <summary>
        /// Construct a new CreateCredentialOptions
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        public CreateCredentialOptions(string credentialListSid, string username, string password)
        {
            CredentialListSid = credentialListSid;
            Username = username;
            Password = password;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Username != null)
            {
                p.Add(new KeyValuePair<string, string>("Username", Username));
            }
            
            if (Password != null)
            {
                p.Add(new KeyValuePair<string, string>("Password", Password));
            }
            
            return p;
        }
    }

    public class FetchCredentialOptions : IOptions<CredentialResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchCredentialOptions
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchCredentialOptions(string credentialListSid, string sid)
        {
            CredentialListSid = credentialListSid;
            Sid = sid;
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

    public class UpdateCredentialOptions : IOptions<CredentialResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }
    
        /// <summary>
        /// Construct a new UpdateCredentialOptions
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public UpdateCredentialOptions(string credentialListSid, string sid)
        {
            CredentialListSid = credentialListSid;
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Password != null)
            {
                p.Add(new KeyValuePair<string, string>("Password", Password));
            }
            
            return p;
        }
    }

    public class DeleteCredentialOptions : IOptions<CredentialResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The credential_list_sid
        /// </summary>
        public string CredentialListSid { get; }
        /// <summary>
        /// The sid
        /// </summary>
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteCredentialOptions
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public DeleteCredentialOptions(string credentialListSid, string sid)
        {
            CredentialListSid = credentialListSid;
            Sid = sid;
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

}
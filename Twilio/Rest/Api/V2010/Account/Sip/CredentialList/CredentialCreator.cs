using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList 
{

    public class CredentialCreator : Creator<CredentialResource> 
    {
        public string AccountSid { get; set; }
        public string CredentialListSid { get; }
        public string Username { get; }
        public string Password { get; }
    
        /// <summary>
        /// Construct a new CredentialCreator
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        public CredentialCreator(string credentialListSid, string username, string password)
        {
            CredentialListSid = credentialListSid;
            Username = username;
            Password = password;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CredentialResource </returns> 
        public override async Task<CredentialResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + this.CredentialListSid + "/Credentials.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created CredentialResource </returns> 
        public override CredentialResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + this.CredentialListSid + "/Credentials.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Username != null)
            {
                request.AddPostParam("Username", Username);
            }
            
            if (Password != null)
            {
                request.AddPostParam("Password", Password);
            }
        }
    }
}
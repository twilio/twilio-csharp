using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList 
{

    public class CredentialUpdater : Updater<CredentialResource> 
    {
        public string AccountSid { get; set; }
        public string CredentialListSid { get; }
        public string Sid { get; }
        public string Password { get; set; }
    
        /// <summary>
        /// Construct a new CredentialUpdater
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        public CredentialUpdater(string credentialListSid, string sid)
        {
            CredentialListSid = credentialListSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CredentialResource </returns> 
        public override async System.Threading.Tasks.Task<CredentialResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + CredentialListSid + "/Credentials/" + Sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated CredentialResource </returns> 
        public override CredentialResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/CredentialLists/" + CredentialListSid + "/Credentials/" + Sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
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
            if (Password != null)
            {
                request.AddPostParam("Password", Password);
            }
        }
    }
}
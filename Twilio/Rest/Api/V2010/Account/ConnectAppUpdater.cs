using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ConnectAppUpdater : Updater<ConnectAppResource> 
    {
        public string accountSid { get; set; }
        public string sid { get; }
        public Uri authorizeRedirectUrl { get; set; }
        public string companyName { get; set; }
        public Twilio.Http.HttpMethod deauthorizeCallbackMethod { get; set; }
        public Uri deauthorizeCallbackUrl { get; set; }
        public string description { get; set; }
        public string friendlyName { get; set; }
        public Uri homepageUrl { get; set; }
        public List<ConnectAppResource.Permission> permissions { get; set; }
    
        /// <summary>
        /// Construct a new ConnectAppUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ConnectAppUpdater(string sid)
        {
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ConnectAppResource </returns> 
        public override async Task<ConnectAppResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/ConnectApps/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ConnectAppResource update failed: Unable to connect to server");
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
            
            return ConnectAppResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ConnectAppResource </returns> 
        public override ConnectAppResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/ConnectApps/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ConnectAppResource update failed: Unable to connect to server");
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
            
            return ConnectAppResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (authorizeRedirectUrl != null)
            {
                request.AddPostParam("AuthorizeRedirectUrl", authorizeRedirectUrl.ToString());
            }
            
            if (companyName != null)
            {
                request.AddPostParam("CompanyName", companyName);
            }
            
            if (deauthorizeCallbackMethod != null)
            {
                request.AddPostParam("DeauthorizeCallbackMethod", deauthorizeCallbackMethod.ToString());
            }
            
            if (deauthorizeCallbackUrl != null)
            {
                request.AddPostParam("DeauthorizeCallbackUrl", deauthorizeCallbackUrl.ToString());
            }
            
            if (description != null)
            {
                request.AddPostParam("Description", description);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (homepageUrl != null)
            {
                request.AddPostParam("HomepageUrl", homepageUrl.ToString());
            }
            
            if (permissions != null)
            {
                request.AddPostParam("Permissions", permissions.ToString());
            }
        }
    }
}
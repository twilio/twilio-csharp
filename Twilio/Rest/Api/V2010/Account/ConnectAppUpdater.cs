using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ConnectAppUpdater : Updater<ConnectAppResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public Uri AuthorizeRedirectUrl { get; set; }
        public string CompanyName { get; set; }
        public Twilio.Http.HttpMethod DeauthorizeCallbackMethod { get; set; }
        public Uri DeauthorizeCallbackUrl { get; set; }
        public string Description { get; set; }
        public string FriendlyName { get; set; }
        public Uri HomepageUrl { get; set; }
        public List<ConnectAppResource.PermissionEnum> Permissions { get; set; }
    
        /// <summary>
        /// Construct a new ConnectAppUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ConnectAppUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ConnectAppResource </returns> 
        public override async System.Threading.Tasks.Task<ConnectAppResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/ConnectApps/" + Sid + ".json"
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
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/ConnectApps/" + Sid + ".json"
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
            if (AuthorizeRedirectUrl != null)
            {
                request.AddPostParam("AuthorizeRedirectUrl", AuthorizeRedirectUrl.ToString());
            }
            
            if (CompanyName != null)
            {
                request.AddPostParam("CompanyName", CompanyName);
            }
            
            if (DeauthorizeCallbackMethod != null)
            {
                request.AddPostParam("DeauthorizeCallbackMethod", DeauthorizeCallbackMethod.ToString());
            }
            
            if (DeauthorizeCallbackUrl != null)
            {
                request.AddPostParam("DeauthorizeCallbackUrl", DeauthorizeCallbackUrl.ToString());
            }
            
            if (Description != null)
            {
                request.AddPostParam("Description", Description);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (HomepageUrl != null)
            {
                request.AddPostParam("HomepageUrl", HomepageUrl.ToString());
            }
            
            if (Permissions != null)
            {
                request.AddPostParam("Permissions", Permissions.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ConnectAppUpdater : Updater<ConnectAppResource> {
        private string accountSid;
        private string sid;
        private Uri authorizeRedirectUrl;
        private string companyName;
        private Twilio.Http.HttpMethod deauthorizeCallbackMethod;
        private Uri deauthorizeCallbackUrl;
        private string description;
        private string friendlyName;
        private Uri homepageUrl;
        private List<ConnectAppResource.Permission> permissions;
    
        /// <summary>
        /// Construct a new ConnectAppUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ConnectAppUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new ConnectAppUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        public ConnectAppUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The URL the user's browser will redirect to after Twilio authenticates the user and obtains authorization for this
        /// Connect App.
        /// </summary>
        ///
        /// <param name="authorizeRedirectUrl"> URIL Twilio sends requests when users authorize </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setAuthorizeRedirectUrl(Uri authorizeRedirectUrl) {
            this.authorizeRedirectUrl = authorizeRedirectUrl;
            return this;
        }
    
        /// <summary>
        /// The URL the user's browser will redirect to after Twilio authenticates the user and obtains authorization for this
        /// Connect App.
        /// </summary>
        ///
        /// <param name="authorizeRedirectUrl"> URIL Twilio sends requests when users authorize </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setAuthorizeRedirectUrl(string authorizeRedirectUrl) {
            return setAuthorizeRedirectUrl(Promoter.UriFromString(authorizeRedirectUrl));
        }
    
        /// <summary>
        /// The company name set for this Connect App.
        /// </summary>
        ///
        /// <param name="companyName"> The company name set for this Connect App. </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setCompanyName(string companyName) {
            this.companyName = companyName;
            return this;
        }
    
        /// <summary>
        /// The HTTP method to be used when making a request to the `DeauthorizeCallbackUrl`.
        /// </summary>
        ///
        /// <param name="deauthorizeCallbackMethod"> HTTP method Twilio WIll use making requests to the url </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setDeauthorizeCallbackMethod(Twilio.Http.HttpMethod deauthorizeCallbackMethod) {
            this.deauthorizeCallbackMethod = deauthorizeCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL to which Twilio will send a request when a user de-authorizes this Connect App.
        /// </summary>
        ///
        /// <param name="deauthorizeCallbackUrl"> URL Twilio will send a request when a user de-authorizes this app </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setDeauthorizeCallbackUrl(Uri deauthorizeCallbackUrl) {
            this.deauthorizeCallbackUrl = deauthorizeCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL to which Twilio will send a request when a user de-authorizes this Connect App.
        /// </summary>
        ///
        /// <param name="deauthorizeCallbackUrl"> URL Twilio will send a request when a user de-authorizes this app </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setDeauthorizeCallbackUrl(string deauthorizeCallbackUrl) {
            return setDeauthorizeCallbackUrl(Promoter.UriFromString(deauthorizeCallbackUrl));
        }
    
        /// <summary>
        /// A more detailed human readable description of the Connect App.
        /// </summary>
        ///
        /// <param name="description"> A more detailed human readable description </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setDescription(string description) {
            this.description = description;
            return this;
        }
    
        /// <summary>
        /// A human readable name for the Connect App.
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable name for the Connect App. </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The public URL where users can obtain more information about this Connect App.
        /// </summary>
        ///
        /// <param name="homepageUrl"> The URL users can obtain more information </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setHomepageUrl(Uri homepageUrl) {
            this.homepageUrl = homepageUrl;
            return this;
        }
    
        /// <summary>
        /// The public URL where users can obtain more information about this Connect App.
        /// </summary>
        ///
        /// <param name="homepageUrl"> The URL users can obtain more information </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setHomepageUrl(string homepageUrl) {
            return setHomepageUrl(Promoter.UriFromString(homepageUrl));
        }
    
        /// <summary>
        /// The set of permissions that your ConnectApp requests.
        /// </summary>
        ///
        /// <param name="permissions"> The set of permissions that your ConnectApp requests. </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setPermissions(List<ConnectAppResource.Permission> permissions) {
            this.permissions = permissions;
            return this;
        }
    
        /// <summary>
        /// The set of permissions that your ConnectApp requests.
        /// </summary>
        ///
        /// <param name="permissions"> The set of permissions that your ConnectApp requests. </param>
        /// <returns> this </returns> 
        public ConnectAppUpdater setPermissions(ConnectAppResource.Permission permissions) {
            return setPermissions(Promoter.ListOfOne(permissions));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ConnectAppResource </returns> 
        public override async Task<ConnectAppResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/ConnectApps/" + this.sid + ".json"
            );
            addPostParams(request);
            
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
        public override ConnectAppResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/ConnectApps/" + this.sid + ".json"
            );
            addPostParams(request);
            
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
        private void addPostParams(Request request) {
            if (authorizeRedirectUrl != null) {
                request.AddPostParam("AuthorizeRedirectUrl", authorizeRedirectUrl.ToString());
            }
            
            if (companyName != null) {
                request.AddPostParam("CompanyName", companyName);
            }
            
            if (deauthorizeCallbackMethod != null) {
                request.AddPostParam("DeauthorizeCallbackMethod", deauthorizeCallbackMethod.ToString());
            }
            
            if (deauthorizeCallbackUrl != null) {
                request.AddPostParam("DeauthorizeCallbackUrl", deauthorizeCallbackUrl.ToString());
            }
            
            if (description != null) {
                request.AddPostParam("Description", description);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (homepageUrl != null) {
                request.AddPostParam("HomepageUrl", homepageUrl.ToString());
            }
            
            if (permissions != null) {
                request.AddPostParam("Permissions", permissions.ToString());
            }
        }
    }
}
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeUpdater : Updater<ShortCodeResource> {
        public string accountSid { get; }
        public string sid { get; }
        public string friendlyName { get; set; }
        public string apiVersion { get; set; }
        public Uri smsUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new ShortCodeUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ShortCodeUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new ShortCodeUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        public ShortCodeUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// A human readable descriptive text for this resource, up to 64 characters long. By default, the `FriendlyName` is
        /// just the short code.
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// SMSs to this short code will start a new TwiML session with this API version.
        /// </summary>
        ///
        /// <param name="apiVersion"> The API version to use </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when receiving an incoming SMS message to this short code.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when receiving an incoming SMS message to this short code.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when making requests to the `SmsUrl`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsMethod"> HTTP method to use when requesting the sms url </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above URL. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsFallbackMethod"> HTTP method Twilio will use with sms fallback url </param>
        /// <returns> this </returns> 
        public ShortCodeUpdater setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ShortCodeResource </returns> 
        public override async Task<ShortCodeResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SMS/ShortCodes/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ShortCodeResource update failed: Unable to connect to server");
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
            
            return ShortCodeResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ShortCodeResource </returns> 
        public override ShortCodeResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SMS/ShortCodes/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ShortCodeResource update failed: Unable to connect to server");
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
            
            return ShortCodeResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != null) {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsFallbackMethod != null) {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
        }
    }
}
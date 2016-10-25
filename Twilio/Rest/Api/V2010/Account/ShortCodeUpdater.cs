using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ShortCodeUpdater : Updater<ShortCodeResource> 
    {
        public string accountSid { get; }
        public string sid { get; }
        public string friendlyName { get; set; }
        public string apiVersion { get; set; }
        public Uri smsUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new ShortCodeUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="apiVersion"> The API version to use </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="smsMethod"> HTTP method to use when requesting the sms url </param>
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="smsFallbackMethod"> HTTP method Twilio will use with sms fallback url </param>
        public ShortCodeUpdater(string sid, string accountSid=null, string friendlyName=null, string apiVersion=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsFallbackMethod=null)
        {
            this.smsUrl = smsUrl;
            this.apiVersion = apiVersion;
            this.sid = sid;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsMethod = smsMethod;
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
            this.smsFallbackMethod = smsFallbackMethod;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ShortCodeResource </returns> 
        public override async Task<ShortCodeResource> UpdateAsync(ITwilioRestClient client)
        {
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
        public override ShortCodeResource Update(ITwilioRestClient client)
        {
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
        private void AddPostParams(Request request)
        {
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != null)
            {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (smsUrl != null)
            {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (smsMethod != null)
            {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsFallbackUrl != null)
            {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsFallbackMethod != null)
            {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
        }
    }
}
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip {

    public class DomainCreator : Creator<DomainResource> {
        private string accountSid;
        private string domainName;
        private string friendlyName;
        private string authType;
        private Uri voiceUrl;
        private Twilio.Http.HttpMethod voiceMethod;
        private Uri voiceFallbackUrl;
        private Twilio.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceStatusCallbackUrl;
        private Twilio.Http.HttpMethod voiceStatusCallbackMethod;
    
        /// <summary>
        /// Construct a new DomainCreator.
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        public DomainCreator(string domainName) {
            this.domainName = domainName;
        }
    
        /// <summary>
        /// Construct a new DomainCreator
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        public DomainCreator(string accountSid, string domainName) {
            this.accountSid = accountSid;
            this.domainName = domainName;
        }
    
        /// <summary>
        /// A user-specified, human-readable name for the trigger.
        /// </summary>
        ///
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <returns> this </returns> 
        public DomainCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The types of authentication you have mapped to your domain
        /// </summary>
        ///
        /// <param name="authType"> The types of authentication mapped to the domain </param>
        /// <returns> this </returns> 
        public DomainCreator setAuthType(string authType) {
            this.authType = authType;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when this domain receives a call
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when this domain receives a call
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /// <summary>
        /// The HTTP method to use with the voice_url
        /// </summary>
        ///
        /// <param name="voiceMethod"> HTTP method to use with voice_url </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will use if an error occurs retrieving or executing the TwiML requested by VoiceUrl
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will use if an error occurs retrieving or executing the TwiML requested by VoiceUrl
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the VoiceFallbackUrl
        /// </summary>
        ///
        /// <param name="voiceFallbackMethod"> HTTP method used with voice_fallback_url </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackUrl"> URL that Twilio will request with status updates </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceStatusCallbackUrl(Uri voiceStatusCallbackUrl) {
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackUrl"> URL that Twilio will request with status updates </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceStatusCallbackUrl(string voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.UriFromString(voiceStatusCallbackUrl));
        }
    
        /// <summary>
        /// The voice_status_callback_method
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackMethod"> The voice_status_callback_method </param>
        /// <returns> this </returns> 
        public DomainCreator setVoiceStatusCallbackMethod(Twilio.Http.HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DomainResource </returns> 
        public override async Task<DomainResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource creation failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DomainResource </returns> 
        public override DomainResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource creation failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (domainName != null) {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (authType != null) {
                request.AddPostParam("AuthType", authType);
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
        }
    }
}
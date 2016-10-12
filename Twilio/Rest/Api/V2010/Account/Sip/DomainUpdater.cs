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

    public class DomainUpdater : Updater<DomainResource> {
        private string accountSid;
        private string sid;
        private string authType;
        private string friendlyName;
        private Twilio.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private Twilio.Http.HttpMethod voiceMethod;
        private Twilio.Http.HttpMethod voiceStatusCallbackMethod;
        private Uri voiceStatusCallbackUrl;
        private Uri voiceUrl;
    
        /// <summary>
        /// Construct a new DomainUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DomainUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new DomainUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        public DomainUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The auth_type
        /// </summary>
        ///
        /// <param name="authType"> The auth_type </param>
        /// <returns> this </returns> 
        public DomainUpdater setAuthType(string authType) {
            this.authType = authType;
            return this;
        }
    
        /// <summary>
        /// A user-specified, human-readable name for the trigger.
        /// </summary>
        ///
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <returns> this </returns> 
        public DomainUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_method
        /// </summary>
        ///
        /// <param name="voiceFallbackMethod"> The voice_fallback_method </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_url
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_url
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method to use with the voice_url
        /// </summary>
        ///
        /// <param name="voiceMethod"> HTTP method to use with voice_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_status_callback_method
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackMethod"> The voice_status_callback_method </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceStatusCallbackMethod(Twilio.Http.HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_status_callback_url
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackUrl"> The voice_status_callback_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceStatusCallbackUrl(Uri voiceStatusCallbackUrl) {
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_status_callback_url
        /// </summary>
        ///
        /// <param name="voiceStatusCallbackUrl"> The voice_status_callback_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceStatusCallbackUrl(string voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.UriFromString(voiceStatusCallbackUrl));
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public DomainUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override async Task<DomainResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override DomainResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (authType != null) {
                request.AddPostParam("AuthType", authType);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}
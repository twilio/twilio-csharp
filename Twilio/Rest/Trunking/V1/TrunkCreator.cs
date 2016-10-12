using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1 {

    public class TrunkCreator : Creator<TrunkResource> {
        private string friendlyName;
        private string domainName;
        private Uri disasterRecoveryUrl;
        private Twilio.Http.HttpMethod disasterRecoveryMethod;
        private string recording;
        private bool? secure;
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public TrunkCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The domain_name
        /// </summary>
        ///
        /// <param name="domainName"> The domain_name </param>
        /// <returns> this </returns> 
        public TrunkCreator setDomainName(string domainName) {
            this.domainName = domainName;
            return this;
        }
    
        /// <summary>
        /// The disaster_recovery_url
        /// </summary>
        ///
        /// <param name="disasterRecoveryUrl"> The disaster_recovery_url </param>
        /// <returns> this </returns> 
        public TrunkCreator setDisasterRecoveryUrl(Uri disasterRecoveryUrl) {
            this.disasterRecoveryUrl = disasterRecoveryUrl;
            return this;
        }
    
        /// <summary>
        /// The disaster_recovery_url
        /// </summary>
        ///
        /// <param name="disasterRecoveryUrl"> The disaster_recovery_url </param>
        /// <returns> this </returns> 
        public TrunkCreator setDisasterRecoveryUrl(string disasterRecoveryUrl) {
            return setDisasterRecoveryUrl(Promoter.UriFromString(disasterRecoveryUrl));
        }
    
        /// <summary>
        /// The disaster_recovery_method
        /// </summary>
        ///
        /// <param name="disasterRecoveryMethod"> The disaster_recovery_method </param>
        /// <returns> this </returns> 
        public TrunkCreator setDisasterRecoveryMethod(Twilio.Http.HttpMethod disasterRecoveryMethod) {
            this.disasterRecoveryMethod = disasterRecoveryMethod;
            return this;
        }
    
        /// <summary>
        /// The recording
        /// </summary>
        ///
        /// <param name="recording"> The recording </param>
        /// <returns> this </returns> 
        public TrunkCreator setRecording(string recording) {
            this.recording = recording;
            return this;
        }
    
        /// <summary>
        /// The secure
        /// </summary>
        ///
        /// <param name="secure"> The secure </param>
        /// <returns> this </returns> 
        public TrunkCreator setSecure(bool? secure) {
            this.secure = secure;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TrunkResource </returns> 
        public override async Task<TrunkResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource creation failed: Unable to connect to server");
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
            
            return TrunkResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TrunkResource </returns> 
        public override TrunkResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource creation failed: Unable to connect to server");
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
            
            return TrunkResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (domainName != null) {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (disasterRecoveryUrl != null) {
                request.AddPostParam("DisasterRecoveryUrl", disasterRecoveryUrl.ToString());
            }
            
            if (disasterRecoveryMethod != null) {
                request.AddPostParam("DisasterRecoveryMethod", disasterRecoveryMethod.ToString());
            }
            
            if (recording != null) {
                request.AddPostParam("Recording", recording);
            }
            
            if (secure != null) {
                request.AddPostParam("Secure", secure.ToString());
            }
        }
    }
}
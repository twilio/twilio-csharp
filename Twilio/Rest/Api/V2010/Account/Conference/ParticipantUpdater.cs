using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Conference {

    public class ParticipantUpdater : Updater<ParticipantResource> {
        private string accountSid;
        private string conferenceSid;
        private string callSid;
        private bool? muted;
        private bool? hold;
        private Uri holdUrl;
        private Twilio.Http.HttpMethod holdMethod;
    
        /// <summary>
        /// Construct a new ParticipantUpdater.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public ParticipantUpdater(string conferenceSid, string callSid) {
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        /// <summary>
        /// Construct a new ParticipantUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public ParticipantUpdater(string accountSid, string conferenceSid, string callSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        /// <summary>
        /// Indicates if the participant should be muted
        /// </summary>
        ///
        /// <param name="muted"> Indicates if the participant should be muted </param>
        /// <returns> this </returns> 
        public ParticipantUpdater setMuted(bool? muted) {
            this.muted = muted;
            return this;
        }
    
        /// <summary>
        /// The hold
        /// </summary>
        ///
        /// <param name="hold"> The hold </param>
        /// <returns> this </returns> 
        public ParticipantUpdater setHold(bool? hold) {
            this.hold = hold;
            return this;
        }
    
        /// <summary>
        /// The hold_url
        /// </summary>
        ///
        /// <param name="holdUrl"> The hold_url </param>
        /// <returns> this </returns> 
        public ParticipantUpdater setHoldUrl(Uri holdUrl) {
            this.holdUrl = holdUrl;
            return this;
        }
    
        /// <summary>
        /// The hold_url
        /// </summary>
        ///
        /// <param name="holdUrl"> The hold_url </param>
        /// <returns> this </returns> 
        public ParticipantUpdater setHoldUrl(string holdUrl) {
            return setHoldUrl(Promoter.UriFromString(holdUrl));
        }
    
        /// <summary>
        /// The hold_method
        /// </summary>
        ///
        /// <param name="holdMethod"> The hold_method </param>
        /// <returns> this </returns> 
        public ParticipantUpdater setHoldMethod(Twilio.Http.HttpMethod holdMethod) {
            this.holdMethod = holdMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ParticipantResource </returns> 
        public override async Task<ParticipantResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource update failed: Unable to connect to server");
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
            
            return ParticipantResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ParticipantResource </returns> 
        public override ParticipantResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource update failed: Unable to connect to server");
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
            
            return ParticipantResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (muted != null) {
                request.AddPostParam("Muted", muted.ToString());
            }
            
            if (hold != null) {
                request.AddPostParam("Hold", hold.ToString());
            }
            
            if (holdUrl != null) {
                request.AddPostParam("HoldUrl", holdUrl.ToString());
            }
            
            if (holdMethod != null) {
                request.AddPostParam("HoldMethod", holdMethod.ToString());
            }
        }
    }
}
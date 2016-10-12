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
    
        /**
         * Construct a new ParticipantUpdater.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         */
        public ParticipantUpdater(string conferenceSid, string callSid) {
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        /**
         * Construct a new ParticipantUpdater
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         * @param callSid The call_sid
         */
        public ParticipantUpdater(string accountSid, string conferenceSid, string callSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        /**
         * Indicates if the participant should be muted
         * 
         * @param muted Indicates if the participant should be muted
         * @return this
         */
        public ParticipantUpdater setMuted(bool? muted) {
            this.muted = muted;
            return this;
        }
    
        /**
         * The hold
         * 
         * @param hold The hold
         * @return this
         */
        public ParticipantUpdater setHold(bool? hold) {
            this.hold = hold;
            return this;
        }
    
        /**
         * The hold_url
         * 
         * @param holdUrl The hold_url
         * @return this
         */
        public ParticipantUpdater setHoldUrl(Uri holdUrl) {
            this.holdUrl = holdUrl;
            return this;
        }
    
        /**
         * The hold_url
         * 
         * @param holdUrl The hold_url
         * @return this
         */
        public ParticipantUpdater setHoldUrl(string holdUrl) {
            return setHoldUrl(Promoter.UriFromString(holdUrl));
        }
    
        /**
         * The hold_method
         * 
         * @param holdMethod The hold_method
         * @return this
         */
        public ParticipantUpdater setHoldMethod(Twilio.Http.HttpMethod holdMethod) {
            this.holdMethod = holdMethod;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ParticipantResource
         */
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
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return ParticipantResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ParticipantResource
         */
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
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return ParticipantResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
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
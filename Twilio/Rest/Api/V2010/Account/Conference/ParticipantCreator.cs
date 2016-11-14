using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantCreator : Creator<ParticipantResource> 
    {
        public string accountSid { get; set; }
        public string conferenceSid { get; }
        public Twilio.Types.PhoneNumber from { get; }
        public Twilio.Types.PhoneNumber to { get; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public List<string> statusCallbackEvent { get; set; }
        public int? timeout { get; set; }
        public bool? record { get; set; }
        public bool? muted { get; set; }
        public ParticipantResource.ParticipantBeep beep { get; set; }
        public bool? startConferenceOnEnter { get; set; }
        public bool? endConferenceOnExit { get; set; }
        public Uri waitUrl { get; set; }
        public Twilio.Http.HttpMethod waitMethod { get; set; }
        public bool? earlyMedia { get; set; }
        public int? maxParticipants { get; set; }
        public ParticipantResource.ParticipantConferenceRecord conferenceRecord { get; set; }
        public string conferenceTrim { get; set; }
        public Uri conferenceStatusCallback { get; set; }
        public Twilio.Http.HttpMethod conferenceStatusCallbackMethod { get; set; }
        public string conferenceStatusCallbackEvent { get; set; }
    
        /// <summary>
        /// Construct a new ParticipantCreator
        /// </summary>
        ///
        /// <param name="conferenceSid"> The conference_sid </param>
        /// <param name="from"> The from </param>
        /// <param name="to"> The to </param>
        public ParticipantCreator(string conferenceSid, Twilio.Types.PhoneNumber from, Twilio.Types.PhoneNumber to)
        {
            this.conferenceSid = conferenceSid;
            this.from = from;
            this.to = to;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ParticipantResource </returns> 
        public override async Task<ParticipantResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource creation failed: Unable to connect to server");
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
            
            return ParticipantResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ParticipantResource </returns> 
        public override ParticipantResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource creation failed: Unable to connect to server");
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
            
            return ParticipantResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (from != null)
            {
                request.AddPostParam("From", from.ToString());
            }
            
            if (to != null)
            {
                request.AddPostParam("To", to.ToString());
            }
            
            if (statusCallback != null)
            {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (statusCallbackEvent != null)
            {
                request.AddPostParam("StatusCallbackEvent", statusCallbackEvent.ToString());
            }
            
            if (timeout != null)
            {
                request.AddPostParam("Timeout", timeout.ToString());
            }
            
            if (record != null)
            {
                request.AddPostParam("Record", record.ToString());
            }
            
            if (muted != null)
            {
                request.AddPostParam("Muted", muted.ToString());
            }
            
            if (beep != null)
            {
                request.AddPostParam("Beep", beep.ToString());
            }
            
            if (startConferenceOnEnter != null)
            {
                request.AddPostParam("StartConferenceOnEnter", startConferenceOnEnter.ToString());
            }
            
            if (endConferenceOnExit != null)
            {
                request.AddPostParam("EndConferenceOnExit", endConferenceOnExit.ToString());
            }
            
            if (waitUrl != null)
            {
                request.AddPostParam("WaitUrl", waitUrl.ToString());
            }
            
            if (waitMethod != null)
            {
                request.AddPostParam("WaitMethod", waitMethod.ToString());
            }
            
            if (earlyMedia != null)
            {
                request.AddPostParam("EarlyMedia", earlyMedia.ToString());
            }
            
            if (maxParticipants != null)
            {
                request.AddPostParam("MaxParticipants", maxParticipants.ToString());
            }
            
            if (conferenceRecord != null)
            {
                request.AddPostParam("ConferenceRecord", conferenceRecord.ToString());
            }
            
            if (conferenceTrim != null)
            {
                request.AddPostParam("ConferenceTrim", conferenceTrim);
            }
            
            if (conferenceStatusCallback != null)
            {
                request.AddPostParam("ConferenceStatusCallback", conferenceStatusCallback.ToString());
            }
            
            if (conferenceStatusCallbackMethod != null)
            {
                request.AddPostParam("ConferenceStatusCallbackMethod", conferenceStatusCallbackMethod.ToString());
            }
            
            if (conferenceStatusCallbackEvent != null)
            {
                request.AddPostParam("ConferenceStatusCallbackEvent", conferenceStatusCallbackEvent);
            }
        }
    }
}
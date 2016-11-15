using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantCreator : Creator<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public Types.PhoneNumber From { get; }
        public Types.PhoneNumber To { get; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public List<string> StatusCallbackEvent { get; set; }
        public int? Timeout { get; set; }
        public bool? Record { get; set; }
        public bool? Muted { get; set; }
        public ParticipantResource.BeepEnum Beep { get; set; }
        public bool? StartConferenceOnEnter { get; set; }
        public bool? EndConferenceOnExit { get; set; }
        public Uri WaitUrl { get; set; }
        public Twilio.Http.HttpMethod WaitMethod { get; set; }
        public bool? EarlyMedia { get; set; }
        public int? MaxParticipants { get; set; }
        public ParticipantResource.ConferenceRecordEnum ConferenceRecord { get; set; }
        public string ConferenceTrim { get; set; }
        public Uri ConferenceStatusCallback { get; set; }
        public Twilio.Http.HttpMethod ConferenceStatusCallbackMethod { get; set; }
        public string ConferenceStatusCallbackEvent { get; set; }
    
        /// <summary>
        /// Construct a new ParticipantCreator
        /// </summary>
        ///
        /// <param name="conferenceSid"> The conference_sid </param>
        /// <param name="from"> The from </param>
        /// <param name="to"> The to </param>
        public ParticipantCreator(string conferenceSid, Types.PhoneNumber from, Types.PhoneNumber to)
        {
            ConferenceSid = conferenceSid;
            From = from;
            To = to;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ParticipantResource </returns> 
        public override async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Conferences/" + ConferenceSid + "/Participants.json"
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
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Conferences/" + ConferenceSid + "/Participants.json"
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
            if (From != null)
            {
                request.AddPostParam("From", From.ToString());
            }
            
            if (To != null)
            {
                request.AddPostParam("To", To.ToString());
            }
            
            if (StatusCallback != null)
            {
                request.AddPostParam("StatusCallback", StatusCallback.ToString());
            }
            
            if (StatusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", StatusCallbackMethod.ToString());
            }
            
            if (StatusCallbackEvent != null)
            {
                request.AddPostParam("StatusCallbackEvent", StatusCallbackEvent.ToString());
            }
            
            if (Timeout != null)
            {
                request.AddPostParam("Timeout", Timeout.ToString());
            }
            
            if (Record != null)
            {
                request.AddPostParam("Record", Record.ToString());
            }
            
            if (Muted != null)
            {
                request.AddPostParam("Muted", Muted.ToString());
            }
            
            if (Beep != null)
            {
                request.AddPostParam("Beep", Beep.ToString());
            }
            
            if (StartConferenceOnEnter != null)
            {
                request.AddPostParam("StartConferenceOnEnter", StartConferenceOnEnter.ToString());
            }
            
            if (EndConferenceOnExit != null)
            {
                request.AddPostParam("EndConferenceOnExit", EndConferenceOnExit.ToString());
            }
            
            if (WaitUrl != null)
            {
                request.AddPostParam("WaitUrl", WaitUrl.ToString());
            }
            
            if (WaitMethod != null)
            {
                request.AddPostParam("WaitMethod", WaitMethod.ToString());
            }
            
            if (EarlyMedia != null)
            {
                request.AddPostParam("EarlyMedia", EarlyMedia.ToString());
            }
            
            if (MaxParticipants != null)
            {
                request.AddPostParam("MaxParticipants", MaxParticipants.ToString());
            }
            
            if (ConferenceRecord != null)
            {
                request.AddPostParam("ConferenceRecord", ConferenceRecord.ToString());
            }
            
            if (ConferenceTrim != null)
            {
                request.AddPostParam("ConferenceTrim", ConferenceTrim);
            }
            
            if (ConferenceStatusCallback != null)
            {
                request.AddPostParam("ConferenceStatusCallback", ConferenceStatusCallback.ToString());
            }
            
            if (ConferenceStatusCallbackMethod != null)
            {
                request.AddPostParam("ConferenceStatusCallbackMethod", ConferenceStatusCallbackMethod.ToString());
            }
            
            if (ConferenceStatusCallbackEvent != null)
            {
                request.AddPostParam("ConferenceStatusCallbackEvent", ConferenceStatusCallbackEvent);
            }
        }
    }
}
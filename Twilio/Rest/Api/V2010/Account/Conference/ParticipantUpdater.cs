using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantUpdater : Updater<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public string CallSid { get; }
        public bool? Muted { get; set; }
        public bool? Hold { get; set; }
        public Uri HoldUrl { get; set; }
        public Twilio.Http.HttpMethod HoldMethod { get; set; }
    
        /// <summary>
        /// Construct a new ParticipantUpdater
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public ParticipantUpdater(string conferenceSid, string callSid)
        {
            ConferenceSid = conferenceSid;
            CallSid = callSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ParticipantResource </returns> 
        public override async System.Threading.Tasks.Task<ParticipantResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants/" + CallSid + ".json"
            );
            AddPostParams(request);
            
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
        public override ParticipantResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants/" + CallSid + ".json"
            );
            AddPostParams(request);
            
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
        private void AddPostParams(Request request)
        {
            if (Muted != null)
            {
                request.AddPostParam("Muted", Muted.ToString());
            }
            
            if (Hold != null)
            {
                request.AddPostParam("Hold", Hold.ToString());
            }
            
            if (HoldUrl != null)
            {
                request.AddPostParam("HoldUrl", HoldUrl.ToString());
            }
            
            if (HoldMethod != null)
            {
                request.AddPostParam("HoldMethod", HoldMethod.ToString());
            }
        }
    }
}
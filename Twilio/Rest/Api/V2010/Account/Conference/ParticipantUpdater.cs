using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantUpdater : Updater<ParticipantResource> 
    {
        public string accountSid { get; set; }
        public string conferenceSid { get; }
        public string callSid { get; }
        public bool? muted { get; set; }
        public bool? hold { get; set; }
        public Uri holdUrl { get; set; }
        public Twilio.Http.HttpMethod holdMethod { get; set; }
    
        /// <summary>
        /// Construct a new ParticipantUpdater
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public ParticipantUpdater(string conferenceSid, string callSid)
        {
            this.conferenceSid = conferenceSid;
            this.callSid = callSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ParticipantResource </returns> 
        public override async Task<ParticipantResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
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
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants/" + this.callSid + ".json"
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
            if (muted != null)
            {
                request.AddPostParam("Muted", muted.ToString());
            }
            
            if (hold != null)
            {
                request.AddPostParam("Hold", hold.ToString());
            }
            
            if (holdUrl != null)
            {
                request.AddPostParam("HoldUrl", holdUrl.ToString());
            }
            
            if (holdMethod != null)
            {
                request.AddPostParam("HoldMethod", holdMethod.ToString());
            }
        }
    }
}
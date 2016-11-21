using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class OriginationUrlUpdater : Updater<OriginationUrlResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
        public int? Weight { get; set; }
        public int? Priority { get; set; }
        public bool? Enabled { get; set; }
        public string FriendlyName { get; set; }
        public Uri SipUrl { get; set; }
    
        /// <summary>
        /// Construct a new OriginationUrlUpdater
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public OriginationUrlUpdater(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated OriginationUrlResource </returns> 
        public override async System.Threading.Tasks.Task<OriginationUrlResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + TrunkSid + "/OriginationUrls/" + Sid + "",
                client.Region
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated OriginationUrlResource </returns> 
        public override OriginationUrlResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + TrunkSid + "/OriginationUrls/" + Sid + "",
                client.Region
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Weight != null)
            {
                request.AddPostParam("Weight", Weight.ToString());
            }
            
            if (Priority != null)
            {
                request.AddPostParam("Priority", Priority.ToString());
            }
            
            if (Enabled != null)
            {
                request.AddPostParam("Enabled", Enabled.ToString());
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (SipUrl != null)
            {
                request.AddPostParam("SipUrl", SipUrl.ToString());
            }
        }
    }
}
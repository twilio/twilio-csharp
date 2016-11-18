using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class RatePlanCreator : Creator<RatePlanResource> 
    {
        public string Alias { get; set; }
        public string FriendlyName { get; set; }
        public List<string> Roaming { get; set; }
        public int? DataLimit { get; set; }
        public string DataMetering { get; set; }
        public bool? CommandsEnabled { get; set; }
        public int? RenewalPeriod { get; set; }
        public string RenewalUnits { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created RatePlanResource </returns> 
        public override async System.Threading.Tasks.Task<RatePlanResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/RatePlans"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("RatePlanResource creation failed: Unable to connect to server");
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
            
            return RatePlanResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created RatePlanResource </returns> 
        public override RatePlanResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/RatePlans"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("RatePlanResource creation failed: Unable to connect to server");
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
            
            return RatePlanResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Alias != null)
            {
                request.AddPostParam("Alias", Alias);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (Roaming != null)
            {
                request.AddPostParam("Roaming", Roaming.ToString());
            }
            
            if (DataLimit != null)
            {
                request.AddPostParam("DataLimit", DataLimit.ToString());
            }
            
            if (DataMetering != null)
            {
                request.AddPostParam("DataMetering", DataMetering);
            }
            
            if (CommandsEnabled != null)
            {
                request.AddPostParam("CommandsEnabled", CommandsEnabled.ToString());
            }
            
            if (RenewalPeriod != null)
            {
                request.AddPostParam("RenewalPeriod", RenewalPeriod.ToString());
            }
            
            if (RenewalUnits != null)
            {
                request.AddPostParam("RenewalUnits", RenewalUnits);
            }
        }
    }
}
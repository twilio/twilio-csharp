using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ConferenceReader : Reader<ConferenceResource> 
    {
        public string AccountSid { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateCreatedAfter { get; set; }
        public DateTime? DateCreatedBefore { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateUpdatedAfter { get; set; }
        public DateTime? DateUpdatedBefore { get; set; }
        public string FriendlyName { get; set; }
        public ConferenceResource.StatusEnum Status { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ConferenceResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<ConferenceResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Conferences.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ConferenceResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ConferenceResource ResourceSet </returns> 
        public override ResourceSet<ConferenceResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Conferences.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ConferenceResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ConferenceResource> NextPage(Page<ConferenceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Rest.Domain.Api
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of ConferenceResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<ConferenceResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ConferenceResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (DateCreated != null)
            {
                request.AddQueryParam("DateCreated", DateCreated.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    request.AddQueryParam("DateCreated<", DateCreatedBefore.Value.ToString("yyyy-MM-dd"));
                }
                if (DateCreatedAfter != null)
                {
                    request.AddQueryParam("DateCreated>", DateCreatedAfter.Value.ToString("yyyy-MM-dd"));
                }
            }
            
            if (DateUpdated != null)
            {
                request.AddQueryParam("DateUpdated", DateUpdated.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                if (DateUpdatedBefore != null)
                {
                    request.AddQueryParam("DateUpdated<", DateUpdatedBefore.Value.ToString("yyyy-MM-dd"));
                }
                if (DateUpdatedAfter != null)
                {
                    request.AddQueryParam("DateUpdated>", DateUpdatedAfter.Value.ToString("yyyy-MM-dd"));
                }
            }
            
            if (FriendlyName != null)
            {
                request.AddQueryParam("FriendlyName", FriendlyName);
            }
            
            if (Status != null)
            {
                request.AddQueryParam("Status", Status.ToString());
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
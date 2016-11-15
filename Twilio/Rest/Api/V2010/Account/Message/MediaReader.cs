using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class MediaReader : Reader<MediaResource> 
    {
        public string AccountSid { get; set; }
        public string MessageSid { get; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateCreatedAfter { get; set; }
        public DateTime? DateCreatedBefore { get; set; }
    
        /// <summary>
        /// Construct a new MediaReader
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        public MediaReader(string messageSid)
        {
            MessageSid = messageSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MediaResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<MediaResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Messages/" + MessageSid + "/Media.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<MediaResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MediaResource ResourceSet </returns> 
        public override ResourceSet<MediaResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Messages/" + MessageSid + "/Media.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<MediaResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<MediaResource> NextPage(Page<MediaResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.Api
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of MediaResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<MediaResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MediaResource read failed: Unable to connect to server");
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
            
            return Page<MediaResource>.FromJson("media_list", response.Content);
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
                request.AddQueryParam("DateCreated", DateCreated.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
            }
            else
            {
                if (DateCreatedBefore != null)
                {
                    request.AddQueryParam("DateCreated<", DateCreatedBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
                if (DateCreatedAfter != null)
                {
                    request.AddQueryParam("DateCreated>", DateCreatedAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallReader : Reader<CallResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber To { get; set; }
        public Types.PhoneNumber From { get; set; }
        public string ParentCallSid { get; set; }
        public CallResource.StatusEnum Status { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StartTimeAfter { get; set; }
        public DateTime? StartTimeBefore { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? EndTimeAfter { get; set; }
        public DateTime? EndTimeBefore { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> CallResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<CallResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<CallResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> CallResource ResourceSet </returns> 
        public override ResourceSet<CallResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<CallResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<CallResource> NextPage(Page<CallResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of CallResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<CallResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CallResource read failed: Unable to connect to server");
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
            
            return Page<CallResource>.FromJson("calls", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (To != null)
            {
                request.AddQueryParam("To", To.ToString());
            }
            
            if (From != null)
            {
                request.AddQueryParam("From", From.ToString());
            }
            
            if (ParentCallSid != null)
            {
                request.AddQueryParam("ParentCallSid", ParentCallSid);
            }
            
            if (Status != null)
            {
                request.AddQueryParam("Status", Status.ToString());
            }
            
            if (StartTime != null)
            {
                request.AddQueryParam("StartTime", StartTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
            }
            else
            {
                if (StartTimeBefore != null)
                {
                    request.AddQueryParam("StartTime<", StartTimeBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
                if (StartTimeAfter != null)
                {
                    request.AddQueryParam("StartTime>", StartTimeAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
            }
            
            if (EndTime != null)
            {
                request.AddQueryParam("EndTime", EndTime.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
            }
            else
            {
                if (EndTimeBefore != null)
                {
                    request.AddQueryParam("EndTime<", EndTimeBefore.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
                if (EndTimeAfter != null)
                {
                    request.AddQueryParam("EndTime>", EndTimeAfter.Value.ToString("yyyy-MM-dd'T'HH:mm:ssZ"));
                }
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
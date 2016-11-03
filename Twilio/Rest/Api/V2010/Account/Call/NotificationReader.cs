using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class NotificationReader : Reader<NotificationResource> 
    {
        public string accountSid { get; set; }
        public string callSid { get; }
        public int? log { get; set; }
        public DateTime? messageDate { get; set; }
        public DateTime? messageDateAfter { get; set; }
        public DateTime? messageDateBefore { get; set; }
    
        /// <summary>
        /// Construct a new NotificationReader
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        public NotificationReader(string callSid)
        {
            this.callSid = callSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> NotificationResource ResourceSet </returns> 
        public override Task<ResourceSet<NotificationResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.callSid + "/Notifications.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<NotificationResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> NotificationResource ResourceSet </returns> 
        public override ResourceSet<NotificationResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.callSid + "/Notifications.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<NotificationResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<NotificationResource> NextPage(Page<NotificationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of NotificationResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<NotificationResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource read failed: Unable to connect to server");
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
            
            return Page<NotificationResource>.FromJson("notifications", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (log != null)
            {
                request.AddQueryParam("Log", log.ToString());
            }
            
            if (messageDate != null)
            {
                request.AddQueryParam("MessageDate", messageDate.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                if (messageDateBefore != null)
                {
                    request.AddQueryParam("MessageDate<", messageDateBefore.Value.ToString("yyyy-MM-dd"));
                }
                if (messageDateAfter != null)
                {
                    request.AddQueryParam("MessageDate>", messageDateAfter.Value.ToString("yyyy-MM-dd"));
                }
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
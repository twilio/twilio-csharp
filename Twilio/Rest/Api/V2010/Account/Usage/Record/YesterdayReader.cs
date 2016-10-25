using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage.Record 
{

    public class YesterdayReader : Reader<YesterdayResource> 
    {
        public string accountSid { get; }
        public YesterdayResource.Category category { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    
        /// <summary>
        /// Construct a new YesterdayReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="category"> The category </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        public YesterdayReader(string accountSid=null, YesterdayResource.Category category=null, DateTime? startDate=null, DateTime? endDate=null)
        {
            this.accountSid = accountSid;
            this.category = category;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> YesterdayResource ResourceSet </returns> 
        public override Task<ResourceSet<YesterdayResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Records/Yesterday.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<YesterdayResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> YesterdayResource ResourceSet </returns> 
        public override ResourceSet<YesterdayResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Usage/Records/Yesterday.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<YesterdayResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<YesterdayResource> NextPage(Page<YesterdayResource> page, ITwilioRestClient client)
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
        /// Generate a Page of YesterdayResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<YesterdayResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("YesterdayResource read failed: Unable to connect to server");
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
            
            return Page<YesterdayResource>.FromJson("usage_records", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (category != null)
            {
                request.AddQueryParam("Category", category.ToString());
            }
            
            if (startDate != null)
            {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null)
            {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage.Record {

    public class ThisMonthReader : Reader<ThisMonthResource> {
        private string accountSid;
        private ThisMonthResource.Category category;
        private DateTime? startDate;
        private DateTime? endDate;
    
        /// <summary>
        /// Construct a new ThisMonthReader.
        /// </summary>
        public ThisMonthReader() {
        }
    
        /// <summary>
        /// Construct a new ThisMonthReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public ThisMonthReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// The category
        /// </summary>
        ///
        /// <param name="category"> The category </param>
        /// <returns> this </returns> 
        public ThisMonthReader ByCategory(ThisMonthResource.Category category) {
            this.category = category;
            return this;
        }
    
        /// <summary>
        /// The start_date
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <returns> this </returns> 
        public ThisMonthReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /// <summary>
        /// The end_date
        /// </summary>
        ///
        /// <param name="endDate"> The end_date </param>
        /// <returns> this </returns> 
        public ThisMonthReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ThisMonthResource ResourceSet </returns> 
        public override Task<ResourceSet<ThisMonthResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records/ThisMonth.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ThisMonthResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ThisMonthResource ResourceSet </returns> 
        public override ResourceSet<ThisMonthResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records/ThisMonth.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ThisMonthResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ThisMonthResource> NextPage(Page<ThisMonthResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of ThisMonthResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<ThisMonthResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ThisMonthResource read failed: Unable to connect to server");
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
            
            return Page<ThisMonthResource>.FromJson("usage_records", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (category != null) {
                request.AddQueryParam("Category", category.ToString());
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}
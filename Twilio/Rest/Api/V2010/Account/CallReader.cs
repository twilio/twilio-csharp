using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CallReader : Reader<CallResource> 
    {
        public string accountSid { get; }
        public Twilio.Types.PhoneNumber to { get; set; }
        public Twilio.Types.PhoneNumber from { get; set; }
        public string parentCallSid { get; set; }
        public CallResource.Status status { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    
        /// <summary>
        /// Construct a new CallReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="to"> Phone number or Client identifier to filter `to` on </param>
        /// <param name="from"> Phone number or Client identifier to filter `from` on </param>
        /// <param name="parentCallSid"> Parent Call Sid to filter on </param>
        /// <param name="status"> Status to filter on </param>
        /// <param name="startTime"> StartTime to filter on </param>
        /// <param name="endTime"> EndTime to filter on </param>
        public CallReader(string accountSid=null, Twilio.Types.PhoneNumber to=null, Twilio.Types.PhoneNumber from=null, string parentCallSid=null, CallResource.Status status=null, string startTime=null, string endTime=null)
        {
            this.startTime = startTime;
            this.parentCallSid = parentCallSid;
            this.from = from;
            this.accountSid = accountSid;
            this.status = status;
            this.endTime = endTime;
            this.to = to;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> CallResource ResourceSet </returns> 
        public override Task<ResourceSet<CallResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls.json"
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
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<CallResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<CallResource> NextPage(Page<CallResource> page, ITwilioRestClient client)
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
            if (to != null)
            {
                request.AddQueryParam("To", to.ToString());
            }
            
            if (from != null)
            {
                request.AddQueryParam("From", from.ToString());
            }
            
            if (parentCallSid != null)
            {
                request.AddQueryParam("ParentCallSid", parentCallSid);
            }
            
            if (status != null)
            {
                request.AddQueryParam("Status", status.ToString());
            }
            
            
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
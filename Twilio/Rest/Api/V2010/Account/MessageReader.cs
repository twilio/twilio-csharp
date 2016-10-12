using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class MessageReader : Reader<MessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string dateSent;
    
        /// <summary>
        /// Construct a new MessageReader.
        /// </summary>
        public MessageReader() {
        }
    
        /// <summary>
        /// Construct a new MessageReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public MessageReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// Filter by messages to this number
        /// </summary>
        ///
        /// <param name="to"> Filter by messages to this number </param>
        /// <returns> this </returns> 
        public MessageReader ByTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /// <summary>
        /// Only show messages from this phone number
        /// </summary>
        ///
        /// <param name="from"> Filter by from number </param>
        /// <returns> this </returns> 
        public MessageReader ByFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /// <summary>
        /// Filter messages sent by this date
        /// </summary>
        ///
        /// <param name="dateSent"> Filter by date sent </param>
        /// <returns> this </returns> 
        public MessageReader ByDateSent(string dateSent) {
            this.dateSent = dateSent;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MessageResource ResourceSet </returns> 
        public override Task<ResourceSet<MessageResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<MessageResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MessageResource ResourceSet </returns> 
        public override ResourceSet<MessageResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<MessageResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<MessageResource> NextPage(Page<MessageResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of MessageResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<MessageResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource read failed: Unable to connect to server");
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
            
            return Page<MessageResource>.FromJson("messages", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (to != null) {
                request.AddQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from.ToString());
            }
            
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}
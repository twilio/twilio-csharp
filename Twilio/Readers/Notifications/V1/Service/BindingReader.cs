using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Notifications.V1.Service;

namespace Twilio.Readers.Notifications.V1.Service {

    public class BindingReader : Reader<BindingResource> {
        private string serviceSid;
        private string startDate;
        private string endDate;
        private List<string> identity;
        private List<string> tag;
    
        /**
         * Construct a new BindingReader
         * 
         * @param serviceSid The service_sid
         */
        public BindingReader(string serviceSid) {
            this.serviceSid = serviceSid;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public BindingReader byStartDate(string startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public BindingReader byEndDate(string endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The identity
         * 
         * @param identity The identity
         * @return this
         */
        public BindingReader byIdentity(List<string> identity) {
            this.identity = identity;
            return this;
        }
    
        /**
         * The identity
         * 
         * @param identity The identity
         * @return this
         */
        public BindingReader byIdentity(string identity) {
            return byIdentity(Promoter.ListOfOne(identity));
        }
    
        /**
         * The tag
         * 
         * @param tag The tag
         * @return this
         */
        public BindingReader byTag(List<string> tag) {
            this.tag = tag;
            return this;
        }
    
        /**
         * The tag
         * 
         * @param tag The tag
         * @return this
         */
        public BindingReader byTag(string tag) {
            return byTag(Promoter.ListOfOne(tag));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return BindingResource ResourceSet
         */
        public override Task<ResourceSet<BindingResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            AddQueryParams(request);
            
            Page<BindingResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<BindingResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return BindingResource ResourceSet
         */
        public override ResourceSet<BindingResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            AddQueryParams(request);
            
            Page<BindingResource> page = PageForRequest(client, request);
            
            return new ResourceSet<BindingResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<BindingResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of BindingResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<BindingResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("BindingResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            Page<BindingResource> result = new Page<BindingResource>();
            result.deserialize("bindings", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate);
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate);
            }
            
            if (identity != null) {
                request.AddQueryParam("Identity", identity.ToString());
            }
            
            if (tag != null) {
                request.AddQueryParam("Tag", tag.ToString());
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}
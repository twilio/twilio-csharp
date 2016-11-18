using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
{

    public class MemberReader : Reader<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public List<string> Identity { get; set; }
    
        /// <summary>
        /// Construct a new MemberReader
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        public MemberReader(string serviceSid, string channelSid)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MemberResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels/" + ChannelSid + "/Members"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<MemberResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> MemberResource ResourceSet </returns> 
        public override ResourceSet<MemberResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels/" + ChannelSid + "/Members"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<MemberResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<MemberResource> NextPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.IpMessaging
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of MemberResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<MemberResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource read failed: Unable to connect to server");
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
            
            return Page<MemberResource>.FromJson("members", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (Identity != null)
            {
                request.AddQueryParam("Identity", Identity.ToString());
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service 
{

    public class NotificationCreator : Creator<NotificationResource> 
    {
        public string ServiceSid { get; }
        public List<string> Identity { get; set; }
        public List<string> Tag { get; set; }
        public string Body { get; set; }
        public NotificationResource.PriorityEnum Priority { get; set; }
        public int? Ttl { get; set; }
        public string Title { get; set; }
        public string Sound { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public string Apn { get; set; }
        public string Gcm { get; set; }
        public string Sms { get; set; }
        public Object FacebookMessenger { get; set; }
    
        /// <summary>
        /// Construct a new NotificationCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public NotificationCreator(string serviceSid)
        {
            ServiceSid = serviceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created NotificationResource </returns> 
        public override async Task<NotificationResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.ServiceSid + "/Notifications"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return NotificationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created NotificationResource </returns> 
        public override NotificationResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.ServiceSid + "/Notifications"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return NotificationResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (Identity != null)
            {
                request.AddPostParam("Identity", Identity.ToString());
            }
            
            if (Tag != null)
            {
                request.AddPostParam("Tag", Tag.ToString());
            }
            
            if (Body != null)
            {
                request.AddPostParam("Body", Body);
            }
            
            if (Priority != null)
            {
                request.AddPostParam("Priority", Priority.ToString());
            }
            
            if (Ttl != null)
            {
                request.AddPostParam("Ttl", Ttl.ToString());
            }
            
            if (Title != null)
            {
                request.AddPostParam("Title", Title);
            }
            
            if (Sound != null)
            {
                request.AddPostParam("Sound", Sound);
            }
            
            if (Action != null)
            {
                request.AddPostParam("Action", Action);
            }
            
            if (Data != null)
            {
                request.AddPostParam("Data", Data);
            }
            
            if (Apn != null)
            {
                request.AddPostParam("Apn", Apn);
            }
            
            if (Gcm != null)
            {
                request.AddPostParam("Gcm", Gcm);
            }
            
            if (Sms != null)
            {
                request.AddPostParam("Sms", Sms);
            }
            
            if (FacebookMessenger != null)
            {
                request.AddPostParam("FacebookMessenger", FacebookMessenger.ToString());
            }
        }
    }
}
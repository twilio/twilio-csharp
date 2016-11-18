using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Call;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class NotificationDeleter : Deleter<NotificationResource> 
    {
        public string AccountSid { get; set; }
        public string CallSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new NotificationDeleter
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        public NotificationDeleter(string callSid, string sid)
        {
            CallSid = callSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls/" + CallSid + "/Notifications/" + Sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override void Delete(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Calls/" + CallSid + "/Notifications/" + Sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}
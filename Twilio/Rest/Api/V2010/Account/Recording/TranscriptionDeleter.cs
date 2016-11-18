using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Recording;

namespace Twilio.Rest.Api.V2010.Account.Recording 
{

    public class TranscriptionDeleter : Deleter<TranscriptionResource> 
    {
        public string AccountSid { get; set; }
        public string RecordingSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new TranscriptionDeleter
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="sid"> The sid </param>
        public TranscriptionDeleter(string recordingSid, string sid)
        {
            RecordingSid = recordingSid;
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
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Recordings/" + RecordingSid + "/Transcriptions/" + Sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TranscriptionResource delete failed: Unable to connect to server");
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
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Recordings/" + RecordingSid + "/Transcriptions/" + Sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TranscriptionResource delete failed: Unable to connect to server");
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
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Trunking.V1;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1 {

    public class TrunkDeleter : Deleter<TrunkResource> {
        private string sid;
    
        /**
         * Construct a new TrunkDeleter
         * 
         * @param sid The sid
         */
        public TrunkDeleter(string sid) {
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.sid + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource delete failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override void Delete(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.sid + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource delete failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}
using System;
using Simple;
using System.Text;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        /// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync<T>(RestRequest request, Action<T> callback) where T : new()
        {
            request.OnBeforeDeserialization = (resp) =>
            {
                // for individual resources when there's an error to make
                // sure that RestException props are populated
                if (((int)resp.StatusCode) >= 400)
                {
                    // have to read the bytes so .Content doesn't get populated
                    var restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

                    resp.Content = null;
                    resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
                }
            };

            request.DateFormat = "ddd, dd MMM yyyy HH:mm:ss '+0000'";

            _client.ExecuteAsync<T>(request, (response) => callback(response.Data));
        }

        /// <summary>
        /// Execute a manual REST request
        /// </summary>
        /// <param name="request">The RestRequest to execute (will use client credentials)</param>
        /// <param name="callback">The callback function to execute when the async request completes</param>
        public virtual void ExecuteAsync(RestRequest request, Action<RestResponse> callback)
        {
            _client.ExecuteAsync(request, callback);
        }
    }
}
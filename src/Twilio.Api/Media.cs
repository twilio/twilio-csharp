using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
    public partial class TwilioRestClient
    {

        /// <summary>
        /// Get the details for a specific Media instance.
        /// </summary>
        /// <param name="mediaSid">The Sid of the media resource</param>
        /// <returns></returns>
        public virtual Media GetMedia(string messageSid, string mediaSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}/Media/{MediaSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);
            request.AddUrlSegment("MediaSid", mediaSid);
            return Execute<Media>(request);
        }

        /// <summary>
        /// Retrieve a list of Media objects with no list filters
        /// </summary>
		public virtual MediaResult ListMedia(string messageSid)
        {
            return ListMedia(messageSid, new MediaListRequest());
        }

        /// <summary>
        /// Return a filtered list of Media objects. The list includes paging
        /// information.
        /// </summary>
		public virtual MediaResult ListMedia(string messageSid, MediaListRequest options)
        {
            return ListMessageMedia(messageSid, options);
        }

        /// <summary>
        /// List all media for a particular message
        /// </summary>
        /// <param name="messageSid">The message sid to filter on</param>
		public virtual MediaResult ListMessageMedia(string messageSid, MediaListRequest options)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}/Media.json";
            request.AddUrlSegment("MessageSid", messageSid);
            AddMediaListOptions(options, request);
            return Execute<MediaResult>(request);
        }

        /// <summary>
        /// Delete the specified media instance. Makes a DELETE request to a
        /// Media Instance resource.
        /// </summary>
        /// <param name="mediaSid">The Sid of the media to delete</param>
        public virtual DeleteStatus DeleteMedia(string messageSid, string mediaSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}/Media/{MediaSid}.json";
            request.AddUrlSegment("MessageSid", messageSid);
            request.AddUrlSegment("MediaSid", mediaSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

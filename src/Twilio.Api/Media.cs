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
        public Media GetMedia(string mediaSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Media/{MediaSid}.json";
            request.AddUrlSegment("MediaSid", mediaSid);
            return Execute<Media>(request);
        }

        /// <summary>
        /// Retrieve a list of Media objects with no list filters
        /// </summary>
        public MediaResult ListMedia()
        {
            return ListMedia(new MediaListRequest());
        }

        /// <summary>
        /// Return a filtered list of Media objects. The list includes paging
        /// information.
        /// </summary>
        public MediaResult ListMedia(MediaListRequest options)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Media.json";
            AddMediaListOptions(options, request);
            return Execute<MediaResult>(request);
        }

        /// <summary>
        /// List all media for a particular message
        /// </summary>
        /// <param name="messageSid">The message sid to filter on</param>
        public MediaResult ListMessageMedia(string messageSid, MediaListRequest options)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Messages/{MessageSid}/Media.json";
            request.AddUrlSegment("MessageSid", messageSid);
            AddMediaListOptions(options, request);
            return Execute<MediaResult>(request);
        }

        /// <summary>
        /// Add the options to the request
        /// </summary>
        private void AddMediaListOptions(MediaListRequest options, RestRequest request)
        {
            if (options.ParentSid.HasValue()) request.AddParameter("ParentSid", options.ParentSid);
            // Construct the date filter
            if (options.DateCreated.HasValue)
            {
                var dateCreatedParameterName = GetParameterNameWithEquality(options.DateCreatedComparison, "DateCreated");
                request.AddParameter(dateCreatedParameterName, options.DateCreated.Value.ToString("yyyy-MM-dd"));
            }

            // Paging options
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
        }

        /// <summary>
        /// Delete the specified media instance. Makes a DELETE request to a 
        /// Media Instance resource.
        /// </summary>
        /// <param name="mediaSid">The Sid of the media to delete</param>
        public DeleteStatus DeleteMedia(string mediaSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Media/{MediaSid}.json";

            request.AddParameter("MediaSid", mediaSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}

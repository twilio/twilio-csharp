using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Returns a list of Recordings, each representing a recording generated during the course of a phone call. 
        /// The list includes paging information.
        /// Makes a GET request to the Recordings List resource.
        /// </summary>
        public ImageResult ListImages()
        {
            return ListImages(null, null, null, null);
        }

        /// <summary>
        /// Returns a filtered list of Recordings, each representing a recording generated during the course of a phone call. 
        /// The list includes paging information.
        /// Makes a GET request to the Recordings List resource.
        /// </summary>
        /// <param name="messageSid">(Optional) The CallSid to retrieve recordings for</param>
        /// <param name="dateCreated">(Optional) The date the recording was created (GMT)</param>
        /// <param name="pageNumber">The page to start retrieving results from</param>
        /// <param name="count">How many results to retrieve</param>
        public ImageResult ListImages(string messageSid, DateTime? dateCreated, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Media/Images.json";

            if (messageSid.HasValue()) request.AddParameter("MessageSid", messageSid);
            if (dateCreated.HasValue) request.AddParameter("DateCreated", dateCreated.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            return Execute<ImageResult>(request);
        }

        /// <summary>
        /// Retrieve the details for the specified recording instance.
        /// Makes a GET request to a Recording Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to retrieve</param>
        public Image GetImage(string imageSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Media/Images/{ImageSid}.json";

            request.AddParameter("ImageSid", imageSid, ParameterType.UrlSegment);

            return Execute<Image>(request);
        }

        /// <summary>
        /// Delete the specified recording instance. Makes a DELETE request to a Recording Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to delete</param>
        public DeleteStatus DeleteImage(string imageSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Media/Images/{ImageSid}.json";

            request.AddParameter("ImageSid", imageSid, ParameterType.UrlSegment);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}
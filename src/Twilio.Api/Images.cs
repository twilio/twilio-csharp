using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Returns a list of Images. 
        /// The list includes paging information.
        /// Makes a GET request to the Images List resource.
        /// </summary>
        public ImageResult ListImages()
        {
            return ListImages(null, null, null, null);
        }

        /// <summary>
        /// Returns a filtered list of Images, each representing a image. 
        /// The list includes paging information.
        /// Makes a GET request to the Images List resource.
        /// </summary>
        /// <param name="messageSid">(Optional) The Message to retrieve images for</param>
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
        /// Retrieve the details for the specified image instance.
        /// Makes a GET request to a Image Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the image to retrieve</param>
        public Image GetImage(string imageSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Media/Images/{ImageSid}.json";

            request.AddParameter("ImageSid", imageSid, ParameterType.UrlSegment);

            return Execute<Image>(request);
        }

        /// <summary>
        /// Delete the specified image instance. Makes a DELETE request to a Image Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the image to delete</param>
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
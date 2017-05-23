using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.BulkExports.Export 
{

    /// <summary>
    /// DayResource
    /// </summary>
    public class DayResource : Resource 
    {
        private static Request BuildReadRequest(ReadDayOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/BulkExports/Exports/" + options.PathResourceType + "/Days",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Day parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Day </returns> 
        public static ResourceSet<DayResource> Read(ReadDayOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<DayResource>.FromJson("days", response.Content);
            return new ResourceSet<DayResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Day parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Day </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DayResource>> ReadAsync(ReadDayOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DayResource>.FromJson("days", response.Content);
            return new ResourceSet<DayResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathResourceType"> The resource_type </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Day </returns> 
        public static ResourceSet<DayResource> Read(string pathResourceType, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDayOptions(pathResourceType){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathResourceType"> The resource_type </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Day </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DayResource>> ReadAsync(string pathResourceType, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDayOptions(pathResourceType){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<DayResource> NextPage(Page<DayResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<DayResource>.FromJson("days", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a DayResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DayResource object represented by the provided JSON </returns> 
        public static DayResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DayResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The redirect_to
        /// </summary>
        [JsonProperty("redirect_to")]
        public Uri RedirectTo { get; private set; }
        /// <summary>
        /// The day
        /// </summary>
        [JsonProperty("day")]
        public string Day { get; private set; }
        /// <summary>
        /// The size
        /// </summary>
        [JsonProperty("size")]
        public int? Size { get; private set; }
        /// <summary>
        /// The resource_type
        /// </summary>
        [JsonProperty("resource_type")]
        public string ResourceType { get; private set; }

        private DayResource()
        {

        }
    }

}
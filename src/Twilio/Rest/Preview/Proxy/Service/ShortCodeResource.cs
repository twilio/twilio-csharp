using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Proxy.Service 
{

    /// <summary>
    /// ShortCodeResource
    /// </summary>
    public class ShortCodeResource : Resource 
    {
        private static Request BuildCreateRequest(CreateShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/ShortCodes",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Add an existing shortcode to this service to be used as a Proxy Number
        /// </summary>
        ///
        /// <param name="options"> Create ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Create(CreateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Add an existing shortcode to this service to be used as a Proxy Number
        /// </summary>
        ///
        /// <param name="options"> Create ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> CreateAsync(CreateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Add an existing shortcode to this service to be used as a Proxy Number
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="sid"> Delete by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Create(string pathServiceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new CreateShortCodeOptions(pathServiceSid, sid);
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Add an existing shortcode to this service to be used as a Proxy Number
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="sid"> Delete by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> CreateAsync(string pathServiceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new CreateShortCodeOptions(pathServiceSid, sid);
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/ShortCodes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a shortcode belonging to this service.
        /// </summary>
        ///
        /// <param name="options"> Delete ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static bool Delete(DeleteShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a shortcode belonging to this service.
        /// </summary>
        ///
        /// <param name="options"> Delete ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a shortcode belonging to this service.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> Delete by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteShortCodeOptions(pathServiceSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a shortcode belonging to this service.
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> Delete by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteShortCodeOptions(pathServiceSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/ShortCodes",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of shortcodes belonging to this service
        /// </summary>
        ///
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ResourceSet<ShortCodeResource> Read(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of shortcodes belonging to this service
        /// </summary>
        ///
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of shortcodes belonging to this service
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ResourceSet<ShortCodeResource> Read(string pathServiceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of shortcodes belonging to this service
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(string pathServiceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        ///
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns> 
        public static Page<ShortCodeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns> 
        public static Page<ShortCodeResource> PreviousPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        private static Request BuildFetchRequest(FetchShortCodeOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Proxy/Services/" + options.PathServiceSid + "/ShortCodes/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a shortcode belonging to this service
        /// </summary>
        ///
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Fetch(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a shortcode belonging to this service
        /// </summary>
        ///
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a shortcode belonging to this service
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> Fetch by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns> 
        public static ShortCodeResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a shortcode belonging to this service
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathSid"> Fetch by unique shortcode Sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns> 
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns> 
        public static ShortCodeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// A string that uniquely identifies this resource
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// Account Sid.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// Service Sid.
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The date this resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date this resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The short code. e.g., 894546.
        /// </summary>
        [JsonProperty("short_code")]
        public string ShortCode { get; private set; }
        /// <summary>
        /// The ISO 3166-1 alpha-2 country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }
        /// <summary>
        /// Indicate if a shortcode can receive messages
        /// </summary>
        [JsonProperty("capabilities")]
        public List<object> Capabilities { get; private set; }
        /// <summary>
        /// The URL of this resource.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private ShortCodeResource()
        {

        }
    }

}
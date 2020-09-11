/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// IpRecordResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Voice.V1
{

    public class IpRecordResource : Resource
    {
        private static Request BuildCreateRequest(CreateIpRecordOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Voice,
                "/v1/IpRecords",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Create(CreateIpRecordOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> CreateAsync(CreateIpRecordOptions options,
                                                                                      ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        /// <param name="ipAddress"> An IP address in dotted decimal notation, IPv4 only. </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="cidrPrefixLength"> An integer representing the length of the
        ///                        [CIDR](https://tools.ietf.org/html/rfc4632) prefix to use with this IP address. By default
        ///                        the entire IP address is used, which for IPv4 is value 32. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Create(string ipAddress,
                                              string friendlyName = null,
                                              int? cidrPrefixLength = null,
                                              ITwilioRestClient client = null)
        {
            var options = new CreateIpRecordOptions(ipAddress){FriendlyName = friendlyName, CidrPrefixLength = cidrPrefixLength};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="ipAddress"> An IP address in dotted decimal notation, IPv4 only. </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="cidrPrefixLength"> An integer representing the length of the
        ///                        [CIDR](https://tools.ietf.org/html/rfc4632) prefix to use with this IP address. By default
        ///                        the entire IP address is used, which for IPv4 is value 32. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> CreateAsync(string ipAddress,
                                                                                      string friendlyName = null,
                                                                                      int? cidrPrefixLength = null,
                                                                                      ITwilioRestClient client = null)
        {
            var options = new CreateIpRecordOptions(ipAddress){FriendlyName = friendlyName, CidrPrefixLength = cidrPrefixLength};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchIpRecordOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Voice,
                "/v1/IpRecords/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Fetch(FetchIpRecordOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> FetchAsync(FetchIpRecordOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Fetch(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchIpRecordOptions(pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> FetchAsync(string pathSid,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new FetchIpRecordOptions(pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadIpRecordOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Voice,
                "/v1/IpRecords",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static ResourceSet<IpRecordResource> Read(ReadIpRecordOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<IpRecordResource>.FromJson("ip_records", response.Content);
            return new ResourceSet<IpRecordResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpRecordResource>> ReadAsync(ReadIpRecordOptions options,
                                                                                                 ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<IpRecordResource>.FromJson("ip_records", response.Content);
            return new ResourceSet<IpRecordResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static ResourceSet<IpRecordResource> Read(int? pageSize = null,
                                                         long? limit = null,
                                                         ITwilioRestClient client = null)
        {
            var options = new ReadIpRecordOptions(){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpRecordResource>> ReadAsync(int? pageSize = null,
                                                                                                 long? limit = null,
                                                                                                 ITwilioRestClient client = null)
        {
            var options = new ReadIpRecordOptions(){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<IpRecordResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<IpRecordResource>.FromJson("ip_records", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<IpRecordResource> NextPage(Page<IpRecordResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Voice)
            );

            var response = client.Request(request);
            return Page<IpRecordResource>.FromJson("ip_records", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<IpRecordResource> PreviousPage(Page<IpRecordResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Voice)
            );

            var response = client.Request(request);
            return Page<IpRecordResource>.FromJson("ip_records", response.Content);
        }

        private static Request BuildUpdateRequest(UpdateIpRecordOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Voice,
                "/v1/IpRecords/" + options.PathSid + "",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Update(UpdateIpRecordOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> UpdateAsync(UpdateIpRecordOptions options,
                                                                                      ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static IpRecordResource Update(string pathSid, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateIpRecordOptions(pathSid){FriendlyName = friendlyName};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<IpRecordResource> UpdateAsync(string pathSid,
                                                                                      string friendlyName = null,
                                                                                      ITwilioRestClient client = null)
        {
            var options = new UpdateIpRecordOptions(pathSid){FriendlyName = friendlyName};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteIpRecordOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Voice,
                "/v1/IpRecords/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static bool Delete(DeleteIpRecordOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete IpRecord parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIpRecordOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpRecord </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpRecordOptions(pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpRecord </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpRecordOptions(pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a IpRecordResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpRecordResource object represented by the provided JSON </returns>
        public static IpRecordResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpRecordResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The string that you assigned to describe the resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// An IP address in dotted decimal notation, IPv4 only.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; private set; }
        /// <summary>
        /// An integer representing the length of the [CIDR](https://tools.ietf.org/html/rfc4632) prefix to use with this IP address. By default the entire IP address is used, which for IPv4 is value 32.
        /// </summary>
        [JsonProperty("cidr_prefix_length")]
        public int? CidrPrefixLength { get; private set; }
        /// <summary>
        /// The RFC 2822 date and time in GMT that the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The RFC 2822 date and time in GMT that the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The absolute URL of the resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private IpRecordResource()
        {

        }
    }

}
/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
///
/// SessionResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Proxy.V1.Service
{

    public class SessionResource : Resource
    {
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }

            public static readonly StatusEnum Open = new StatusEnum("open");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Closed = new StatusEnum("closed");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum Unknown = new StatusEnum("unknown");
        }

        public sealed class ModeEnum : StringEnum
        {
            private ModeEnum(string value) : base(value) {}
            public ModeEnum() {}
            public static implicit operator ModeEnum(string value)
            {
                return new ModeEnum(value);
            }

            public static readonly ModeEnum MessageOnly = new ModeEnum("message-only");
            public static readonly ModeEnum VoiceOnly = new ModeEnum("voice-only");
            public static readonly ModeEnum VoiceAndMessage = new ModeEnum("voice-and-message");
        }

        private static Request BuildFetchRequest(FetchSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Proxy,
                "/v1/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        /// <param name="options"> Fetch Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Fetch(FetchSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        /// <param name="options"> Fetch Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> FetchAsync(FetchSessionOptions options,
                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSessionOptions(pathServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> FetchAsync(string pathServiceSid,
                                                                                    string pathSid,
                                                                                    ITwilioRestClient client = null)
        {
            var options = new FetchSessionOptions(pathServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Proxy,
                "/v1/Services/" + options.PathServiceSid + "/Sessions",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Retrieve a list of all Sessions for the Service. A maximum of 100 records will be returned per page.
        /// </summary>
        /// <param name="options"> Read Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static ResourceSet<SessionResource> Read(ReadSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<SessionResource>.FromJson("sessions", response.Content);
            return new ResourceSet<SessionResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Sessions for the Service. A maximum of 100 records will be returned per page.
        /// </summary>
        /// <param name="options"> Read Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SessionResource>> ReadAsync(ReadSessionOptions options,
                                                                                                ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SessionResource>.FromJson("sessions", response.Content);
            return new ResourceSet<SessionResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all Sessions for the Service. A maximum of 100 records will be returned per page.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static ResourceSet<SessionResource> Read(string pathServiceSid,
                                                        int? pageSize = null,
                                                        long? limit = null,
                                                        ITwilioRestClient client = null)
        {
            var options = new ReadSessionOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all Sessions for the Service. A maximum of 100 records will be returned per page.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SessionResource>> ReadAsync(string pathServiceSid,
                                                                                                int? pageSize = null,
                                                                                                long? limit = null,
                                                                                                ITwilioRestClient client = null)
        {
            var options = new ReadSessionOptions(pathServiceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SessionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SessionResource> NextPage(Page<SessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Proxy)
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SessionResource> PreviousPage(Page<SessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Proxy)
            );

            var response = client.Request(request);
            return Page<SessionResource>.FromJson("sessions", response.Content);
        }

        private static Request BuildCreateRequest(CreateSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Proxy,
                "/v1/Services/" + options.PathServiceSid + "/Sessions",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Create a new Session
        /// </summary>
        /// <param name="options"> Create Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Create(CreateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Create a new Session
        /// </summary>
        /// <param name="options"> Create Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> CreateAsync(CreateSessionOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Create a new Session
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the parent Service resource </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource </param>
        /// <param name="dateExpiry"> The ISO 8601 date when the Session should expire </param>
        /// <param name="ttl"> When the session will expire </param>
        /// <param name="mode"> The Mode of the Session </param>
        /// <param name="status"> Session status </param>
        /// <param name="participants"> The Participant objects to include in the new session </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Create(string pathServiceSid,
                                             string uniqueName = null,
                                             DateTime? dateExpiry = null,
                                             int? ttl = null,
                                             SessionResource.ModeEnum mode = null,
                                             SessionResource.StatusEnum status = null,
                                             List<object> participants = null,
                                             ITwilioRestClient client = null)
        {
            var options = new CreateSessionOptions(pathServiceSid){UniqueName = uniqueName, DateExpiry = dateExpiry, Ttl = ttl, Mode = mode, Status = status, Participants = participants};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Create a new Session
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the parent Service resource </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource </param>
        /// <param name="dateExpiry"> The ISO 8601 date when the Session should expire </param>
        /// <param name="ttl"> When the session will expire </param>
        /// <param name="mode"> The Mode of the Session </param>
        /// <param name="status"> Session status </param>
        /// <param name="participants"> The Participant objects to include in the new session </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> CreateAsync(string pathServiceSid,
                                                                                     string uniqueName = null,
                                                                                     DateTime? dateExpiry = null,
                                                                                     int? ttl = null,
                                                                                     SessionResource.ModeEnum mode = null,
                                                                                     SessionResource.StatusEnum status = null,
                                                                                     List<object> participants = null,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new CreateSessionOptions(pathServiceSid){UniqueName = uniqueName, DateExpiry = dateExpiry, Ttl = ttl, Mode = mode, Status = status, Participants = participants};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Proxy,
                "/v1/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        /// <param name="options"> Delete Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static bool Delete(DeleteSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        /// <param name="options"> Delete Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSessionOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSessionOptions(pathServiceSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteSessionOptions(pathServiceSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateSessionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Proxy,
                "/v1/Services/" + options.PathServiceSid + "/Sessions/" + options.PathSid + "",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// Update a specific Session.
        /// </summary>
        /// <param name="options"> Update Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Update(UpdateSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Session.
        /// </summary>
        /// <param name="options"> Update Session parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> UpdateAsync(UpdateSessionOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to update the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="dateExpiry"> The ISO 8601 date when the Session should expire </param>
        /// <param name="ttl"> When the session will expire </param>
        /// <param name="status"> The new status of the resource </param>
        /// <param name="failOnParticipantConflict"> Opt-in to enable Proxy to return 400 on detected conflict on re-open
        ///                                 request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Session </returns>
        public static SessionResource Update(string pathServiceSid,
                                             string pathSid,
                                             DateTime? dateExpiry = null,
                                             int? ttl = null,
                                             SessionResource.StatusEnum status = null,
                                             bool? failOnParticipantConflict = null,
                                             ITwilioRestClient client = null)
        {
            var options = new UpdateSessionOptions(pathServiceSid, pathSid){DateExpiry = dateExpiry, Ttl = ttl, Status = status, FailOnParticipantConflict = failOnParticipantConflict};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update a specific Session.
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to update the resource from </param>
        /// <param name="pathSid"> The unique string that identifies the resource </param>
        /// <param name="dateExpiry"> The ISO 8601 date when the Session should expire </param>
        /// <param name="ttl"> When the session will expire </param>
        /// <param name="status"> The new status of the resource </param>
        /// <param name="failOnParticipantConflict"> Opt-in to enable Proxy to return 400 on detected conflict on re-open
        ///                                 request. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Session </returns>
        public static async System.Threading.Tasks.Task<SessionResource> UpdateAsync(string pathServiceSid,
                                                                                     string pathSid,
                                                                                     DateTime? dateExpiry = null,
                                                                                     int? ttl = null,
                                                                                     SessionResource.StatusEnum status = null,
                                                                                     bool? failOnParticipantConflict = null,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new UpdateSessionOptions(pathServiceSid, pathSid){DateExpiry = dateExpiry, Ttl = ttl, Status = status, FailOnParticipantConflict = failOnParticipantConflict};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a SessionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SessionResource object represented by the provided JSON </returns>
        public static SessionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SessionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The SID of the resource's parent Service
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The ISO 8601 date when the Session started
        /// </summary>
        [JsonProperty("date_started")]
        public DateTime? DateStarted { get; private set; }
        /// <summary>
        /// The ISO 8601 date when the Session ended
        /// </summary>
        [JsonProperty("date_ended")]
        public DateTime? DateEnded { get; private set; }
        /// <summary>
        /// The ISO 8601 date when the Session last had an interaction
        /// </summary>
        [JsonProperty("date_last_interaction")]
        public DateTime? DateLastInteraction { get; private set; }
        /// <summary>
        /// The ISO 8601 date when the Session should expire
        /// </summary>
        [JsonProperty("date_expiry")]
        public DateTime? DateExpiry { get; private set; }
        /// <summary>
        /// An application-defined string that uniquely identifies the resource
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// The status of the Session
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SessionResource.StatusEnum Status { get; private set; }
        /// <summary>
        /// The reason the Session ended
        /// </summary>
        [JsonProperty("closed_reason")]
        public string ClosedReason { get; private set; }
        /// <summary>
        /// When the session will expire
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; private set; }
        /// <summary>
        /// The Mode of the Session
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SessionResource.ModeEnum Mode { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The absolute URL of the Session resource
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The URLs of resources related to the Session
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private SessionResource()
        {

        }
    }

}
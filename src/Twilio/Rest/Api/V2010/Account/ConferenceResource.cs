/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Api.V2010.Account
{
    public class ConferenceResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Init = new StatusEnum("init");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ReasonConferenceEndedEnum : StringEnum
        {
            private ReasonConferenceEndedEnum(string value) : base(value) {}
            public ReasonConferenceEndedEnum() {}
            public static implicit operator ReasonConferenceEndedEnum(string value)
            {
                return new ReasonConferenceEndedEnum(value);
            }
            public static readonly ReasonConferenceEndedEnum ConferenceEndedViaApi = new ReasonConferenceEndedEnum("conference-ended-via-api");
            public static readonly ReasonConferenceEndedEnum ParticipantWithEndConferenceOnExitLeft = new ReasonConferenceEndedEnum("participant-with-end-conference-on-exit-left");
            public static readonly ReasonConferenceEndedEnum ParticipantWithEndConferenceOnExitKicked = new ReasonConferenceEndedEnum("participant-with-end-conference-on-exit-kicked");
            public static readonly ReasonConferenceEndedEnum LastParticipantKicked = new ReasonConferenceEndedEnum("last-participant-kicked");
            public static readonly ReasonConferenceEndedEnum LastParticipantLeft = new ReasonConferenceEndedEnum("last-participant-left");

        }
        public sealed class UpdateStatusEnum : StringEnum
        {
            private UpdateStatusEnum(string value) : base(value) {}
            public UpdateStatusEnum() {}
            public static implicit operator UpdateStatusEnum(string value)
            {
                return new UpdateStatusEnum(value);
            }
            public static readonly UpdateStatusEnum Completed = new UpdateStatusEnum("completed");

        }

        
        private static Request BuildFetchRequest(FetchConferenceOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Conferences/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch an instance of a conference </summary>
        /// <param name="options"> Fetch Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Fetch(FetchConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an instance of a conference </summary>
        /// <param name="options"> Fetch Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ConferenceResource> FetchAsync(FetchConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an instance of a conference </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Conference resource to fetch </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Fetch(
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchConferenceOptions(pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an instance of a conference </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Conference resource to fetch </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ConferenceResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchConferenceOptions(pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadConferenceOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Conferences.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of conferences belonging to the account used to make the request </summary>
        /// <param name="options"> Read Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ResourceSet<ConferenceResource> Read(ReadConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ConferenceResource>.FromJson("conferences", response.Content);
            return new ResourceSet<ConferenceResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of conferences belonging to the account used to make the request </summary>
        /// <param name="options"> Read Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConferenceResource>> ReadAsync(ReadConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ConferenceResource>.FromJson("conferences", response.Content);
            return new ResourceSet<ConferenceResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of conferences belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to read. </param>
        /// <param name="dateCreatedBefore"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateCreated"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateCreatedAfter"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateUpdatedBefore"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="dateUpdated"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="dateUpdatedAfter"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="friendlyName"> The string that identifies the Conference resources to read. </param>
        /// <param name="status"> The status of the resources to read. Can be: `init`, `in-progress`, or `completed`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ResourceSet<ConferenceResource> Read(
                                                     string pathAccountSid = null,
                                                     DateTime? dateCreatedBefore = null,
                                                     DateTime? dateCreated = null,
                                                     DateTime? dateCreatedAfter = null,
                                                     DateTime? dateUpdatedBefore = null,
                                                     DateTime? dateUpdated = null,
                                                     DateTime? dateUpdatedAfter = null,
                                                     string friendlyName = null,
                                                     ConferenceResource.StatusEnum status = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadConferenceOptions(){ PathAccountSid = pathAccountSid, DateCreatedBefore = dateCreatedBefore, DateCreated = dateCreated, DateCreatedAfter = dateCreatedAfter, DateUpdatedBefore = dateUpdatedBefore, DateUpdated = dateUpdated, DateUpdatedAfter = dateUpdatedAfter, FriendlyName = friendlyName, Status = status, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of conferences belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to read. </param>
        /// <param name="dateCreatedBefore"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateCreated"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateCreatedAfter"> Only include conferences that were created on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were created on this date. You can also specify an inequality, such as `DateCreated<=YYYY-MM-DD`, to read conferences that were created on or before midnight of this date, and `DateCreated>=YYYY-MM-DD` to read conferences that were created on or after midnight of this date. </param>
        /// <param name="dateUpdatedBefore"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="dateUpdated"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="dateUpdatedAfter"> Only include conferences that were last updated on this date. Specify a date as `YYYY-MM-DD` in UTC, for example: `2009-07-06`, to read only conferences that were last updated on this date. You can also specify an inequality, such as `DateUpdated<=YYYY-MM-DD`, to read conferences that were last updated on or before midnight of this date, and `DateUpdated>=YYYY-MM-DD` to read conferences that were last updated on or after midnight of this date. </param>
        /// <param name="friendlyName"> The string that identifies the Conference resources to read. </param>
        /// <param name="status"> The status of the resources to read. Can be: `init`, `in-progress`, or `completed`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConferenceResource>> ReadAsync(
                                                                                             string pathAccountSid = null,
                                                                                             DateTime? dateCreatedBefore = null,
                                                                                             DateTime? dateCreated = null,
                                                                                             DateTime? dateCreatedAfter = null,
                                                                                             DateTime? dateUpdatedBefore = null,
                                                                                             DateTime? dateUpdated = null,
                                                                                             DateTime? dateUpdatedAfter = null,
                                                                                             string friendlyName = null,
                                                                                             ConferenceResource.StatusEnum status = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadConferenceOptions(){ PathAccountSid = pathAccountSid, DateCreatedBefore = dateCreatedBefore, DateCreated = dateCreated, DateCreatedAfter = dateCreatedAfter, DateUpdatedBefore = dateUpdatedBefore, DateUpdated = dateUpdated, DateUpdatedAfter = dateUpdatedAfter, FriendlyName = friendlyName, Status = status, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ConferenceResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ConferenceResource> NextPage(Page<ConferenceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ConferenceResource> PreviousPage(Page<ConferenceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateConferenceOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Conferences/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Update(UpdateConferenceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Conference parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ConferenceResource> UpdateAsync(UpdateConferenceOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Conference resource to update </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to update. </param>
        /// <param name="status">  </param>
        /// <param name="announceUrl"> The URL we should call to announce something into the conference. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs. </param>
        /// <param name="announceMethod"> The HTTP method used to call `announce_url`. Can be: `GET` or `POST` and the default is `POST` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conference </returns>
        public static ConferenceResource Update(
                                          string pathSid,
                                          string pathAccountSid = null,
                                          ConferenceResource.UpdateStatusEnum status = null,
                                          Uri announceUrl = null,
                                          Twilio.Http.HttpMethod announceMethod = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateConferenceOptions(pathSid){ PathAccountSid = pathAccountSid, Status = status, AnnounceUrl = announceUrl, AnnounceMethod = announceMethod };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Conference resource to update </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Conference resource(s) to update. </param>
        /// <param name="status">  </param>
        /// <param name="announceUrl"> The URL we should call to announce something into the conference. The URL may return an MP3 file, a WAV file, or a TwiML document that contains `<Play>`, `<Say>`, `<Pause>`, or `<Redirect>` verbs. </param>
        /// <param name="announceMethod"> The HTTP method used to call `announce_url`. Can be: `GET` or `POST` and the default is `POST` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conference </returns>
        public static async System.Threading.Tasks.Task<ConferenceResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string pathAccountSid = null,
                                                                              ConferenceResource.UpdateStatusEnum status = null,
                                                                              Uri announceUrl = null,
                                                                              Twilio.Http.HttpMethod announceMethod = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateConferenceOptions(pathSid){ PathAccountSid = pathAccountSid, Status = status, AnnounceUrl = announceUrl, AnnounceMethod = announceMethod };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ConferenceResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConferenceResource object represented by the provided JSON </returns>
        public static ConferenceResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConferenceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Conference resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The date and time in UTC that this resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in UTC that this resource was last updated, specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The API version used to create this conference. </summary> 
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }

        ///<summary> A string that you assigned to describe this conference room. Maximum length is 128 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A string that represents the Twilio Region where the conference audio was mixed. May be `us1`, `ie1`,  `de1`, `sg1`, `br1`, `au1`, and `jp1`. Basic conference audio will always be mixed in `us1`. Global Conference audio will be mixed nearest to the majority of participants. </summary> 
        [JsonProperty("region")]
        public string Region { get; private set; }

        ///<summary> The unique, Twilio-provided string used to identify this Conference resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        
        [JsonProperty("status")]
        public ConferenceResource.StatusEnum Status { get; private set; }

        ///<summary> The URI of this resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        ///<summary> A list of related resources identified by their URIs relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }

        
        [JsonProperty("reason_conference_ended")]
        public ConferenceResource.ReasonConferenceEndedEnum ReasonConferenceEnded { get; private set; }

        ///<summary> The call SID that caused the conference to end. </summary> 
        [JsonProperty("call_sid_ending_conference")]
        public string CallSidEndingConference { get; private set; }



        private ConferenceResource() {

        }
    }
}


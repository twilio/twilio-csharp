/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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


namespace Twilio.Rest.Verify.V2.Service.Entity
{
    public class ChallengeResource : Resource
    {
    

    
        public sealed class ListOrdersEnum : StringEnum
        {
            private ListOrdersEnum(string value) : base(value) {}
            public ListOrdersEnum() {}
            public static implicit operator ListOrdersEnum(string value)
            {
                return new ListOrdersEnum(value);
            }
            public static readonly ListOrdersEnum Asc = new ListOrdersEnum("asc");
            public static readonly ListOrdersEnum Desc = new ListOrdersEnum("desc");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ChallengeStatusesEnum : StringEnum
        {
            private ChallengeStatusesEnum(string value) : base(value) {}
            public ChallengeStatusesEnum() {}
            public static implicit operator ChallengeStatusesEnum(string value)
            {
                return new ChallengeStatusesEnum(value);
            }
            public static readonly ChallengeStatusesEnum Pending = new ChallengeStatusesEnum("pending");
            public static readonly ChallengeStatusesEnum Expired = new ChallengeStatusesEnum("expired");
            public static readonly ChallengeStatusesEnum Approved = new ChallengeStatusesEnum("approved");
            public static readonly ChallengeStatusesEnum Denied = new ChallengeStatusesEnum("denied");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class FactorTypesEnum : StringEnum
        {
            private FactorTypesEnum(string value) : base(value) {}
            public FactorTypesEnum() {}
            public static implicit operator FactorTypesEnum(string value)
            {
                return new FactorTypesEnum(value);
            }
            public static readonly FactorTypesEnum Push = new FactorTypesEnum("push");
            public static readonly FactorTypesEnum Totp = new FactorTypesEnum("totp");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ChallengeReasonsEnum : StringEnum
        {
            private ChallengeReasonsEnum(string value) : base(value) {}
            public ChallengeReasonsEnum() {}
            public static implicit operator ChallengeReasonsEnum(string value)
            {
                return new ChallengeReasonsEnum(value);
            }
            public static readonly ChallengeReasonsEnum None = new ChallengeReasonsEnum("none");
            public static readonly ChallengeReasonsEnum NotNeeded = new ChallengeReasonsEnum("not_needed");
            public static readonly ChallengeReasonsEnum NotRequested = new ChallengeReasonsEnum("not_requested");

        }

        
        private static Request BuildCreateRequest(CreateChallengeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}/Challenges";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Challenge for the Factor </summary>
        /// <param name="options"> Create Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Create(CreateChallengeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Challenge for the Factor </summary>
        /// <param name="options"> Create Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ChallengeResource> CreateAsync(CreateChallengeOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Challenge for the Factor </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="factorSid"> The unique SID identifier of the Factor. </param>
        /// <param name="expirationDate"> The date-time when this Challenge expires, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. The default value is five (5) minutes after Challenge creation. The max value is sixty (60) minutes after creation. </param>
        /// <param name="detailsMessage"> Shown to the user when the push notification arrives. Required when `factor_type` is `push`. Can be up to 256 characters in length </param>
        /// <param name="detailsFields"> A list of objects that describe the Fields included in the Challenge. Each object contains the label and value of the field, the label can be up to 36 characters in length and the value can be up to 128 characters in length. Used when `factor_type` is `push`. There can be up to 20 details fields. </param>
        /// <param name="hiddenDetails"> Details provided to give context about the Challenge. Not shown to the end user. It must be a stringified JSON with only strings values eg. `{\\\"ip\\\": \\\"172.168.1.234\\\"}`. Can be up to 1024 characters in length </param>
        /// <param name="authPayload"> Optional payload used to verify the Challenge upon creation. Only used with a Factor of type `totp` to carry the TOTP code that needs to be verified. For `TOTP` this value must be between 3 and 8 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Create(
                                          string pathServiceSid,
                                          string pathIdentity,
                                          string factorSid,
                                          DateTime? expirationDate = null,
                                          string detailsMessage = null,
                                          List<object> detailsFields = null,
                                          object hiddenDetails = null,
                                          string authPayload = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateChallengeOptions(pathServiceSid, pathIdentity, factorSid){  ExpirationDate = expirationDate, DetailsMessage = detailsMessage, DetailsFields = detailsFields, HiddenDetails = hiddenDetails, AuthPayload = authPayload };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Challenge for the Factor </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="factorSid"> The unique SID identifier of the Factor. </param>
        /// <param name="expirationDate"> The date-time when this Challenge expires, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. The default value is five (5) minutes after Challenge creation. The max value is sixty (60) minutes after creation. </param>
        /// <param name="detailsMessage"> Shown to the user when the push notification arrives. Required when `factor_type` is `push`. Can be up to 256 characters in length </param>
        /// <param name="detailsFields"> A list of objects that describe the Fields included in the Challenge. Each object contains the label and value of the field, the label can be up to 36 characters in length and the value can be up to 128 characters in length. Used when `factor_type` is `push`. There can be up to 20 details fields. </param>
        /// <param name="hiddenDetails"> Details provided to give context about the Challenge. Not shown to the end user. It must be a stringified JSON with only strings values eg. `{\\\"ip\\\": \\\"172.168.1.234\\\"}`. Can be up to 1024 characters in length </param>
        /// <param name="authPayload"> Optional payload used to verify the Challenge upon creation. Only used with a Factor of type `totp` to carry the TOTP code that needs to be verified. For `TOTP` this value must be between 3 and 8 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ChallengeResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string pathIdentity,
                                                                                  string factorSid,
                                                                                  DateTime? expirationDate = null,
                                                                                  string detailsMessage = null,
                                                                                  List<object> detailsFields = null,
                                                                                  object hiddenDetails = null,
                                                                                  string authPayload = null,
                                                                                    ITwilioRestClient client = null, System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreateChallengeOptions(pathServiceSid, pathIdentity, factorSid){  ExpirationDate = expirationDate, DetailsMessage = detailsMessage, DetailsFields = detailsFields, HiddenDetails = hiddenDetails, AuthPayload = authPayload };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchChallengeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}/Challenges/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Challenge. </summary>
        /// <param name="options"> Fetch Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Fetch(FetchChallengeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Challenge. </summary>
        /// <param name="options"> Fetch Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ChallengeResource> FetchAsync(FetchChallengeOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Challenge. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenges. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Fetch(
                                         string pathServiceSid, 
                                         string pathIdentity, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchChallengeOptions(pathServiceSid, pathIdentity, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Challenge. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenges. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ChallengeResource> FetchAsync(string pathServiceSid, string pathIdentity, string pathSid, ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new FetchChallengeOptions(pathServiceSid, pathIdentity, pathSid){  };
            return await FetchAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildReadRequest(ReadChallengeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}/Challenges";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Challenges for a Factor. </summary>
        /// <param name="options"> Read Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ResourceSet<ChallengeResource> Read(ReadChallengeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ChallengeResource>.FromJson("challenges", response.Content);
            return new ResourceSet<ChallengeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Challenges for a Factor. </summary>
        /// <param name="options"> Read Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChallengeResource>> ReadAsync(ReadChallengeOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client), cancellationToken);

            var page = Page<ChallengeResource>.FromJson("challenges", response.Content);
            return new ResourceSet<ChallengeResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Challenges for a Factor. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="factorSid"> The unique SID identifier of the Factor. </param>
        /// <param name="status"> The Status of the Challenges to fetch. One of `pending`, `expired`, `approved` or `denied`. </param>
        /// <param name="order"> The desired sort order of the Challenges list. One of `asc` or `desc` for ascending and descending respectively. Defaults to `asc`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ResourceSet<ChallengeResource> Read(
                                                     string pathServiceSid,
                                                     string pathIdentity,
                                                     string factorSid = null,
                                                     ChallengeResource.ChallengeStatusesEnum status = null,
                                                     ChallengeResource.ListOrdersEnum order = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadChallengeOptions(pathServiceSid, pathIdentity){ FactorSid = factorSid, Status = status, Order = order, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Challenges for a Factor. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="factorSid"> The unique SID identifier of the Factor. </param>
        /// <param name="status"> The Status of the Challenges to fetch. One of `pending`, `expired`, `approved` or `denied`. </param>
        /// <param name="order"> The desired sort order of the Challenges list. One of `asc` or `desc` for ascending and descending respectively. Defaults to `asc`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChallengeResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             string pathIdentity,
                                                                                             string factorSid = null,
                                                                                             ChallengeResource.ChallengeStatusesEnum status = null,
                                                                                             ChallengeResource.ListOrdersEnum order = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new ReadChallengeOptions(pathServiceSid, pathIdentity){ FactorSid = factorSid, Status = status, Order = order, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client, cancellationToken);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ChallengeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ChallengeResource>.FromJson("challenges", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ChallengeResource> NextPage(Page<ChallengeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChallengeResource>.FromJson("challenges", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ChallengeResource> PreviousPage(Page<ChallengeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChallengeResource>.FromJson("challenges", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateChallengeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}/Challenges/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Verify a specific Challenge. </summary>
        /// <param name="options"> Update Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Update(UpdateChallengeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Verify a specific Challenge. </summary>
        /// <param name="options"> Update Challenge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ChallengeResource> UpdateAsync(UpdateChallengeOptions options, 
                                                                                                    ITwilioRestClient client = null,
                                                                                                    System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Verify a specific Challenge. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        /// <param name="authPayload"> The optional payload needed to verify the Challenge. E.g., a TOTP would use the numeric code. For `TOTP` this value must be between 3 and 8 characters long. For `Push` this value can be up to 5456 characters in length </param>
        /// <param name="metadata"> Custom metadata associated with the challenge. This is added by the Device/SDK directly to allow for the inclusion of device information. It must be a stringified JSON with only strings values eg. `{\\\"os\\\": \\\"Android\\\"}`. Can be up to 1024 characters in length. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Challenge </returns>
        public static ChallengeResource Update(
                                          string pathServiceSid,
                                          string pathIdentity,
                                          string pathSid,
                                          string authPayload = null,
                                          object metadata = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateChallengeOptions(pathServiceSid, pathIdentity, pathSid){ AuthPayload = authPayload, Metadata = metadata };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Verify a specific Challenge. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Challenge. </param>
        /// <param name="authPayload"> The optional payload needed to verify the Challenge. E.g., a TOTP would use the numeric code. For `TOTP` this value must be between 3 and 8 characters long. For `Push` this value can be up to 5456 characters in length </param>
        /// <param name="metadata"> Custom metadata associated with the challenge. This is added by the Device/SDK directly to allow for the inclusion of device information. It must be a stringified JSON with only strings values eg. `{\\\"os\\\": \\\"Android\\\"}`. Can be up to 1024 characters in length. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Challenge </returns>
        public static async System.Threading.Tasks.Task<ChallengeResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathIdentity,
                                                                              string pathSid,
                                                                              string authPayload = null,
                                                                              object metadata = null,
                                                                                ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new UpdateChallengeOptions(pathServiceSid, pathIdentity, pathSid){ AuthPayload = authPayload, Metadata = metadata };
            return await UpdateAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ChallengeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChallengeResource object represented by the provided JSON </returns>
        public static ChallengeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ChallengeResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies this Challenge. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique SID identifier of the Service. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The unique SID identifier of the Entity. </summary> 
        [JsonProperty("entity_sid")]
        public string EntitySid { get; private set; }

        ///<summary> Customer unique identity for the Entity owner of the Challenge. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        [JsonProperty("identity")]
        public string Identity { get; private set; }

        ///<summary> The unique SID identifier of the Factor. </summary> 
        [JsonProperty("factor_sid")]
        public string FactorSid { get; private set; }

        ///<summary> The date that this Challenge was created, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Challenge was updated, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The date that this Challenge was responded, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_responded")]
        public DateTime? DateResponded { get; private set; }

        ///<summary> The date-time when this Challenge expires, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. The default value is five (5) minutes after Challenge creation. The max value is sixty (60) minutes after creation. </summary> 
        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; private set; }

        
        [JsonProperty("status")]
        public ChallengeResource.ChallengeStatusesEnum Status { get; private set; }

        
        [JsonProperty("responded_reason")]
        public ChallengeResource.ChallengeReasonsEnum RespondedReason { get; private set; }

        ///<summary> Details provided to give context about the Challenge. Intended to be shown to the end user. </summary> 
        [JsonProperty("details")]
        public object Details { get; private set; }

        ///<summary> Details provided to give context about the Challenge. Intended to be hidden from the end user. It must be a stringified JSON with only strings values eg. `{\"ip\": \"172.168.1.234\"}` </summary> 
        [JsonProperty("hidden_details")]
        public object HiddenDetails { get; private set; }

        ///<summary> Custom metadata associated with the challenge. This is added by the Device/SDK directly to allow for the inclusion of device information. It must be a stringified JSON with only strings values eg. `{\"os\": \"Android\"}`. Can be up to 1024 characters in length. </summary> 
        [JsonProperty("metadata")]
        public object Metadata { get; private set; }

        
        [JsonProperty("factor_type")]
        public ChallengeResource.FactorTypesEnum FactorType { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains a dictionary of URL links to nested resources of this Challenge. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ChallengeResource() {

        }
    }
}


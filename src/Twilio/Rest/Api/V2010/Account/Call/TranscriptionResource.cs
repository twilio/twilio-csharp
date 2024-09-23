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


namespace Twilio.Rest.Api.V2010.Account.Call
{
    public class TranscriptionResource : Resource
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
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Stopped = new StatusEnum("stopped");

        }
        public sealed class TrackEnum : StringEnum
        {
            private TrackEnum(string value) : base(value) {}
            public TrackEnum() {}
            public static implicit operator TrackEnum(string value)
            {
                return new TrackEnum(value);
            }
            public static readonly TrackEnum InboundTrack = new TrackEnum("inbound_track");
            public static readonly TrackEnum OutboundTrack = new TrackEnum("outbound_track");
            public static readonly TrackEnum BothTracks = new TrackEnum("both_tracks");

        }
        public sealed class UpdateStatusEnum : StringEnum
        {
            private UpdateStatusEnum(string value) : base(value) {}
            public UpdateStatusEnum() {}
            public static implicit operator UpdateStatusEnum(string value)
            {
                return new UpdateStatusEnum(value);
            }
            public static readonly UpdateStatusEnum Stopped = new UpdateStatusEnum("stopped");

        }

        
        private static Request BuildCreateRequest(CreateTranscriptionOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Transcriptions.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a Transcription </summary>
        /// <param name="options"> Create Transcription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Transcription </returns>
        public static TranscriptionResource Create(CreateTranscriptionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a Transcription </summary>
        /// <param name="options"> Create Transcription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Transcription </returns>
        public static async System.Threading.Tasks.Task<TranscriptionResource> CreateAsync(CreateTranscriptionOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a Transcription </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Transcription resource is associated with. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Transcription resource. </param>
        /// <param name="name"> The user-specified name of this Transcription, if one was given when the Transcription was created. This may be used to stop the Transcription. </param>
        /// <param name="track">  </param>
        /// <param name="statusCallbackUrl"> Absolute URL of the status callback. </param>
        /// <param name="statusCallbackMethod"> The http method for the status_callback (one of GET, POST). </param>
        /// <param name="inboundTrackLabel"> Friendly name given to the Inbound Track </param>
        /// <param name="outboundTrackLabel"> Friendly name given to the Outbound Track </param>
        /// <param name="partialResults"> Indicates if partial results are going to be sent to the customer </param>
        /// <param name="languageCode"> Language code used by the transcription engine, specified in [BCP-47](https://www.rfc-editor.org/rfc/bcp/bcp47.txt) format </param>
        /// <param name="transcriptionEngine"> Definition of the transcription engine to be used, among those supported by Twilio </param>
        /// <param name="profanityFilter"> indicates if the server will attempt to filter out profanities, replacing all but the initial character in each filtered word with asterisks </param>
        /// <param name="speechModel"> Recognition model used by the transcription engine, among those supported by the provider </param>
        /// <param name="hints"> A Phrase contains words and phrase \\\"hints\\\" so that the speech recognition engine is more likely to recognize them. </param>
        /// <param name="enableAutomaticPunctuation"> The provider will add punctuation to recognition result </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Transcription </returns>
        public static TranscriptionResource Create(
                                          string pathCallSid,
                                          string pathAccountSid = null,
                                          string name = null,
                                          TranscriptionResource.TrackEnum track = null,
                                          Uri statusCallbackUrl = null,
                                          Twilio.Http.HttpMethod statusCallbackMethod = null,
                                          string inboundTrackLabel = null,
                                          string outboundTrackLabel = null,
                                          bool? partialResults = null,
                                          string languageCode = null,
                                          string transcriptionEngine = null,
                                          bool? profanityFilter = null,
                                          string speechModel = null,
                                          string hints = null,
                                          bool? enableAutomaticPunctuation = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateTranscriptionOptions(pathCallSid){  PathAccountSid = pathAccountSid, Name = name, Track = track, StatusCallbackUrl = statusCallbackUrl, StatusCallbackMethod = statusCallbackMethod, InboundTrackLabel = inboundTrackLabel, OutboundTrackLabel = outboundTrackLabel, PartialResults = partialResults, LanguageCode = languageCode, TranscriptionEngine = transcriptionEngine, ProfanityFilter = profanityFilter, SpeechModel = speechModel, Hints = hints, EnableAutomaticPunctuation = enableAutomaticPunctuation };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a Transcription </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Transcription resource is associated with. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Transcription resource. </param>
        /// <param name="name"> The user-specified name of this Transcription, if one was given when the Transcription was created. This may be used to stop the Transcription. </param>
        /// <param name="track">  </param>
        /// <param name="statusCallbackUrl"> Absolute URL of the status callback. </param>
        /// <param name="statusCallbackMethod"> The http method for the status_callback (one of GET, POST). </param>
        /// <param name="inboundTrackLabel"> Friendly name given to the Inbound Track </param>
        /// <param name="outboundTrackLabel"> Friendly name given to the Outbound Track </param>
        /// <param name="partialResults"> Indicates if partial results are going to be sent to the customer </param>
        /// <param name="languageCode"> Language code used by the transcription engine, specified in [BCP-47](https://www.rfc-editor.org/rfc/bcp/bcp47.txt) format </param>
        /// <param name="transcriptionEngine"> Definition of the transcription engine to be used, among those supported by Twilio </param>
        /// <param name="profanityFilter"> indicates if the server will attempt to filter out profanities, replacing all but the initial character in each filtered word with asterisks </param>
        /// <param name="speechModel"> Recognition model used by the transcription engine, among those supported by the provider </param>
        /// <param name="hints"> A Phrase contains words and phrase \\\"hints\\\" so that the speech recognition engine is more likely to recognize them. </param>
        /// <param name="enableAutomaticPunctuation"> The provider will add punctuation to recognition result </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Transcription </returns>
        public static async System.Threading.Tasks.Task<TranscriptionResource> CreateAsync(
                                                                                  string pathCallSid,
                                                                                  string pathAccountSid = null,
                                                                                  string name = null,
                                                                                  TranscriptionResource.TrackEnum track = null,
                                                                                  Uri statusCallbackUrl = null,
                                                                                  Twilio.Http.HttpMethod statusCallbackMethod = null,
                                                                                  string inboundTrackLabel = null,
                                                                                  string outboundTrackLabel = null,
                                                                                  bool? partialResults = null,
                                                                                  string languageCode = null,
                                                                                  string transcriptionEngine = null,
                                                                                  bool? profanityFilter = null,
                                                                                  string speechModel = null,
                                                                                  string hints = null,
                                                                                  bool? enableAutomaticPunctuation = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateTranscriptionOptions(pathCallSid){  PathAccountSid = pathAccountSid, Name = name, Track = track, StatusCallbackUrl = statusCallbackUrl, StatusCallbackMethod = statusCallbackMethod, InboundTrackLabel = inboundTrackLabel, OutboundTrackLabel = outboundTrackLabel, PartialResults = partialResults, LanguageCode = languageCode, TranscriptionEngine = transcriptionEngine, ProfanityFilter = profanityFilter, SpeechModel = speechModel, Hints = hints, EnableAutomaticPunctuation = enableAutomaticPunctuation };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateTranscriptionOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Transcriptions/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);
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

        /// <summary> Stop a Transcription using either the SID of the Transcription resource or the `name` used when creating the resource </summary>
        /// <param name="options"> Update Transcription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Transcription </returns>
        public static TranscriptionResource Update(UpdateTranscriptionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Stop a Transcription using either the SID of the Transcription resource or the `name` used when creating the resource </summary>
        /// <param name="options"> Update Transcription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Transcription </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<TranscriptionResource> UpdateAsync(UpdateTranscriptionOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Stop a Transcription using either the SID of the Transcription resource or the `name` used when creating the resource </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Transcription resource is associated with. </param>
        /// <param name="pathSid"> The SID of the Transcription resource, or the `name` used when creating the resource </param>
        /// <param name="status">  </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Transcription resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Transcription </returns>
        public static TranscriptionResource Update(
                                          string pathCallSid,
                                          string pathSid,
                                          TranscriptionResource.UpdateStatusEnum status,
                                          string pathAccountSid = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateTranscriptionOptions(pathCallSid, pathSid, status){ PathAccountSid = pathAccountSid };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Stop a Transcription using either the SID of the Transcription resource or the `name` used when creating the resource </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Transcription resource is associated with. </param>
        /// <param name="pathSid"> The SID of the Transcription resource, or the `name` used when creating the resource </param>
        /// <param name="status">  </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Transcription resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Transcription </returns>
        public static async System.Threading.Tasks.Task<TranscriptionResource> UpdateAsync(
                                                                              string pathCallSid,
                                                                              string pathSid,
                                                                              TranscriptionResource.UpdateStatusEnum status,
                                                                              string pathAccountSid = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateTranscriptionOptions(pathCallSid, pathSid, status){ PathAccountSid = pathAccountSid };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TranscriptionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TranscriptionResource object represented by the provided JSON </returns>
        public static TranscriptionResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TranscriptionResource>(json);
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

    
        ///<summary> The SID of the Transcription resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this Transcription resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Transcription resource is associated with. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> The user-specified name of this Transcription, if one was given when the Transcription was created. This may be used to stop the Transcription. </summary> 
        [JsonProperty("name")]
        public string Name { get; private set; }

        
        [JsonProperty("status")]
        public TranscriptionResource.StatusEnum Status { get; private set; }

        ///<summary> The date and time in GMT that this resource was last updated, specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The uri </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private TranscriptionResource() {

        }
    }
}


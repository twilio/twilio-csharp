/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// RecordingResource
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

namespace Twilio.Rest.Trunking.V1.Trunk
{

    public class RecordingResource : Resource
    {
        public sealed class RecordingModeEnum : StringEnum
        {
            private RecordingModeEnum(string value) : base(value) {}
            public RecordingModeEnum() {}
            public static implicit operator RecordingModeEnum(string value)
            {
                return new RecordingModeEnum(value);
            }

            public static readonly RecordingModeEnum DoNotRecord = new RecordingModeEnum("do-not-record");
            public static readonly RecordingModeEnum RecordFromRinging = new RecordingModeEnum("record-from-ringing");
            public static readonly RecordingModeEnum RecordFromAnswer = new RecordingModeEnum("record-from-answer");
            public static readonly RecordingModeEnum RecordFromRingingDual = new RecordingModeEnum("record-from-ringing-dual");
            public static readonly RecordingModeEnum RecordFromAnswerDual = new RecordingModeEnum("record-from-answer-dual");
        }

        public sealed class RecordingTrimEnum : StringEnum
        {
            private RecordingTrimEnum(string value) : base(value) {}
            public RecordingTrimEnum() {}
            public static implicit operator RecordingTrimEnum(string value)
            {
                return new RecordingTrimEnum(value);
            }

            public static readonly RecordingTrimEnum TrimSilence = new RecordingTrimEnum("trim-silence");
            public static readonly RecordingTrimEnum DoNotTrim = new RecordingTrimEnum("do-not-trim");
        }

        private static Request BuildFetchRequest(FetchRecordingOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.PathTrunkSid + "/Recording",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Recording parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Recording </returns>
        public static RecordingResource Fetch(FetchRecordingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Recording parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Recording </returns>
        public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(FetchRecordingOptions options,
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
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the recording settings. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Recording </returns>
        public static RecordingResource Fetch(string pathTrunkSid, ITwilioRestClient client = null)
        {
            var options = new FetchRecordingOptions(pathTrunkSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the recording settings. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Recording </returns>
        public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(string pathTrunkSid,
                                                                                      ITwilioRestClient client = null)
        {
            var options = new FetchRecordingOptions(pathTrunkSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateRecordingOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.PathTrunkSid + "/Recording",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Recording parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Recording </returns>
        public static RecordingResource Update(UpdateRecordingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Recording parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Recording </returns>
        public static async System.Threading.Tasks.Task<RecordingResource> UpdateAsync(UpdateRecordingOptions options,
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
        /// <param name="pathTrunkSid"> The SID of the Trunk. </param>
        /// <param name="mode"> The recording mode for the trunk. </param>
        /// <param name="trim"> The recording trim setting for the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Recording </returns>
        public static RecordingResource Update(string pathTrunkSid,
                                               RecordingResource.RecordingModeEnum mode = null,
                                               RecordingResource.RecordingTrimEnum trim = null,
                                               ITwilioRestClient client = null)
        {
            var options = new UpdateRecordingOptions(pathTrunkSid){Mode = mode, Trim = trim};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk. </param>
        /// <param name="mode"> The recording mode for the trunk. </param>
        /// <param name="trim"> The recording trim setting for the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Recording </returns>
        public static async System.Threading.Tasks.Task<RecordingResource> UpdateAsync(string pathTrunkSid,
                                                                                       RecordingResource.RecordingModeEnum mode = null,
                                                                                       RecordingResource.RecordingTrimEnum trim = null,
                                                                                       ITwilioRestClient client = null)
        {
            var options = new UpdateRecordingOptions(pathTrunkSid){Mode = mode, Trim = trim};
            return await UpdateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns>
        public static RecordingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The recording mode for the trunk.
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.RecordingModeEnum Mode { get; private set; }
        /// <summary>
        /// The recording trim setting for the trunk.
        /// </summary>
        [JsonProperty("trim")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.RecordingTrimEnum Trim { get; private set; }

        private RecordingResource()
        {

        }
    }

}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Connecting = new StatusEnum("connecting");
            public static readonly StatusEnum Ringing = new StatusEnum("ringing");
            public static readonly StatusEnum Connected = new StatusEnum("connected");
            public static readonly StatusEnum Complete = new StatusEnum("complete");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
        }
    
        public sealed class BeepEnum : StringEnum 
        {
            private BeepEnum(string value) : base(value) {}
            public BeepEnum() {}
        
            public static readonly BeepEnum True = new BeepEnum("true");
            public static readonly BeepEnum False = new BeepEnum("false");
            public static readonly BeepEnum Onenter = new BeepEnum("onEnter");
            public static readonly BeepEnum Onexit = new BeepEnum("onExit");
        }
    
        public sealed class ConferenceRecordEnum : StringEnum 
        {
            private ConferenceRecordEnum(string value) : base(value) {}
            public ConferenceRecordEnum() {}
        
            public static readonly ConferenceRecordEnum DoNotRecord = new ConferenceRecordEnum("do-not-record");
            public static readonly ConferenceRecordEnum RecordFromStart = new ConferenceRecordEnum("record-from-start");
        }
    
        private static Request BuildFetchRequest(FetchParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Conferences/" + options.ConferenceSid + "/Participants/" + options.CallSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of a participant
        /// </summary>
        public static ParticipantResource Fetch(FetchParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(FetchParticipantOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of a participant
        /// </summary>
        public static ParticipantResource Fetch(string conferenceSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(conferenceSid, callSid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(string conferenceSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(conferenceSid, callSid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Conferences/" + options.ConferenceSid + "/Participants/" + options.CallSid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update the properties of this participant
        /// </summary>
        public static ParticipantResource Update(UpdateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> UpdateAsync(UpdateParticipantOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Update the properties of this participant
        /// </summary>
        public static ParticipantResource Update(string conferenceSid, string callSid, string accountSid = null, bool? muted = null, bool? hold = null, Uri holdUrl = null, Twilio.Http.HttpMethod holdMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateParticipantOptions(conferenceSid, callSid){AccountSid = accountSid, Muted = muted, Hold = hold, HoldUrl = holdUrl, HoldMethod = holdMethod};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> UpdateAsync(string conferenceSid, string callSid, string accountSid = null, bool? muted = null, bool? hold = null, Uri holdUrl = null, Twilio.Http.HttpMethod holdMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateParticipantOptions(conferenceSid, callSid){AccountSid = accountSid, Muted = muted, Hold = hold, HoldUrl = holdUrl, HoldMethod = holdMethod};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Conferences/" + options.ConferenceSid + "/Participants.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static ParticipantResource Create(CreateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(CreateParticipantOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static ParticipantResource Create(string conferenceSid, Types.PhoneNumber from, Types.PhoneNumber to, string accountSid = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, List<string> statusCallbackEvent = null, int? timeout = null, bool? record = null, bool? muted = null, ParticipantResource.BeepEnum beep = null, bool? startConferenceOnEnter = null, bool? endConferenceOnExit = null, Uri waitUrl = null, Twilio.Http.HttpMethod waitMethod = null, bool? earlyMedia = null, int? maxParticipants = null, ParticipantResource.ConferenceRecordEnum conferenceRecord = null, string conferenceTrim = null, Uri conferenceStatusCallback = null, Twilio.Http.HttpMethod conferenceStatusCallbackMethod = null, List<string> conferenceStatusCallbackEvent = null, ITwilioRestClient client = null)
        {
            var options = new CreateParticipantOptions(conferenceSid, from, to){AccountSid = accountSid, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, StatusCallbackEvent = statusCallbackEvent, Timeout = timeout, Record = record, Muted = muted, Beep = beep, StartConferenceOnEnter = startConferenceOnEnter, EndConferenceOnExit = endConferenceOnExit, WaitUrl = waitUrl, WaitMethod = waitMethod, EarlyMedia = earlyMedia, MaxParticipants = maxParticipants, ConferenceRecord = conferenceRecord, ConferenceTrim = conferenceTrim, ConferenceStatusCallback = conferenceStatusCallback, ConferenceStatusCallbackMethod = conferenceStatusCallbackMethod, ConferenceStatusCallbackEvent = conferenceStatusCallbackEvent};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(string conferenceSid, Types.PhoneNumber from, Types.PhoneNumber to, string accountSid = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, List<string> statusCallbackEvent = null, int? timeout = null, bool? record = null, bool? muted = null, ParticipantResource.BeepEnum beep = null, bool? startConferenceOnEnter = null, bool? endConferenceOnExit = null, Uri waitUrl = null, Twilio.Http.HttpMethod waitMethod = null, bool? earlyMedia = null, int? maxParticipants = null, ParticipantResource.ConferenceRecordEnum conferenceRecord = null, string conferenceTrim = null, Uri conferenceStatusCallback = null, Twilio.Http.HttpMethod conferenceStatusCallbackMethod = null, List<string> conferenceStatusCallbackEvent = null, ITwilioRestClient client = null)
        {
            var options = new CreateParticipantOptions(conferenceSid, from, to){AccountSid = accountSid, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod, StatusCallbackEvent = statusCallbackEvent, Timeout = timeout, Record = record, Muted = muted, Beep = beep, StartConferenceOnEnter = startConferenceOnEnter, EndConferenceOnExit = endConferenceOnExit, WaitUrl = waitUrl, WaitMethod = waitMethod, EarlyMedia = earlyMedia, MaxParticipants = maxParticipants, ConferenceRecord = conferenceRecord, ConferenceTrim = conferenceTrim, ConferenceStatusCallback = conferenceStatusCallback, ConferenceStatusCallbackMethod = conferenceStatusCallbackMethod, ConferenceStatusCallbackEvent = conferenceStatusCallbackEvent};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Conferences/" + options.ConferenceSid + "/Participants/" + options.CallSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Kick a participant from a given conference
        /// </summary>
        public static bool Delete(DeleteParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteParticipantOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Kick a participant from a given conference
        /// </summary>
        public static bool Delete(string conferenceSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(conferenceSid, callSid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string conferenceSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(conferenceSid, callSid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadParticipantOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Conferences/" + options.ConferenceSid + "/Participants.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of participants belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ParticipantResource> Read(ReadParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(ReadParticipantOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of participants belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<ParticipantResource> Read(string conferenceSid, string accountSid = null, bool? muted = null, bool? hold = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(conferenceSid){AccountSid = accountSid, Muted = muted, Hold = hold, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(string conferenceSid, string accountSid = null, bool? muted = null, bool? hold = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(conferenceSid){AccountSid = accountSid, Muted = muted, Hold = hold, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns> 
        public static ParticipantResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
        [JsonProperty("conference_sid")]
        public string ConferenceSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("end_conference_on_exit")]
        public bool? EndConferenceOnExit { get; private set; }
        [JsonProperty("muted")]
        public bool? Muted { get; private set; }
        [JsonProperty("hold")]
        public bool? Hold { get; private set; }
        [JsonProperty("start_conference_on_enter")]
        public bool? StartConferenceOnEnter { get; private set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ParticipantResource.StatusEnum Status { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private ParticipantResource()
        {
        
        }
    }

}
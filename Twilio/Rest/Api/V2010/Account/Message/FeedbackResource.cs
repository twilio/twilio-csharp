using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class FeedbackResource : Resource 
    {
        public sealed class OutcomeEnum : StringEnum 
        {
            private OutcomeEnum(string value) : base(value) {}
            public OutcomeEnum() {}
        
            public static readonly OutcomeEnum Confirmed = new OutcomeEnum("confirmed");
            public static readonly OutcomeEnum Umconfirmed = new OutcomeEnum("umconfirmed");
        }
    
        private static Request BuildCreateRequest(CreateFeedbackOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.MessageSid + "/Feedback.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static FeedbackResource Create(CreateFeedbackOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<FeedbackResource> CreateAsync(CreateFeedbackOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static FeedbackResource Create(string messageSid, string accountSid = null, FeedbackResource.OutcomeEnum outcome = null, ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackOptions(messageSid){AccountSid = accountSid, Outcome = outcome};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<FeedbackResource> CreateAsync(string messageSid, string accountSid = null, FeedbackResource.OutcomeEnum outcome = null, ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackOptions(messageSid){AccountSid = accountSid, Outcome = outcome};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns> 
        public static FeedbackResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("message_sid")]
        public string MessageSid { get; private set; }
        [JsonProperty("outcome")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedbackResource.OutcomeEnum Outcome { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private FeedbackResource()
        {
        
        }
    }

}
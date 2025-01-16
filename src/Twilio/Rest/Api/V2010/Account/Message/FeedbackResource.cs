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


namespace Twilio.Rest.Api.V2010.Account.Message
{
    public class FeedbackResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class OutcomeEnum : StringEnum
        {
            private OutcomeEnum(string value) : base(value) {}
            public OutcomeEnum() {}
            public static implicit operator OutcomeEnum(string value)
            {
                return new OutcomeEnum(value);
            }
            public static readonly OutcomeEnum Confirmed = new OutcomeEnum("confirmed");
            public static readonly OutcomeEnum Unconfirmed = new OutcomeEnum("unconfirmed");

        }

        
        private static Request BuildCreateRequest(CreateFeedbackOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Messages/{MessageSid}/Feedback.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathMessageSid = options.PathMessageSid;
            path = path.Replace("{"+"MessageSid"+"}", PathMessageSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create Message Feedback to confirm a tracked user action was performed by the recipient of the associated Message </summary>
        /// <param name="options"> Create Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Create(CreateFeedbackOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create Message Feedback to confirm a tracked user action was performed by the recipient of the associated Message </summary>
        /// <param name="options"> Create Feedback parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        public static async System.Threading.Tasks.Task<FeedbackResource> CreateAsync(CreateFeedbackOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create Message Feedback to confirm a tracked user action was performed by the recipient of the associated Message </summary>
        /// <param name="pathMessageSid"> The SID of the Message resource for which to create MessageFeedback. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) associated with the Message resource for which to create MessageFeedback. </param>
        /// <param name="outcome">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Feedback </returns>
        public static FeedbackResource Create(
                                          string pathMessageSid,
                                          string pathAccountSid = null,
                                          FeedbackResource.OutcomeEnum outcome = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackOptions(pathMessageSid){  PathAccountSid = pathAccountSid, Outcome = outcome };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create Message Feedback to confirm a tracked user action was performed by the recipient of the associated Message </summary>
        /// <param name="pathMessageSid"> The SID of the Message resource for which to create MessageFeedback. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) associated with the Message resource for which to create MessageFeedback. </param>
        /// <param name="outcome">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Feedback </returns>
        public static async System.Threading.Tasks.Task<FeedbackResource> CreateAsync(
                                                                                  string pathMessageSid,
                                                                                  string pathAccountSid = null,
                                                                                  FeedbackResource.OutcomeEnum outcome = null,
                                                                                    ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreateFeedbackOptions(pathMessageSid){  PathAccountSid = pathAccountSid, Outcome = outcome };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns>
        public static FeedbackResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) associated with this MessageFeedback resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the Message resource associated with this MessageFeedback resource. </summary> 
        [JsonProperty("message_sid")]
        public string MessageSid { get; private set; }

        
        [JsonProperty("outcome")]
        public FeedbackResource.OutcomeEnum Outcome { get; private set; }

        ///<summary> The date and time in GMT when this MessageFeedback resource was created, specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when this MessageFeedback resource was last updated, specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URI of the resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private FeedbackResource() {

        }
    }
}


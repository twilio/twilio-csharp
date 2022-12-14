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


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using System.Linq;



namespace Twilio.Rest.Api.V2010.Account
{

    /// <summary> Send a message from the account used to make the request </summary>
    public class CreateMessageOptions : IOptions<MessageResource>
    {
        
        ///<summary> The destination phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format for SMS/MMS or [Channel user address](https://www.twilio.com/docs/sms/channels#channel-addresses) for other 3rd-party channels. </summary> 
        public Types.PhoneNumber To { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The URL we should call using the `status_callback_method` to send status information to your application. If specified, we POST these message status changes to the URL: `queued`, `failed`, `sent`, `delivered`, or `undelivered`. Twilio will POST its [standard request parameters](https://www.twilio.com/docs/sms/twiml#request-parameters) as well as some additional parameters including `MessageSid`, `MessageStatus`, and `ErrorCode`. If you include this parameter with the `messaging_service_sid`, we use this URL instead of the Status Callback URL of the [Messaging Service](https://www.twilio.com/docs/sms/services/api). URLs must contain a valid hostname and underscores are not allowed. </summary> 
        public Uri StatusCallback { get; set; }

        ///<summary> The SID of the application that should receive message status. We POST a `message_sid` parameter and a `message_status` parameter with a value of `sent` or `failed` to the [application](https://www.twilio.com/docs/usage/api/applications)'s `message_status_callback`. If a `status_callback` parameter is also passed, it will be ignored and the application's `message_status_callback` parameter will be used. </summary> 
        public string ApplicationSid { get; set; }

        ///<summary> The maximum total price in US dollars that you will pay for the message to be delivered. Can be a decimal value that has up to 4 decimal places. All messages are queued for delivery and the message cost is checked before the message is sent. If the cost exceeds `max_price`, the message will fail and a status of `Failed` is sent to the status callback. If `MaxPrice` is not set, the message cost is not checked. </summary> 
        public decimal? MaxPrice { get; set; }

        ///<summary> Whether to confirm delivery of the message. Set this value to `true` if you are sending messages that have a trackable user action and you intend to confirm delivery of the message using the [Message Feedback API](https://www.twilio.com/docs/sms/api/message-feedback-resource). This parameter is `false` by default. </summary> 
        public bool? ProvideFeedback { get; set; }

        ///<summary> Total number of attempts made ( including this ) to send out the message regardless of the provider used </summary> 
        public int? Attempt { get; set; }

        ///<summary> How long in seconds the message can remain in our outgoing message queue. After this period elapses, the message fails and we call your status callback. Can be between 1 and the default value of 14,400 seconds. After a message has been accepted by a carrier, however, we cannot guarantee that the message will not be queued after this period. We recommend that this value be at least 5 seconds. </summary> 
        public int? ValidityPeriod { get; set; }

        ///<summary> Reserved </summary> 
        public bool? ForceDelivery { get; set; }

        
        public MessageResource.ContentRetentionEnum ContentRetention { get; set; }

        
        public MessageResource.AddressRetentionEnum AddressRetention { get; set; }

        ///<summary> Whether to detect Unicode characters that have a similar GSM-7 character and replace them. Can be: `true` or `false`. </summary> 
        public bool? SmartEncoded { get; set; }

        ///<summary> Rich actions for Channels Messages. </summary> 
        public List<string> PersistentAction { get; set; }

        ///<summary> Determines the usage of Click Tracking. Setting it to `true` will instruct Twilio to replace all links in the Message with a shortened version based on the associated Domain Sid and track clicks on them. If this parameter is not set on an API call, we will use the value set on the Messaging Service. If this parameter is not set and the value is not configured on the Messaging Service used this will default to `false`. </summary> 
        public bool? ShortenUrls { get; set; }

        
        public MessageResource.ScheduleTypeEnum ScheduleType { get; set; }

        ///<summary> The time that Twilio will send the message. Must be in ISO 8601 format. </summary> 
        public DateTime? SendAt { get; set; }

        ///<summary> If set to True, Twilio will deliver the message as a single MMS message, regardless of the presence of media. </summary> 
        public bool? SendAsMms { get; set; }

        ///<summary> The SID of the Content object returned at Content API content create time (https://www.twilio.com/docs/content-api/create-and-send-your-first-content-api-template#create-a-template). If this parameter is not specified, then the Content API will not be utilized. </summary> 
        public string ContentSid { get; set; }

        ///<summary> Key-value pairs of variable names to substitution values, used alongside a content_sid. If not specified, Content API will default to the default variables defined at create time. </summary> 
        public string ContentVariables { get; set; }

        ///<summary> A Twilio phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, an [alphanumeric sender ID](https://www.twilio.com/docs/sms/send-messages#use-an-alphanumeric-sender-id), or a [Channel Endpoint address](https://www.twilio.com/docs/sms/channels#channel-addresses) that is enabled for the type of message you want to send. Phone numbers or [short codes](https://www.twilio.com/docs/sms/api/short-code) purchased from Twilio also work here. You cannot, for example, spoof messages from a private cell phone number. If you are using `messaging_service_sid`, this parameter must be empty. </summary> 
        public Types.PhoneNumber From { get; set; }

        ///<summary> The SID of the [Messaging Service](https://www.twilio.com/docs/sms/services#send-a-message-with-copilot) you want to associate with the Message. Set this parameter to use the [Messaging Service Settings and Copilot Features](https://www.twilio.com/console/sms/services) you have configured and leave the `from` parameter empty. When only this parameter is set, Twilio will use your enabled Copilot Features to select the `from` phone number for delivery. </summary> 
        public string MessagingServiceSid { get; set; }

        ///<summary> The text of the message you want to send. Can be up to 1,600 characters in length. </summary> 
        public string Body { get; set; }

        ///<summary> The URL of the media to send with the message. The media can be of type `gif`, `png`, and `jpeg` and will be formatted correctly on the recipient's device. The media size limit is 5MB for supported file types (JPEG, PNG, GIF) and 500KB for [other types](https://www.twilio.com/docs/sms/accepted-mime-types) of accepted media. To send more than one image in the message body, provide multiple `media_url` parameters in the POST request. You can include up to 10 `media_url` parameters per message. You can send images in an SMS message in only the US and Canada. </summary> 
        public List<Uri> MediaUrl { get; set; }


        /// <summary> Construct a new CreateMessageOptions </summary>
        /// <param name="to"> The destination phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format for SMS/MMS or [Channel user address](https://www.twilio.com/docs/sms/channels#channel-addresses) for other 3rd-party channels. </param>
        public CreateMessageOptions(Types.PhoneNumber to)
        {
            To = to;
            PersistentAction = new List<string>();
            MediaUrl = new List<Uri>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }
            if (ApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ApplicationSid", ApplicationSid));
            }
            if (MaxPrice != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxPrice", MaxPrice.Value.ToString()));
            }
            if (ProvideFeedback != null)
            {
                p.Add(new KeyValuePair<string, string>("ProvideFeedback", ProvideFeedback.Value.ToString().ToLower()));
            }
            if (Attempt != null)
            {
                p.Add(new KeyValuePair<string, string>("Attempt", Attempt.ToString()));
            }
            if (ValidityPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("ValidityPeriod", ValidityPeriod.ToString()));
            }
            if (ForceDelivery != null)
            {
                p.Add(new KeyValuePair<string, string>("ForceDelivery", ForceDelivery.Value.ToString().ToLower()));
            }
            if (ContentRetention != null)
            {
                p.Add(new KeyValuePair<string, string>("ContentRetention", ContentRetention.ToString()));
            }
            if (AddressRetention != null)
            {
                p.Add(new KeyValuePair<string, string>("AddressRetention", AddressRetention.ToString()));
            }
            if (SmartEncoded != null)
            {
                p.Add(new KeyValuePair<string, string>("SmartEncoded", SmartEncoded.Value.ToString().ToLower()));
            }
            if (PersistentAction != null)
            {
                p.AddRange(PersistentAction.Select(PersistentAction => new KeyValuePair<string, string>("PersistentAction", PersistentAction)));
            }
            if (ShortenUrls != null)
            {
                p.Add(new KeyValuePair<string, string>("ShortenUrls", ShortenUrls.Value.ToString().ToLower()));
            }
            if (ScheduleType != null)
            {
                p.Add(new KeyValuePair<string, string>("ScheduleType", ScheduleType.ToString()));
            }
            if (SendAt != null)
            {
                p.Add(new KeyValuePair<string, string>("SendAt", Serializers.DateTimeIso8601(SendAt)));
            }
            if (SendAsMms != null)
            {
                p.Add(new KeyValuePair<string, string>("SendAsMms", SendAsMms.Value.ToString().ToLower()));
            }
            if (ContentSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ContentSid", ContentSid));
            }
            if (ContentVariables != null)
            {
                p.Add(new KeyValuePair<string, string>("ContentVariables", ContentVariables));
            }
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            if (MessagingServiceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("MessagingServiceSid", MessagingServiceSid));
            }
            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            if (MediaUrl != null)
            {
                p.AddRange(MediaUrl.Select(MediaUrl => new KeyValuePair<string, string>("MediaUrl", Serializers.Url(MediaUrl))));
            }
            return p;
        }
        

    }
    /// <summary> Deletes a message record from your account </summary>
    public class DeleteMessageOptions : IOptions<MessageResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the Message resource to delete. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Message resources to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteMessageOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Message resource to delete. </param>
        public DeleteMessageOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch a message belonging to the account used to make the request </summary>
    public class FetchMessageOptions : IOptions<MessageResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Message resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Message resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchMessageOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Message resource to fetch. </param>
        public FetchMessageOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of messages belonging to the account used to make the request </summary>
    public class ReadMessageOptions : ReadOptions<MessageResource>
    {
    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Message resources to read. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> Read messages sent to only this phone number. </summary> 
        public Types.PhoneNumber To { get; set; }

        ///<summary> Read messages sent from only this phone number or alphanumeric sender ID. </summary> 
        public Types.PhoneNumber From { get; set; }

        ///<summary> The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date. </summary> 
        public DateTime? DateSent { get; set; }

        ///<summary> The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date. </summary> 
        public DateTime? DateSentBefore { get; set; }

        ///<summary> The date of the messages to show. Specify a date as `YYYY-MM-DD` in GMT to read only messages sent on this date. For example: `2009-07-06`. You can also specify an inequality, such as `DateSent<=YYYY-MM-DD`, to read messages sent on or before midnight on a date, and `DateSent>=YYYY-MM-DD` to read messages sent on or after midnight on a date. </summary> 
        public DateTime? DateSentAfter { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            if (DateSent != null)
            {
                p.Add(new KeyValuePair<string, string>("DateSent", Serializers.DateTimeIso8601(DateSent)));
            }
            else
            {
                if (DateSentBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateSent<", Serializers.DateTimeIso8601(DateSentBefore)));
                }
                if (DateSentAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("DateSent>", Serializers.DateTimeIso8601(DateSentAfter)));
                }

            }
            if (DateSentBefore != null)
            {
                p.Add(new KeyValuePair<string, string>("DateSent<", Serializers.DateTimeIso8601(DateSentBefore)));
            }
            if (DateSentAfter != null)
            {
                p.Add(new KeyValuePair<string, string>("DateSent>", Serializers.DateTimeIso8601(DateSentAfter)));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> To redact a message-body from a post-flight message record, post to the message instance resource with an empty body </summary>
    public class UpdateMessageOptions : IOptions<MessageResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Message resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Message resources to update. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The text of the message you want to send. Can be up to 1,600 characters long. </summary> 
        public string Body { get; set; }

        
        public MessageResource.UpdateStatusEnum Status { get; set; }



        /// <summary> Construct a new UpdateMessageOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Message resource to update. </param>
        public UpdateMessageOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Body != null)
            {
                p.Add(new KeyValuePair<string, string>("Body", Body));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            return p;
        }
        

    }


}


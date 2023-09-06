using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.PreviewMessaging
{
    public class Message : Resource
    {
        public class MessagingV1Message 
        {
            [JsonProperty("to")]
            [JsonConverter(typeof(PhoneNumberConverter))]
            public Types.PhoneNumber To { get; set; }
            
            [JsonProperty("body")]
            public string Body { get; set; }
            
            [JsonProperty("content_variables")]
            public string ContentVariables { get; set; }
        } 
        
        public class CreateMessagesRequest
        {
            [JsonProperty("messages")] 
            public List<MessagingV1Message> Messages { get; set; }
            
            [JsonProperty("from")]
            [JsonConverter(typeof(PhoneNumberConverter))]
            public Types.PhoneNumber From { get; set;}
            
            [JsonProperty("messaging_service_sid")]
            public string MessagingServiceSid { get; set;}

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("content_sid")]
            public string ContentSid { get; set; }
            
            [JsonProperty("media_url")]
            public List<Uri> MediaUrl { get; set; }

            [JsonProperty("status_callback")]
            public Uri StatusCallback { get; set; }

            [JsonProperty("validity_period")]
            public int? ValidityPeriod { get; set; }

            [JsonProperty("send_at")]
            [JsonConverter(typeof(DateTimeConverter))]
            public DateTime? SendAt { get; set; }

            [JsonProperty("schedule_type")]
            public string ScheduleType { get; set; }

            [JsonProperty("shorten_urls")]
            public bool? ShortenUrls { get; set; }

            [JsonProperty("send_as_mms")]
            public bool? SendAsMms { get; set; }

            [JsonProperty("max_price")]
            public decimal? MaxPrice { get; set; }

            [JsonProperty("attempt")]
            public int? Attempt { get; set; }

            [JsonProperty("smart_encoded")]
            public bool? SmartEncoded { get; set; }

            [JsonProperty("force_delivery")]
            public bool? ForceDelivery { get; set; }

            [JsonProperty("application_sid")]
            public string ApplicationSid { get; set; }
        } 
        
        public class MessagingV1MessageReceipt 
        {
            [JsonProperty("to")]
            [JsonConverter(typeof(PhoneNumberConverter))]
            public Types.PhoneNumber To { get; set; }

            [JsonProperty("sid")]
            public string Sid { get; set; }
        }
        
        public class MessagingV1FailedMessageReceipt 
        {
            [JsonProperty("to")]
            [JsonConverter(typeof(PhoneNumberConverter))]
            public Types.PhoneNumber To { get; set; }

            [JsonProperty("error_message")]
            public string ErrorMessage { get; set; }

            [JsonProperty("error_code")]
            public int ErrorCode { get; set; }
        }
        
        public static MessageCreator Creator(CreateMessagesRequest createMessagesRequest) {
            return new MessageCreator(createMessagesRequest);
        }
        
        [JsonProperty("total_message_count")]
        public int TotalMessageCount { get; set; }
        
        [JsonProperty("success_count")]
        public int SuccessCount { get; set; }
        
        [JsonProperty("error_count")]
        public int ErrorCount { get; set; }
        
        [JsonProperty("message_receipts")] 
        public List<MessagingV1MessageReceipt> MessageReceipts { get; set; }
        
        [JsonProperty("failed_message_receipts")]
        public List<MessagingV1FailedMessageReceipt> FailedMessageReceipts { get; set; }
        
        [JsonConstructor]
        private Message(
             int totalMessageCount,
             int successCount,
             int errorCount,
             List<MessagingV1MessageReceipt> messageReceipts,
             List<MessagingV1FailedMessageReceipt> failedMessageReceipts
        ) {
            this.TotalMessageCount = totalMessageCount;
            this.SuccessCount = successCount;
            this.ErrorCount = errorCount;
            this.MessageReceipts = messageReceipts ?? new List<MessagingV1MessageReceipt>();
            this.FailedMessageReceipts = failedMessageReceipts ?? new List<MessagingV1FailedMessageReceipt>();
        }
        
        public static Message FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Message>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        private sealed class MessageEqualityComparer : IEqualityComparer<Message>
        {
            public bool Equals(Message x, Message y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.TotalMessageCount == y.TotalMessageCount && x.SuccessCount == y.SuccessCount && x.ErrorCount == y.ErrorCount && Equals(x.MessageReceipts, y.MessageReceipts) && Equals(x.FailedMessageReceipts, y.FailedMessageReceipts);
            }

            public int GetHashCode(Message obj)
            {
                unchecked
                {
                    var hashCode = obj.TotalMessageCount;
                    hashCode = (hashCode * 397) ^ obj.SuccessCount;
                    hashCode = (hashCode * 397) ^ obj.ErrorCount;
                    hashCode = (hashCode * 397) ^ (obj.MessageReceipts != null ? obj.MessageReceipts.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.FailedMessageReceipts != null ? obj.FailedMessageReceipts.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<Message> MessageComparer { get; } = new MessageEqualityComparer();
    }
}
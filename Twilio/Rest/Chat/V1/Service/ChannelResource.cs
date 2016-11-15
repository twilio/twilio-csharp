using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Chat.V1.Service 
{

    public class ChannelResource : Resource 
    {
        public sealed class ChannelTypeEnum : IStringEnum 
        {
            public const string Public = "public";
            public const string Private = "private";
        
            private string _value;
            
            public ChannelTypeEnum() {}
            
            public ChannelTypeEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ChannelTypeEnum(string value)
            {
                return new ChannelTypeEnum(value);
            }
            
            public static implicit operator string(ChannelTypeEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelFetcher capable of executing the fetch </returns> 
        public static ChannelFetcher Fetcher(string serviceSid, string sid)
        {
            return new ChannelFetcher(serviceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelDeleter capable of executing the delete </returns> 
        public static ChannelDeleter Deleter(string serviceSid, string sid)
        {
            return new ChannelDeleter(serviceSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> ChannelCreator capable of executing the create </returns> 
        public static ChannelCreator Creator(string serviceSid)
        {
            return new ChannelCreator(serviceSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <returns> ChannelReader capable of executing the read </returns> 
        public static ChannelReader Reader(string serviceSid)
        {
            return new ChannelReader(serviceSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ChannelUpdater capable of executing the update </returns> 
        public static ChannelUpdater Updater(string serviceSid, string sid)
        {
            return new ChannelUpdater(serviceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChannelResource object represented by the provided JSON </returns> 
        public static ChannelResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ChannelResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }
        [JsonProperty("attributes")]
        public string Attributes { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelResource.ChannelTypeEnum Type { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
        public ChannelResource()
        {
        
        }
    
        private ChannelResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("service_sid")]
                                string serviceSid, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("unique_name")]
                                string uniqueName, 
                                [JsonProperty("attributes")]
                                string attributes, 
                                [JsonProperty("type")]
                                ChannelResource.ChannelTypeEnum type, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("created_by")]
                                string createdBy, 
                                [JsonProperty("url")]
                                Uri url, 
                                [JsonProperty("links")]
                                Dictionary<string, string> links)
                                {
            Sid = sid;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            FriendlyName = friendlyName;
            UniqueName = uniqueName;
            Attributes = attributes;
            Type = type;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            CreatedBy = createdBy;
            Url = url;
            Links = links;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class ChannelResource : Resource 
    {
        public sealed class ChannelChannelType : IStringEnum 
        {
            public const string Public = "public";
            public const string Private = "private";
        
            private string _value;
            
            public ChannelChannelType() {}
            
            public ChannelChannelType(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator ChannelChannelType(string value)
            {
                return new ChannelChannelType(value);
            }
            
            public static implicit operator string(ChannelChannelType value)
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
        public string sid { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("service_sid")]
        public string serviceSid { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("unique_name")]
        public string uniqueName { get; set; }
        [JsonProperty("attributes")]
        public string attributes { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelResource.ChannelChannelType type { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string createdBy { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
    
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
                                ChannelResource.ChannelChannelType type, 
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
            this.sid = sid;
            this.accountSid = accountSid;
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.uniqueName = uniqueName;
            this.attributes = attributes;
            this.type = type;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.createdBy = createdBy;
            this.url = url;
            this.links = links;
        }
    }
}
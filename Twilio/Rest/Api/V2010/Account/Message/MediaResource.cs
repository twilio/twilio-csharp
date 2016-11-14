using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class MediaResource : Resource 
    {
        /// <summary>
        /// Delete media from your account. Once delete, you will no longer be billed
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Delete by unique media Sid </param>
        /// <returns> MediaDeleter capable of executing the delete </returns> 
        public static MediaDeleter Deleter(string messageSid, string sid)
        {
            return new MediaDeleter(messageSid, sid);
        }
    
        /// <summary>
        /// Fetch a single media instance belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Fetch by unique media Sid </param>
        /// <returns> MediaFetcher capable of executing the fetch </returns> 
        public static MediaFetcher Fetcher(string messageSid, string sid)
        {
            return new MediaFetcher(messageSid, sid);
        }
    
        /// <summary>
        /// Retrieve a list of medias belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <returns> MediaReader capable of executing the read </returns> 
        public static MediaReader Reader(string messageSid)
        {
            return new MediaReader(messageSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a MediaResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MediaResource object represented by the provided JSON </returns> 
        public static MediaResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MediaResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("parent_sid")]
        public string ParentSid { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public MediaResource()
        {
        
        }
    
        private MediaResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("content_type")]
                              string contentType, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("parent_sid")]
                              string parentSid, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("uri")]
                              string uri)
                              {
            AccountSid = accountSid;
            ContentType = contentType;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            ParentSid = parentSid;
            Sid = sid;
            Uri = uri;
        }
    }
}
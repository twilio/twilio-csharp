using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class CommandResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> CommandFetcher capable of executing the fetch </returns> 
        public static CommandFetcher Fetcher(string sid) {
            return new CommandFetcher(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CommandReader capable of executing the read </returns> 
        public static CommandReader Reader() {
            return new CommandReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="device"> The device </param>
        /// <param name="command"> The command </param>
        /// <returns> CommandCreator capable of executing the create </returns> 
        public static CommandCreator Creator(string device, string command) {
            return new CommandCreator(device, command);
        }
    
        /// <summary>
        /// Converts a JSON string into a CommandResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CommandResource object represented by the provided JSON </returns> 
        public static CommandResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CommandResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("device_sid")]
        private readonly string deviceSid;
        [JsonProperty("command")]
        private readonly string command;
        [JsonProperty("status")]
        private readonly string status;
        [JsonProperty("direction")]
        private readonly string direction;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public CommandResource() {
        
        }
    
        private CommandResource([JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("device_sid")]
                                string deviceSid, 
                                [JsonProperty("command")]
                                string command, 
                                [JsonProperty("status")]
                                string status, 
                                [JsonProperty("direction")]
                                string direction, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("url")]
                                Uri url) {
            this.sid = sid;
            this.accountSid = accountSid;
            this.deviceSid = deviceSid;
            this.command = command;
            this.status = status;
            this.direction = direction;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The device_sid </returns> 
        public string GetDeviceSid() {
            return this.deviceSid;
        }
    
        /// <returns> The command </returns> 
        public string GetCommand() {
            return this.command;
        }
    
        /// <returns> The status </returns> 
        public string GetStatus() {
            return this.status;
        }
    
        /// <returns> The direction </returns> 
        public string GetDirection() {
            return this.direction;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}
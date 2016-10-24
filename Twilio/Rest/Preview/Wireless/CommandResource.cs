using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class CommandResource : Resource {
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
        public string sid { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("device_sid")]
        public string deviceSid { get; }
        [JsonProperty("command")]
        public string command { get; }
        [JsonProperty("command_mode")]
        public string commandMode { get; }
        [JsonProperty("status")]
        public string status { get; }
        [JsonProperty("direction")]
        public string direction { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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
                                [JsonProperty("command_mode")]
                                string commandMode, 
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
            this.commandMode = commandMode;
            this.status = status;
            this.direction = direction;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.url = url;
        }
    }
}
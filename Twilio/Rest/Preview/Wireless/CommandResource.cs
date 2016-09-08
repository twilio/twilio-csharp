using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless {

    public class CommandResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return CommandFetcher capable of executing the fetch
         */
        public static CommandFetcher Fetch(string sid) {
            return new CommandFetcher(sid);
        }
    
        /**
         * read
         * 
         * @return CommandReader capable of executing the read
         */
        public static CommandReader Read() {
            return new CommandReader();
        }
    
        /**
         * create
         * 
         * @param device The device
         * @param command The command
         * @return CommandCreator capable of executing the create
         */
        public static CommandCreator Create(string device, string command) {
            return new CommandCreator(device, command);
        }
    
        /**
         * Converts a JSON string into a CommandResource object
         * 
         * @param json Raw JSON string
         * @return CommandResource object represented by the provided JSON
         */
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
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The device_sid
         */
        public string GetDeviceSid() {
            return this.deviceSid;
        }
    
        /**
         * @return The command
         */
        public string GetCommand() {
            return this.command;
        }
    
        /**
         * @return The status
         */
        public string GetStatus() {
            return this.status;
        }
    
        /**
         * @return The direction
         */
        public string GetDirection() {
            return this.direction;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}
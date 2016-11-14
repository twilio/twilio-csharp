using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class CommandResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> CommandFetcher capable of executing the fetch </returns> 
        public static CommandFetcher Fetcher(string sid)
        {
            return new CommandFetcher(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CommandReader capable of executing the read </returns> 
        public static CommandReader Reader()
        {
            return new CommandReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="device"> The device </param>
        /// <param name="command"> The command </param>
        /// <returns> CommandCreator capable of executing the create </returns> 
        public static CommandCreator Creator(string device, string command)
        {
            return new CommandCreator(device, command);
        }
    
        /// <summary>
        /// Converts a JSON string into a CommandResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CommandResource object represented by the provided JSON </returns> 
        public static CommandResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CommandResource>(json);
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
        [JsonProperty("device_sid")]
        public string DeviceSid { get; set; }
        [JsonProperty("command")]
        public string Command { get; set; }
        [JsonProperty("command_mode")]
        public string CommandMode { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public CommandResource()
        {
        
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
                                Uri url)
                                {
            Sid = sid;
            AccountSid = accountSid;
            DeviceSid = deviceSid;
            Command = command;
            CommandMode = commandMode;
            Status = status;
            Direction = direction;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Url = url;
        }
    }
}
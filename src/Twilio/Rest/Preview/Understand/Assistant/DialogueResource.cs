/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
/// DialogueResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Understand.Assistant
{

    public class DialogueResource : Resource
    {
        private static Request BuildFetchRequest(FetchDialogueOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Dialogues/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Dialogue parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Dialogue </returns>
        public static DialogueResource Fetch(FetchDialogueOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Dialogue parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Dialogue </returns>
        public static async System.Threading.Tasks.Task<DialogueResource> FetchAsync(FetchDialogueOptions options,
                                                                                     ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathAssistantSid"> The assistant_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Dialogue </returns>
        public static DialogueResource Fetch(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchDialogueOptions(pathAssistantSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathAssistantSid"> The assistant_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Dialogue </returns>
        public static async System.Threading.Tasks.Task<DialogueResource> FetchAsync(string pathAssistantSid,
                                                                                     string pathSid,
                                                                                     ITwilioRestClient client = null)
        {
            var options = new FetchDialogueOptions(pathAssistantSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a DialogueResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DialogueResource object represented by the provided JSON </returns>
        public static DialogueResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DialogueResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique ID of the Account that created this Field.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The unique ID of the parent Assistant.
        /// </summary>
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }
        /// <summary>
        /// The unique ID of the Dialogue
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The dialogue memory object as json
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private DialogueResource()
        {

        }
    }

}
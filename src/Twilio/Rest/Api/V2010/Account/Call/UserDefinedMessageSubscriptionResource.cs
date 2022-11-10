/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// UserDefinedMessageSubscriptionResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call
{

    public class UserDefinedMessageSubscriptionResource : Resource
    {
        private static Request BuildCreateRequest(CreateUserDefinedMessageSubscriptionOptions options,
                                                  ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/" + options.PathCallSid + "/UserDefinedMessageSubscriptions.json",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Subscribe to User Defined Messages for a given Call SID.
        /// </summary>
        /// <param name="options"> Create UserDefinedMessageSubscription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessageSubscription </returns>
        public static UserDefinedMessageSubscriptionResource Create(CreateUserDefinedMessageSubscriptionOptions options,
                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Subscribe to User Defined Messages for a given Call SID.
        /// </summary>
        /// <param name="options"> Create UserDefinedMessageSubscription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessageSubscription </returns>
        public static async System.Threading.Tasks.Task<UserDefinedMessageSubscriptionResource> CreateAsync(CreateUserDefinedMessageSubscriptionOptions options,
                                                                                                            ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Subscribe to User Defined Messages for a given Call SID.
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="callback"> The URL we should call to send user defined messages. </param>
        /// <param name="method"> HTTP method used with the callback. </param>
        /// <param name="pathAccountSid"> Account SID. </param>
        /// <param name="idempotencyKey"> A unique string value to identify API call. This should be a unique string value per
        ///                      API call and can be a randomly generated. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessageSubscription </returns>
        public static UserDefinedMessageSubscriptionResource Create(string pathCallSid,
                                                                    Uri callback,
                                                                    Twilio.Http.HttpMethod method,
                                                                    string pathAccountSid = null,
                                                                    string idempotencyKey = null,
                                                                    ITwilioRestClient client = null)
        {
            var options = new CreateUserDefinedMessageSubscriptionOptions(pathCallSid, callback, method){PathAccountSid = pathAccountSid, IdempotencyKey = idempotencyKey};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Subscribe to User Defined Messages for a given Call SID.
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="callback"> The URL we should call to send user defined messages. </param>
        /// <param name="method"> HTTP method used with the callback. </param>
        /// <param name="pathAccountSid"> Account SID. </param>
        /// <param name="idempotencyKey"> A unique string value to identify API call. This should be a unique string value per
        ///                      API call and can be a randomly generated. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessageSubscription </returns>
        public static async System.Threading.Tasks.Task<UserDefinedMessageSubscriptionResource> CreateAsync(string pathCallSid,
                                                                                                            Uri callback,
                                                                                                            Twilio.Http.HttpMethod method,
                                                                                                            string pathAccountSid = null,
                                                                                                            string idempotencyKey = null,
                                                                                                            ITwilioRestClient client = null)
        {
            var options = new CreateUserDefinedMessageSubscriptionOptions(pathCallSid, callback, method){PathAccountSid = pathAccountSid, IdempotencyKey = idempotencyKey};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteUserDefinedMessageSubscriptionOptions options,
                                                  ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/" + options.PathCallSid + "/UserDefinedMessageSubscriptions/" + options.PathSid + ".json",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Delete a specific User Defined Message Subscription.
        /// </summary>
        /// <param name="options"> Delete UserDefinedMessageSubscription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessageSubscription </returns>
        public static bool Delete(DeleteUserDefinedMessageSubscriptionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Delete a specific User Defined Message Subscription.
        /// </summary>
        /// <param name="options"> Delete UserDefinedMessageSubscription parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessageSubscription </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserDefinedMessageSubscriptionOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Delete a specific User Defined Message Subscription.
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="pathSid"> User Defined Message Subscription SID. </param>
        /// <param name="pathAccountSid"> Account SID. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessageSubscription </returns>
        public static bool Delete(string pathCallSid,
                                  string pathSid,
                                  string pathAccountSid = null,
                                  ITwilioRestClient client = null)
        {
            var options = new DeleteUserDefinedMessageSubscriptionOptions(pathCallSid, pathSid){PathAccountSid = pathAccountSid};
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Delete a specific User Defined Message Subscription.
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="pathSid"> User Defined Message Subscription SID. </param>
        /// <param name="pathAccountSid"> Account SID. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessageSubscription </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathCallSid,
                                                                          string pathSid,
                                                                          string pathAccountSid = null,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteUserDefinedMessageSubscriptionOptions(pathCallSid, pathSid){PathAccountSid = pathAccountSid};
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a UserDefinedMessageSubscriptionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserDefinedMessageSubscriptionResource object represented by the provided JSON </returns>
        public static UserDefinedMessageSubscriptionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UserDefinedMessageSubscriptionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// Account SID.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// Call SID.
        /// </summary>
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
        /// <summary>
        /// User Defined Message Subscription SID.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The date this User Defined Message Subscription was created.
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The URI of the User Defined Message Subscription Resource, relative to `https://api.twilio.com`.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        private UserDefinedMessageSubscriptionResource()
        {

        }
    }

}
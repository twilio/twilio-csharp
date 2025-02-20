/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Api.V2010.Account
{
    public class OutgoingCallerIdResource : Resource
    {
    

    

        
        /// <summary> Delete the caller-id specified from the account </summary>
        /// <param name="options"> Delete OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        private static Request BuildDeleteRequest(DeleteOutgoingCallerIdOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/OutgoingCallerIds/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete the caller-id specified from the account </summary>
        /// <param name="options"> Delete OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static bool Delete(DeleteOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete the caller-id specified from the account </summary>
        /// <param name="options"> Delete OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteOutgoingCallerIdOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete the caller-id specified from the account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static bool Delete(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteOutgoingCallerIdOptions(pathSid)      { PathAccountSid = pathAccountSid }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete the caller-id specified from the account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteOutgoingCallerIdOptions(pathSid)  { PathAccountSid = pathAccountSid };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchOutgoingCallerIdOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/OutgoingCallerIds/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch an outgoing-caller-id belonging to the account used to make the request </summary>
        /// <param name="options"> Fetch OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static OutgoingCallerIdResource Fetch(FetchOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an outgoing-caller-id belonging to the account used to make the request </summary>
        /// <param name="options"> Fetch OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<OutgoingCallerIdResource> FetchAsync(FetchOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an outgoing-caller-id belonging to the account used to make the request </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static OutgoingCallerIdResource Fetch(
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchOutgoingCallerIdOptions(pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an outgoing-caller-id belonging to the account used to make the request </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<OutgoingCallerIdResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchOutgoingCallerIdOptions(pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadOutgoingCallerIdOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/OutgoingCallerIds.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of outgoing-caller-ids belonging to the account used to make the request </summary>
        /// <param name="options"> Read OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static ResourceSet<OutgoingCallerIdResource> Read(ReadOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
            return new ResourceSet<OutgoingCallerIdResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of outgoing-caller-ids belonging to the account used to make the request </summary>
        /// <param name="options"> Read OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OutgoingCallerIdResource>> ReadAsync(ReadOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
            return new ResourceSet<OutgoingCallerIdResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of outgoing-caller-ids belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to read. </param>
        /// <param name="phoneNumber"> The phone number of the OutgoingCallerId resources to read. </param>
        /// <param name="friendlyName"> The string that identifies the OutgoingCallerId resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static ResourceSet<OutgoingCallerIdResource> Read(
                                                     string pathAccountSid = null,
                                                     Types.PhoneNumber phoneNumber = null,
                                                     string friendlyName = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadOutgoingCallerIdOptions(){ PathAccountSid = pathAccountSid, PhoneNumber = phoneNumber, FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of outgoing-caller-ids belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to read. </param>
        /// <param name="phoneNumber"> The phone number of the OutgoingCallerId resources to read. </param>
        /// <param name="friendlyName"> The string that identifies the OutgoingCallerId resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OutgoingCallerIdResource>> ReadAsync(
                                                                                             string pathAccountSid = null,
                                                                                             Types.PhoneNumber phoneNumber = null,
                                                                                             string friendlyName = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadOutgoingCallerIdOptions(){ PathAccountSid = pathAccountSid, PhoneNumber = phoneNumber, FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<OutgoingCallerIdResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<OutgoingCallerIdResource> NextPage(Page<OutgoingCallerIdResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<OutgoingCallerIdResource> PreviousPage(Page<OutgoingCallerIdResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateOutgoingCallerIdOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/OutgoingCallerIds/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Updates the caller-id </summary>
        /// <param name="options"> Update OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static OutgoingCallerIdResource Update(UpdateOutgoingCallerIdOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Updates the caller-id </summary>
        /// <param name="options"> Update OutgoingCallerId parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<OutgoingCallerIdResource> UpdateAsync(UpdateOutgoingCallerIdOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Updates the caller-id </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to update. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OutgoingCallerId </returns>
        public static OutgoingCallerIdResource Update(
                                          string pathSid,
                                          string pathAccountSid = null,
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateOutgoingCallerIdOptions(pathSid){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Updates the caller-id </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the OutgoingCallerId resource to update. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resources to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OutgoingCallerId </returns>
        public static async System.Threading.Tasks.Task<OutgoingCallerIdResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string pathAccountSid = null,
                                                                              string friendlyName = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateOutgoingCallerIdOptions(pathSid){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a OutgoingCallerIdResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OutgoingCallerIdResource object represented by the provided JSON </returns>
        public static OutgoingCallerIdResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<OutgoingCallerIdResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique string that that we created to identify the OutgoingCallerId resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The date and time in GMT that the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the OutgoingCallerId resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, which consists of a + followed by the country code and subscriber number. </summary> 
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }

        ///<summary> The URI of the resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private OutgoingCallerIdResource() {

        }
    }
}


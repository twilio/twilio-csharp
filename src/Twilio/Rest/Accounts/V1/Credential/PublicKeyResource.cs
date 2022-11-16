/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Accounts
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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Accounts.V1.Credential
{
    public class PublicKeyResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreatePublicKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Credentials/PublicKeys";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Accounts,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Public Key Credential </summary>
        /// <param name="options"> Create PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Create(CreatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Public Key Credential </summary>
        /// <param name="options"> Create PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(CreatePublicKeyOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Public Key Credential </summary>
        /// <param name="publicKey"> A URL encoded representation of the public key. For example, `- - - - -BEGIN PUBLIC KEY- - - - -MIIBIjANB.pa9xQIDAQAB- - - - -END PUBLIC KEY- - - - -` </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="accountSid"> The SID of the Subaccount that this Credential should be associated with. Must be a valid Subaccount of the account issuing the request </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Create(
                                          string publicKey,
                                          string friendlyName = null,
                                          string accountSid = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreatePublicKeyOptions(publicKey){  FriendlyName = friendlyName, AccountSid = accountSid };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Public Key Credential </summary>
        /// <param name="publicKey"> A URL encoded representation of the public key. For example, `- - - - -BEGIN PUBLIC KEY- - - - -MIIBIjANB.pa9xQIDAQAB- - - - -END PUBLIC KEY- - - - -` </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="accountSid"> The SID of the Subaccount that this Credential should be associated with. Must be a valid Subaccount of the account issuing the request </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<PublicKeyResource> CreateAsync(
                                                                                  string publicKey,
                                                                                  string friendlyName = null,
                                                                                  string accountSid = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreatePublicKeyOptions(publicKey){  FriendlyName = friendlyName, AccountSid = accountSid };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a Credential from your account </summary>
        /// <param name="options"> Delete PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        private static Request BuildDeleteRequest(DeletePublicKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Credentials/PublicKeys/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Accounts,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a Credential from your account </summary>
        /// <param name="options"> Delete PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static bool Delete(DeletePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a Credential from your account </summary>
        /// <param name="options"> Delete PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePublicKeyOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a Credential from your account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a Credential from your account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeletePublicKeyOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchPublicKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Credentials/PublicKeys/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Accounts,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch the public key specified by the provided Credential Sid </summary>
        /// <param name="options"> Fetch PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Fetch(FetchPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch the public key specified by the provided Credential Sid </summary>
        /// <param name="options"> Fetch PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(FetchPublicKeyOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch the public key specified by the provided Credential Sid </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch the public key specified by the provided Credential Sid </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<PublicKeyResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchPublicKeyOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadPublicKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Credentials/PublicKeys";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Accounts,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieves a collection of Public Key Credentials belonging to the account used to make the request </summary>
        /// <param name="options"> Read PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static ResourceSet<PublicKeyResource> Read(ReadPublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<PublicKeyResource>.FromJson("credentials", response.Content);
            return new ResourceSet<PublicKeyResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieves a collection of Public Key Credentials belonging to the account used to make the request </summary>
        /// <param name="options"> Read PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(ReadPublicKeyOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<PublicKeyResource>.FromJson("credentials", response.Content);
            return new ResourceSet<PublicKeyResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieves a collection of Public Key Credentials belonging to the account used to make the request </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of PublicKey </returns>
        public static ResourceSet<PublicKeyResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieves a collection of Public Key Credentials belonging to the account used to make the request </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PublicKeyResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadPublicKeyOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<PublicKeyResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<PublicKeyResource>.FromJson("credentials", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<PublicKeyResource> NextPage(Page<PublicKeyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PublicKeyResource>.FromJson("credentials", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<PublicKeyResource> PreviousPage(Page<PublicKeyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PublicKeyResource>.FromJson("credentials", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdatePublicKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Credentials/PublicKeys/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Accounts,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Modify the properties of a given Account </summary>
        /// <param name="options"> Update PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Update(UpdatePublicKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Modify the properties of a given Account </summary>
        /// <param name="options"> Update PublicKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(UpdatePublicKeyOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Modify the properties of a given Account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PublicKey </returns>
        public static PublicKeyResource Update(
                                          string pathSid,
                                          string friendlyName = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(pathSid){ FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Modify the properties of a given Account </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the PublicKey resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PublicKey </returns>
        public static async System.Threading.Tasks.Task<PublicKeyResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdatePublicKeyOptions(pathSid){ FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a PublicKeyResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PublicKeyResource object represented by the provided JSON </returns>
        public static PublicKeyResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PublicKeyResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that identifies the resource </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the Account that created the Credential that the PublicKey resource belongs to </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT when the resource was created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT when the resource was last updated </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URI for this resource, relative to `https://accounts.twilio.com` </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private PublicKeyResource() {

        }
    }
}


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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Api.V2010.Account
{
    public class ShortCodeResource : Resource
    {
    

        
        private static Request BuildFetchRequest(FetchShortCodeOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SMS/ShortCodes/{Sid}.json";

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

        /// <summary> Fetch an instance of a short code </summary>
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ShortCodeResource Fetch(FetchShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an instance of a short code </summary>
        /// <param name="options"> Fetch ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(FetchShortCodeOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an instance of a short code </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to fetch </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ShortCodeResource Fetch(
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an instance of a short code </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to fetch </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        public static async System.Threading.Tasks.Task<ShortCodeResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchShortCodeOptions(pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadShortCodeOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SMS/ShortCodes.json";

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
        /// <summary> Retrieve a list of short-codes belonging to the account used to make the request </summary>
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ResourceSet<ShortCodeResource> Read(ReadShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of short-codes belonging to the account used to make the request </summary>
        /// <param name="options"> Read ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(ReadShortCodeOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ShortCodeResource>.FromJson("short_codes", response.Content);
            return new ResourceSet<ShortCodeResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of short-codes belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to read. </param>
        /// <param name="friendlyName"> The string that identifies the ShortCode resources to read. </param>
        /// <param name="shortCode"> Only show the ShortCode resources that match this pattern. You can specify partial numbers and use '*' as a wildcard for any digit. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ResourceSet<ShortCodeResource> Read(
                                                     string pathAccountSid = null,
                                                     string friendlyName = null,
                                                     string shortCode = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName, ShortCode = shortCode, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of short-codes belonging to the account used to make the request </summary>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to read. </param>
        /// <param name="friendlyName"> The string that identifies the ShortCode resources to read. </param>
        /// <param name="shortCode"> Only show the ShortCode resources that match this pattern. You can specify partial numbers and use '*' as a wildcard for any digit. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ShortCodeResource>> ReadAsync(
                                                                                             string pathAccountSid = null,
                                                                                             string friendlyName = null,
                                                                                             string shortCode = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadShortCodeOptions(){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName, ShortCode = shortCode, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ShortCodeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ShortCodeResource> PreviousPage(Page<ShortCodeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateShortCodeOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SMS/ShortCodes/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a short code with the following parameters </summary>
        /// <param name="options"> Update ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ShortCodeResource Update(UpdateShortCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a short code with the following parameters </summary>
        /// <param name="options"> Update ShortCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ShortCodeResource> UpdateAsync(UpdateShortCodeOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a short code with the following parameters </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to update </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to update. </param>
        /// <param name="friendlyName"> A descriptive string that you created to describe this resource. It can be up to 64 characters long. By default, the `FriendlyName` is the short code. </param>
        /// <param name="apiVersion"> The API version to use to start a new TwiML session. Can be: `2010-04-01` or `2008-08-01`. </param>
        /// <param name="smsUrl"> The URL we should call when receiving an incoming SMS message to this short code. </param>
        /// <param name="smsMethod"> The HTTP method we should use when calling the `sms_url`. Can be: `GET` or `POST`. </param>
        /// <param name="smsFallbackUrl"> The URL that we should call if an error occurs while retrieving or executing the TwiML from `sms_url`. </param>
        /// <param name="smsFallbackMethod"> The HTTP method that we should use to call the `sms_fallback_url`. Can be: `GET` or `POST`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ShortCode </returns>
        public static ShortCodeResource Update(
                                          string pathSid,
                                          string pathAccountSid = null,
                                          string friendlyName = null,
                                          string apiVersion = null,
                                          Uri smsUrl = null,
                                          Twilio.Http.HttpMethod smsMethod = null,
                                          Uri smsFallbackUrl = null,
                                          Twilio.Http.HttpMethod smsFallbackMethod = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateShortCodeOptions(pathSid){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a short code with the following parameters </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the ShortCode resource to update </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ShortCode resource(s) to update. </param>
        /// <param name="friendlyName"> A descriptive string that you created to describe this resource. It can be up to 64 characters long. By default, the `FriendlyName` is the short code. </param>
        /// <param name="apiVersion"> The API version to use to start a new TwiML session. Can be: `2010-04-01` or `2008-08-01`. </param>
        /// <param name="smsUrl"> The URL we should call when receiving an incoming SMS message to this short code. </param>
        /// <param name="smsMethod"> The HTTP method we should use when calling the `sms_url`. Can be: `GET` or `POST`. </param>
        /// <param name="smsFallbackUrl"> The URL that we should call if an error occurs while retrieving or executing the TwiML from `sms_url`. </param>
        /// <param name="smsFallbackMethod"> The HTTP method that we should use to call the `sms_fallback_url`. Can be: `GET` or `POST`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ShortCode </returns>
        public static async System.Threading.Tasks.Task<ShortCodeResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string pathAccountSid = null,
                                                                              string friendlyName = null,
                                                                              string apiVersion = null,
                                                                              Uri smsUrl = null,
                                                                              Twilio.Http.HttpMethod smsMethod = null,
                                                                              Uri smsFallbackUrl = null,
                                                                              Twilio.Http.HttpMethod smsFallbackMethod = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateShortCodeOptions(pathSid){ PathAccountSid = pathAccountSid, FriendlyName = friendlyName, ApiVersion = apiVersion, SmsUrl = smsUrl, SmsMethod = smsMethod, SmsFallbackUrl = smsFallbackUrl, SmsFallbackMethod = smsFallbackMethod };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ShortCodeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ShortCodeResource object represented by the provided JSON </returns>
        public static ShortCodeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ShortCodeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created this ShortCode resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The API version used to start a new TwiML session when an SMS message is sent to this short code. </summary> 
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }

        ///<summary> The date and time in GMT that this resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that this resource was last updated, specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> A string that you assigned to describe this resource. By default, the `FriendlyName` is the short code. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The short code. e.g., 894546. </summary> 
        [JsonProperty("short_code")]
        public string ShortCode { get; private set; }

        ///<summary> The unique string that that we created to identify this ShortCode resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The HTTP method we use to call the `sms_fallback_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("sms_fallback_method")]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }

        ///<summary> The URL that we call if an error occurs while retrieving or executing the TwiML from `sms_url`. </summary> 
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }

        ///<summary> The HTTP method we use to call the `sms_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("sms_method")]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }

        ///<summary> The URL we call when receiving an incoming SMS message to this short code. </summary> 
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }

        ///<summary> The URI of this resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private ShortCodeResource() {

        }
    }
}


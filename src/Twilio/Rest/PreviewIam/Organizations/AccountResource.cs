/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Organization Public API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
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
using Twilio.Types;


namespace Twilio.Rest.PreviewIam.Organizations
{
    public class AccountResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Active = new StatusEnum("active");
            public static readonly StatusEnum Suspended = new StatusEnum("suspended");
            public static readonly StatusEnum PendingClosure = new StatusEnum("pending_closure");
            public static readonly StatusEnum Closed = new StatusEnum("closed");

        }

        
        private static Request BuildFetchRequest(FetchAccountOptions options, ITwilioRestClient client)
        {
            
            string path = "/Organizations/{OrganizationSid}/Accounts/{AccountSid}";

            string PathOrganizationSid = options.PathOrganizationSid.ToString();
            path = path.Replace("{"+"OrganizationSid"+"}", PathOrganizationSid);
            string PathAccountSid = options.PathAccountSid.ToString();
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.PreviewIam,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Account parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Account </returns>
        public static AccountResource Fetch(FetchAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Account parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Account </returns>
        public static async System.Threading.Tasks.Task<AccountResource> FetchAsync(FetchAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pathAccountSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Account </returns>
        public static AccountResource Fetch(
                                         string pathOrganizationSid, 
                                         string pathAccountSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchAccountOptions(pathOrganizationSid, pathAccountSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pathAccountSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Account </returns>
        public static async System.Threading.Tasks.Task<AccountResource> FetchAsync(string pathOrganizationSid, string pathAccountSid, ITwilioRestClient client = null)
        {
            var options = new FetchAccountOptions(pathOrganizationSid, pathAccountSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadAccountOptions options, ITwilioRestClient client)
        {
            
            string path = "/Organizations/{OrganizationSid}/Accounts";

            string PathOrganizationSid = options.PathOrganizationSid.ToString();
            path = path.Replace("{"+"OrganizationSid"+"}", PathOrganizationSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.PreviewIam,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read Account parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Account </returns>
        public static ResourceSet<AccountResource> Read(ReadAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<AccountResource>.FromJson("content", response.Content);
            return new ResourceSet<AccountResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read Account parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Account </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AccountResource>> ReadAsync(ReadAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<AccountResource>.FromJson("content", response.Content);
            return new ResourceSet<AccountResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pageSize">  </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Account </returns>
        public static ResourceSet<AccountResource> Read(
                                                     string pathOrganizationSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadAccountOptions(pathOrganizationSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pageSize">  </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Account </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AccountResource>> ReadAsync(
                                                                                             string pathOrganizationSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadAccountOptions(pathOrganizationSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<AccountResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AccountResource>.FromJson("content", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<AccountResource> NextPage(Page<AccountResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AccountResource>.FromJson("content", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<AccountResource> PreviousPage(Page<AccountResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AccountResource>.FromJson("content", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a AccountResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccountResource object represented by the provided JSON </returns>
        public static AccountResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AccountResource>(json);
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

    
        ///<summary> Twilio account sid </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Account friendly name </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Account status </summary> 
        [JsonProperty("status")]
        public AccountResource.StatusEnum Status { get; private set; }

        ///<summary> Twilio account sid </summary> 
        [JsonProperty("owner_sid")]
        public string OwnerSid { get; private set; }

        ///<summary> The date and time when the account was created in the system </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }



        private AccountResource() {

        }
    }
}


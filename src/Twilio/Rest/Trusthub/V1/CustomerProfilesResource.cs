/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trusthub
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
using Twilio.Types;


namespace Twilio.Rest.Trusthub.V1
{
    public class CustomerProfilesResource : Resource
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
            public static readonly StatusEnum Draft = new StatusEnum("draft");
            public static readonly StatusEnum PendingReview = new StatusEnum("pending-review");
            public static readonly StatusEnum InReview = new StatusEnum("in-review");
            public static readonly StatusEnum TwilioRejected = new StatusEnum("twilio-rejected");
            public static readonly StatusEnum TwilioApproved = new StatusEnum("twilio-approved");

        }

        
        private static Request BuildCreateRequest(CreateCustomerProfilesOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/CustomerProfiles";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trusthub,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Customer-Profile. </summary>
        /// <param name="options"> Create CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Create(CreateCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Customer-Profile. </summary>
        /// <param name="options"> Create CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> CreateAsync(CreateCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Customer-Profile. </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="email"> The email address that will receive updates when the Customer-Profile resource changes status. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the Customer-Profile resource. </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Create(
                                          string friendlyName,
                                          string email,
                                          string policySid,
                                          Uri statusCallback = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateCustomerProfilesOptions(friendlyName, email, policySid){  StatusCallback = statusCallback };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Customer-Profile. </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="email"> The email address that will receive updates when the Customer-Profile resource changes status. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the Customer-Profile resource. </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> CreateAsync(
                                                                                  string friendlyName,
                                                                                  string email,
                                                                                  string policySid,
                                                                                  Uri statusCallback = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateCustomerProfilesOptions(friendlyName, email, policySid){  StatusCallback = statusCallback };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Customer-Profile. </summary>
        /// <param name="options"> Delete CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        private static Request BuildDeleteRequest(DeleteCustomerProfilesOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/CustomerProfiles/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trusthub,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Customer-Profile. </summary>
        /// <param name="options"> Delete CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static bool Delete(DeleteCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Customer-Profile. </summary>
        /// <param name="options"> Delete CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCustomerProfilesOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Customer-Profile. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteCustomerProfilesOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Customer-Profile. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteCustomerProfilesOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchCustomerProfilesOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/CustomerProfiles/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Customer-Profile instance. </summary>
        /// <param name="options"> Fetch CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Fetch(FetchCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Customer-Profile instance. </summary>
        /// <param name="options"> Fetch CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> FetchAsync(FetchCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Customer-Profile instance. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchCustomerProfilesOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Customer-Profile instance. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchCustomerProfilesOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadCustomerProfilesOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/CustomerProfiles";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Customer-Profiles for an account. </summary>
        /// <param name="options"> Read CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static ResourceSet<CustomerProfilesResource> Read(ReadCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<CustomerProfilesResource>.FromJson("results", response.Content);
            return new ResourceSet<CustomerProfilesResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Customer-Profiles for an account. </summary>
        /// <param name="options"> Read CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<CustomerProfilesResource>> ReadAsync(ReadCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<CustomerProfilesResource>.FromJson("results", response.Content);
            return new ResourceSet<CustomerProfilesResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Customer-Profiles for an account. </summary>
        /// <param name="status"> The verification status of the Customer-Profile resource. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the Customer-Profile resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static ResourceSet<CustomerProfilesResource> Read(
                                                     CustomerProfilesResource.StatusEnum status = null,
                                                     string friendlyName = null,
                                                     string policySid = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadCustomerProfilesOptions(){ Status = status, FriendlyName = friendlyName, PolicySid = policySid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Customer-Profiles for an account. </summary>
        /// <param name="status"> The verification status of the Customer-Profile resource. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the Customer-Profile resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<CustomerProfilesResource>> ReadAsync(
                                                                                             CustomerProfilesResource.StatusEnum status = null,
                                                                                             string friendlyName = null,
                                                                                             string policySid = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadCustomerProfilesOptions(){ Status = status, FriendlyName = friendlyName, PolicySid = policySid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<CustomerProfilesResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<CustomerProfilesResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<CustomerProfilesResource> NextPage(Page<CustomerProfilesResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<CustomerProfilesResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<CustomerProfilesResource> PreviousPage(Page<CustomerProfilesResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<CustomerProfilesResource>.FromJson("results", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateCustomerProfilesOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/CustomerProfiles/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trusthub,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Updates a Customer-Profile in an account. </summary>
        /// <param name="options"> Update CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Update(UpdateCustomerProfilesOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Updates a Customer-Profile in an account. </summary>
        /// <param name="options"> Update CustomerProfiles parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> UpdateAsync(UpdateCustomerProfilesOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Updates a Customer-Profile in an account. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="status">  </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="email"> The email address that will receive updates when the Customer-Profile resource changes status. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomerProfiles </returns>
        public static CustomerProfilesResource Update(
                                          string pathSid,
                                          CustomerProfilesResource.StatusEnum status = null,
                                          Uri statusCallback = null,
                                          string friendlyName = null,
                                          string email = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateCustomerProfilesOptions(pathSid){ Status = status, StatusCallback = statusCallback, FriendlyName = friendlyName, Email = email };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Updates a Customer-Profile in an account. </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Customer-Profile resource. </param>
        /// <param name="status">  </param>
        /// <param name="statusCallback"> The URL we call to inform your application of status changes. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource. </param>
        /// <param name="email"> The email address that will receive updates when the Customer-Profile resource changes status. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomerProfiles </returns>
        public static async System.Threading.Tasks.Task<CustomerProfilesResource> UpdateAsync(
                                                                              string pathSid,
                                                                              CustomerProfilesResource.StatusEnum status = null,
                                                                              Uri statusCallback = null,
                                                                              string friendlyName = null,
                                                                              string email = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateCustomerProfilesOptions(pathSid){ Status = status, StatusCallback = statusCallback, FriendlyName = friendlyName, Email = email };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CustomerProfilesResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CustomerProfilesResource object represented by the provided JSON </returns>
        public static CustomerProfilesResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<CustomerProfilesResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Customer-Profile resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Customer-Profile resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string of a policy that is associated to the Customer-Profile resource. </summary> 
        [JsonProperty("policy_sid")]
        public string PolicySid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        
        [JsonProperty("status")]
        public CustomerProfilesResource.StatusEnum Status { get; private set; }

        ///<summary> The date and time in GMT in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format when the resource will be valid until. </summary> 
        [JsonProperty("valid_until")]
        public DateTime? ValidUntil { get; private set; }

        ///<summary> The email address that will receive updates when the Customer-Profile resource changes status. </summary> 
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///<summary> The URL we call to inform your application of status changes. </summary> 
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the Customer-Profile resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of the Assigned Items of the Customer-Profile resource. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The error codes associated with the rejection of the Customer-Profile. </summary> 
        [JsonProperty("errors")]
        public List<object> Errors { get; private set; }



        private CustomerProfilesResource() {

        }
    }
}


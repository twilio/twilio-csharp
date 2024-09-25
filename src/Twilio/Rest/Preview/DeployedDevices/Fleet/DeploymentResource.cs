/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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





namespace Twilio.Rest.Preview.DeployedDevices.Fleet
{
    public class DeploymentResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateDeploymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/DeployedDevices/Fleets/{FleetSid}/Deployments";

            string PathFleetSid = options.PathFleetSid;
            path = path.Replace("{"+"FleetSid"+"}", PathFleetSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Deployment in the Fleet, optionally giving it a friendly name and linking to a specific Twilio Sync service instance. </summary>
        /// <param name="options"> Create Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Create(CreateDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Deployment in the Fleet, optionally giving it a friendly name and linking to a specific Twilio Sync service instance. </summary>
        /// <param name="options"> Create Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<DeploymentResource> CreateAsync(CreateDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Deployment in the Fleet, optionally giving it a friendly name and linking to a specific Twilio Sync service instance. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="friendlyName"> Provides a human readable descriptive text for this Deployment, up to 256 characters long. </param>
        /// <param name="syncServiceSid"> Provides the unique string identifier of the Twilio Sync service instance that will be linked to and accessible by this Deployment. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Create(
                                          string pathFleetSid,
                                          string friendlyName = null,
                                          string syncServiceSid = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateDeploymentOptions(pathFleetSid){  FriendlyName = friendlyName, SyncServiceSid = syncServiceSid };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Deployment in the Fleet, optionally giving it a friendly name and linking to a specific Twilio Sync service instance. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="friendlyName"> Provides a human readable descriptive text for this Deployment, up to 256 characters long. </param>
        /// <param name="syncServiceSid"> Provides the unique string identifier of the Twilio Sync service instance that will be linked to and accessible by this Deployment. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<DeploymentResource> CreateAsync(
                                                                                  string pathFleetSid,
                                                                                  string friendlyName = null,
                                                                                  string syncServiceSid = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateDeploymentOptions(pathFleetSid){  FriendlyName = friendlyName, SyncServiceSid = syncServiceSid };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Deployment from the Fleet, leaving associated devices effectively undeployed. </summary>
        /// <param name="options"> Delete Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        private static Request BuildDeleteRequest(DeleteDeploymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/DeployedDevices/Fleets/{FleetSid}/Deployments/{Sid}";

            string PathFleetSid = options.PathFleetSid;
            path = path.Replace("{"+"FleetSid"+"}", PathFleetSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Deployment from the Fleet, leaving associated devices effectively undeployed. </summary>
        /// <param name="options"> Delete Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static bool Delete(DeleteDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Deployment from the Fleet, leaving associated devices effectively undeployed. </summary>
        /// <param name="options"> Delete Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDeploymentOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Deployment from the Fleet, leaving associated devices effectively undeployed. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static bool Delete(string pathFleetSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteDeploymentOptions(pathFleetSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Deployment from the Fleet, leaving associated devices effectively undeployed. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathFleetSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteDeploymentOptions(pathFleetSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchDeploymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/DeployedDevices/Fleets/{FleetSid}/Deployments/{Sid}";

            string PathFleetSid = options.PathFleetSid;
            path = path.Replace("{"+"FleetSid"+"}", PathFleetSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch information about a specific Deployment in the Fleet. </summary>
        /// <param name="options"> Fetch Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Fetch(FetchDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch information about a specific Deployment in the Fleet. </summary>
        /// <param name="options"> Fetch Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<DeploymentResource> FetchAsync(FetchDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch information about a specific Deployment in the Fleet. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Fetch(
                                         string pathFleetSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchDeploymentOptions(pathFleetSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch information about a specific Deployment in the Fleet. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<DeploymentResource> FetchAsync(string pathFleetSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchDeploymentOptions(pathFleetSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadDeploymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/DeployedDevices/Fleets/{FleetSid}/Deployments";

            string PathFleetSid = options.PathFleetSid;
            path = path.Replace("{"+"FleetSid"+"}", PathFleetSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Deployments belonging to the Fleet. </summary>
        /// <param name="options"> Read Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static ResourceSet<DeploymentResource> Read(ReadDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<DeploymentResource>.FromJson("deployments", response.Content);
            return new ResourceSet<DeploymentResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Deployments belonging to the Fleet. </summary>
        /// <param name="options"> Read Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeploymentResource>> ReadAsync(ReadDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DeploymentResource>.FromJson("deployments", response.Content);
            return new ResourceSet<DeploymentResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Deployments belonging to the Fleet. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static ResourceSet<DeploymentResource> Read(
                                                     string pathFleetSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadDeploymentOptions(pathFleetSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Deployments belonging to the Fleet. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeploymentResource>> ReadAsync(
                                                                                             string pathFleetSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadDeploymentOptions(pathFleetSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DeploymentResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DeploymentResource>.FromJson("deployments", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DeploymentResource> NextPage(Page<DeploymentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeploymentResource>.FromJson("deployments", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DeploymentResource> PreviousPage(Page<DeploymentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeploymentResource>.FromJson("deployments", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateDeploymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/DeployedDevices/Fleets/{FleetSid}/Deployments/{Sid}";

            string PathFleetSid = options.PathFleetSid;
            path = path.Replace("{"+"FleetSid"+"}", PathFleetSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update the given properties of a specific Deployment credential in the Fleet, giving it a friendly name or linking to a specific Twilio Sync service instance. </summary>
        /// <param name="options"> Update Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Update(UpdateDeploymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update the given properties of a specific Deployment credential in the Fleet, giving it a friendly name or linking to a specific Twilio Sync service instance. </summary>
        /// <param name="options"> Update Deployment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<DeploymentResource> UpdateAsync(UpdateDeploymentOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update the given properties of a specific Deployment credential in the Fleet, giving it a friendly name or linking to a specific Twilio Sync service instance. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="friendlyName"> Provides a human readable descriptive text for this Deployment, up to 64 characters long </param>
        /// <param name="syncServiceSid"> Provides the unique string identifier of the Twilio Sync service instance that will be linked to and accessible by this Deployment. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deployment </returns>
        public static DeploymentResource Update(
                                          string pathFleetSid,
                                          string pathSid,
                                          string friendlyName = null,
                                          string syncServiceSid = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateDeploymentOptions(pathFleetSid, pathSid){ FriendlyName = friendlyName, SyncServiceSid = syncServiceSid };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update the given properties of a specific Deployment credential in the Fleet, giving it a friendly name or linking to a specific Twilio Sync service instance. </summary>
        /// <param name="pathFleetSid">  </param>
        /// <param name="pathSid"> Provides a 34 character string that uniquely identifies the requested Deployment resource. </param>
        /// <param name="friendlyName"> Provides a human readable descriptive text for this Deployment, up to 64 characters long </param>
        /// <param name="syncServiceSid"> Provides the unique string identifier of the Twilio Sync service instance that will be linked to and accessible by this Deployment. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deployment </returns>
        public static async System.Threading.Tasks.Task<DeploymentResource> UpdateAsync(
                                                                              string pathFleetSid,
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              string syncServiceSid = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateDeploymentOptions(pathFleetSid, pathSid){ FriendlyName = friendlyName, SyncServiceSid = syncServiceSid };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DeploymentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeploymentResource object represented by the provided JSON </returns>
        public static DeploymentResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DeploymentResource>(json);
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

    
        ///<summary> Contains a 34 character string that uniquely identifies this Deployment resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> Contains an absolute URL for this Deployment resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains a human readable descriptive text for this Deployment, up to 64 characters long </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Specifies the unique string identifier of the Fleet that the given Deployment belongs to. </summary> 
        [JsonProperty("fleet_sid")]
        public string FleetSid { get; private set; }

        ///<summary> Specifies the unique string identifier of the Account responsible for this Deployment. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Specifies the unique string identifier of the Twilio Sync service instance linked to and accessible by this Deployment. </summary> 
        [JsonProperty("sync_service_sid")]
        public string SyncServiceSid { get; private set; }

        ///<summary> Specifies the date this Deployment was created, given in UTC ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> Specifies the date this Deployment was last updated, given in UTC ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }



        private DeploymentResource() {

        }
    }
}


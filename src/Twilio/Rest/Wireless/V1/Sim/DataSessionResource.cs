/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Wireless
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



namespace Twilio.Rest.Wireless.V1.Sim
{
    public class DataSessionResource : Resource
    {
    

        
        private static Request BuildReadRequest(ReadDataSessionOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Sims/{SimSid}/DataSessions";

            string PathSimSid = options.PathSimSid;
            path = path.Replace("{"+"SimSid"+"}", PathSimSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Wireless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read DataSession parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DataSession </returns>
        public static ResourceSet<DataSessionResource> Read(ReadDataSessionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<DataSessionResource>.FromJson("data_sessions", response.Content);
            return new ResourceSet<DataSessionResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read DataSession parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DataSession </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DataSessionResource>> ReadAsync(ReadDataSessionOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DataSessionResource>.FromJson("data_sessions", response.Content);
            return new ResourceSet<DataSessionResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathSimSid"> The SID of the [Sim resource](https://www.twilio.com/docs/wireless/api/sim-resource) with the Data Sessions to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DataSession </returns>
        public static ResourceSet<DataSessionResource> Read(
                                                     string pathSimSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadDataSessionOptions(pathSimSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathSimSid"> The SID of the [Sim resource](https://www.twilio.com/docs/wireless/api/sim-resource) with the Data Sessions to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DataSession </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DataSessionResource>> ReadAsync(
                                                                                             string pathSimSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadDataSessionOptions(pathSimSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DataSessionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DataSessionResource>.FromJson("data_sessions", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DataSessionResource> NextPage(Page<DataSessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DataSessionResource>.FromJson("data_sessions", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DataSessionResource> PreviousPage(Page<DataSessionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DataSessionResource>.FromJson("data_sessions", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a DataSessionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DataSessionResource object represented by the provided JSON </returns>
        public static DataSessionResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DataSessionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the DataSession resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Sim resource](https://www.twilio.com/docs/wireless/api/sim-resource) that the Data Session is for. </summary> 
        [JsonProperty("sim_sid")]
        public string SimSid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the DataSession resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The generation of wireless technology that the device was using. </summary> 
        [JsonProperty("radio_link")]
        public string RadioLink { get; private set; }

        ///<summary> The 'mobile country code' is the unique ID of the home country where the Data Session took place. See: [MCC/MNC lookup](http://mcc-mnc.com/). </summary> 
        [JsonProperty("operator_mcc")]
        public string OperatorMcc { get; private set; }

        ///<summary> The 'mobile network code' is the unique ID specific to the mobile operator network where the Data Session took place. </summary> 
        [JsonProperty("operator_mnc")]
        public string OperatorMnc { get; private set; }

        ///<summary> The three letter country code representing where the device's Data Session took place. This is determined by looking up the `operator_mcc`. </summary> 
        [JsonProperty("operator_country")]
        public string OperatorCountry { get; private set; }

        ///<summary> The friendly name of the mobile operator network that the [SIM](https://www.twilio.com/docs/wireless/api/sim-resource)-connected device is attached to. This is determined by looking up the `operator_mnc`. </summary> 
        [JsonProperty("operator_name")]
        public string OperatorName { get; private set; }

        ///<summary> The unique ID of the cellular tower that the device was attached to at the moment when the Data Session was last updated. </summary> 
        [JsonProperty("cell_id")]
        public string CellId { get; private set; }

        ///<summary> An object that describes the estimated location in latitude and longitude where the device's Data Session took place. The location is derived from the `cell_id` when the Data Session was last updated. See [Cell Location Estimate Object](https://www.twilio.com/docs/wireless/api/datasession-resource#cell-location-estimate-object).  </summary> 
        [JsonProperty("cell_location_estimate")]
        public object CellLocationEstimate { get; private set; }

        ///<summary> The number of packets uploaded by the device between the `start` time and when the Data Session was last updated. </summary> 
        [JsonProperty("packets_uploaded")]
        public int? PacketsUploaded { get; private set; }

        ///<summary> The number of packets downloaded by the device between the `start` time and when the Data Session was last updated. </summary> 
        [JsonProperty("packets_downloaded")]
        public int? PacketsDownloaded { get; private set; }

        ///<summary> The date that the resource was last updated, given as GMT in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; private set; }

        ///<summary> The date that the Data Session started, given as GMT in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("start")]
        public DateTime? Start { get; private set; }

        ///<summary> The date that the record ended, given as GMT in [ISO 8601](https://www.iso.org/iso-8601-date-and-time-format.html) format. </summary> 
        [JsonProperty("end")]
        public DateTime? End { get; private set; }

        ///<summary> The 'international mobile equipment identity' is the unique ID of the device using the SIM to connect. An IMEI is a 15-digit string: 14 digits for the device identifier plus a check digit calculated using the Luhn formula. </summary> 
        [JsonProperty("imei")]
        public string Imei { get; private set; }



        private DataSessionResource() {

        }
    }
}


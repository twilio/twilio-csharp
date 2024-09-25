/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Marketplace
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





namespace Twilio.Rest.Marketplace.V1.InstalledAddOn
{
    public class InstalledAddOnUsageResource : Resource
    {
    
        public class MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems
        {
            [JsonProperty("quantity")]
            private decimal? Quantity {get; set;}
            [JsonProperty("sid")]
            private string Sid {get; set;}
            [JsonProperty("submitted")]
            private bool? Submitted {get; set;}
            public MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems() { }
            public class Builder
            {
                private MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems _marketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems = new MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems();
                public Builder()
                {
                }
                public Builder WithQuantity(decimal? quantity)
                {
                    _marketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems.Quantity= quantity;
                    return this;
                }
                public Builder WithSid(string sid)
                {
                    _marketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems.Sid= sid;
                    return this;
                }
                public Builder WithSubmitted(bool? submitted)
                {
                    _marketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems.Submitted= submitted;
                    return this;
                }
                public MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems Build()
                {
                    return _marketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems;
                }
            }
        }
        public class MarketplaceV1InstalledAddOnInstalledAddOnUsage
        {
            [JsonProperty("total_submitted")]
            private decimal? TotalSubmitted {get; set;}
            [JsonProperty("billable_items")]
            private List<MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems> BillableItems {get; set;}
            public MarketplaceV1InstalledAddOnInstalledAddOnUsage() { }
            public class Builder
            {
                private MarketplaceV1InstalledAddOnInstalledAddOnUsage _marketplaceV1InstalledAddOnInstalledAddOnUsage = new MarketplaceV1InstalledAddOnInstalledAddOnUsage();
                public Builder()
                {
                }
                public Builder WithTotalSubmitted(decimal? totalSubmitted)
                {
                    _marketplaceV1InstalledAddOnInstalledAddOnUsage.TotalSubmitted= totalSubmitted;
                    return this;
                }
                public Builder WithBillableItems(List<MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems> billableItems)
                {
                    _marketplaceV1InstalledAddOnInstalledAddOnUsage.BillableItems= billableItems;
                    return this;
                }
                public MarketplaceV1InstalledAddOnInstalledAddOnUsage Build()
                {
                    return _marketplaceV1InstalledAddOnInstalledAddOnUsage;
                }
            }
        }

    

        
        private static Request BuildCreateRequest(CreateInstalledAddOnUsageOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/InstalledAddOns/{InstalledAddOnSid}/Usage";

            string PathInstalledAddOnSid = options.PathInstalledAddOnSid;
            path = path.Replace("{"+"InstalledAddOnSid"+"}", PathInstalledAddOnSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Marketplace,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Allows Twilio Marketplace publishers to manually report customer usage on No-code Partner Listings that they own. </summary>
        /// <param name="options"> Create InstalledAddOnUsage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnUsage </returns>
        public static InstalledAddOnUsageResource Create(CreateInstalledAddOnUsageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Allows Twilio Marketplace publishers to manually report customer usage on No-code Partner Listings that they own. </summary>
        /// <param name="options"> Create InstalledAddOnUsage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnUsage </returns>
        public static async System.Threading.Tasks.Task<InstalledAddOnUsageResource> CreateAsync(CreateInstalledAddOnUsageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Allows Twilio Marketplace publishers to manually report customer usage on No-code Partner Listings that they own. </summary>
        /// <param name="pathInstalledAddOnSid"> Customer Installation SID to report usage on. </param>
        /// <param name="marketplaceV1InstalledAddOnInstalledAddOnUsage">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of InstalledAddOnUsage </returns>
        public static InstalledAddOnUsageResource Create(
                                          string pathInstalledAddOnSid,
                                          InstalledAddOnUsageResource.MarketplaceV1InstalledAddOnInstalledAddOnUsage marketplaceV1InstalledAddOnInstalledAddOnUsage,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateInstalledAddOnUsageOptions(pathInstalledAddOnSid, marketplaceV1InstalledAddOnInstalledAddOnUsage){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Allows Twilio Marketplace publishers to manually report customer usage on No-code Partner Listings that they own. </summary>
        /// <param name="pathInstalledAddOnSid"> Customer Installation SID to report usage on. </param>
        /// <param name="marketplaceV1InstalledAddOnInstalledAddOnUsage">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of InstalledAddOnUsage </returns>
        public static async System.Threading.Tasks.Task<InstalledAddOnUsageResource> CreateAsync(
                                                                                  string pathInstalledAddOnSid,
                                                                                  InstalledAddOnUsageResource.MarketplaceV1InstalledAddOnInstalledAddOnUsage marketplaceV1InstalledAddOnInstalledAddOnUsage,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateInstalledAddOnUsageOptions(pathInstalledAddOnSid, marketplaceV1InstalledAddOnInstalledAddOnUsage){  };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a InstalledAddOnUsageResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> InstalledAddOnUsageResource object represented by the provided JSON </returns>
        public static InstalledAddOnUsageResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<InstalledAddOnUsageResource>(json);
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

    
        ///<summary> Total amount in local currency that was billed in this request. Aggregates all billable_items that were successfully submitted. </summary> 
        [JsonProperty("total_submitted")]
        public decimal? TotalSubmitted { get; private set; }

        ///<summary> The billable_items </summary> 
        [JsonProperty("billable_items")]
        public List<MarketplaceV1InstalledAddOnInstalledAddOnUsageBillableItems> BillableItems { get; }



        private InstalledAddOnUsageResource() {

        }
    }
}


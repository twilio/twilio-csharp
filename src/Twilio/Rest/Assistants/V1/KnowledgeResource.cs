/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Assistants
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



namespace Twilio.Rest.Assistants.V1
{
    public class KnowledgeResource : Resource
    {
    
        public class AssistantsV1ServiceCreatePolicyRequest
        {
            [JsonProperty("description")]
            private string Description {get; set;}
            [JsonProperty("id")]
            private string Id {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("policy_details")]
            private object PolicyDetails {get; set;}
            [JsonProperty("type")]
            private string Type {get; set;}
            public AssistantsV1ServiceCreatePolicyRequest() { }
            public class Builder
            {
                private AssistantsV1ServiceCreatePolicyRequest _assistantsV1ServiceCreatePolicyRequest = new AssistantsV1ServiceCreatePolicyRequest();
                public Builder()
                {
                }
                public Builder WithDescription(string description)
                {
                    _assistantsV1ServiceCreatePolicyRequest.Description= description;
                    return this;
                }
                public Builder WithId(string id)
                {
                    _assistantsV1ServiceCreatePolicyRequest.Id= id;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceCreatePolicyRequest.Name= name;
                    return this;
                }
                public Builder WithPolicyDetails(object policyDetails)
                {
                    _assistantsV1ServiceCreatePolicyRequest.PolicyDetails= policyDetails;
                    return this;
                }
                public Builder WithType(string type)
                {
                    _assistantsV1ServiceCreatePolicyRequest.Type= type;
                    return this;
                }
                public AssistantsV1ServiceCreatePolicyRequest Build()
                {
                    return _assistantsV1ServiceCreatePolicyRequest;
                }
            }
        }
        public class AssistantsV1ServiceCreateKnowledgeRequest
        {
            [JsonProperty("assistant_id")]
            private string AssistantId {get; set;}
            [JsonProperty("description")]
            private string Description {get; set;}
            [JsonProperty("knowledge_source_details")]
            private object KnowledgeSourceDetails {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("policy")]
            private AssistantsV1ServiceCreatePolicyRequest Policy {get; set;}
            [JsonProperty("type")]
            private string Type {get; set;}
            [JsonProperty("embedding_model")]
            private string EmbeddingModel {get; set;}
            public AssistantsV1ServiceCreateKnowledgeRequest() { }
            public class Builder
            {
                private AssistantsV1ServiceCreateKnowledgeRequest _assistantsV1ServiceCreateKnowledgeRequest = new AssistantsV1ServiceCreateKnowledgeRequest();
                public Builder()
                {
                }
                public Builder WithAssistantId(string assistantId)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.AssistantId= assistantId;
                    return this;
                }
                public Builder WithDescription(string description)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.Description= description;
                    return this;
                }
                public Builder WithKnowledgeSourceDetails(object knowledgeSourceDetails)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.KnowledgeSourceDetails= knowledgeSourceDetails;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.Name= name;
                    return this;
                }
                public Builder WithPolicy(AssistantsV1ServiceCreatePolicyRequest policy)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.Policy= policy;
                    return this;
                }
                public Builder WithType(string type)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.Type= type;
                    return this;
                }
                public Builder WithEmbeddingModel(string embeddingModel)
                {
                    _assistantsV1ServiceCreateKnowledgeRequest.EmbeddingModel= embeddingModel;
                    return this;
                }
                public AssistantsV1ServiceCreateKnowledgeRequest Build()
                {
                    return _assistantsV1ServiceCreateKnowledgeRequest;
                }
            }
        }
        public class AssistantsV1ServiceUpdateKnowledgeRequest
        {
            [JsonProperty("description")]
            private string Description {get; set;}
            [JsonProperty("knowledge_source_details")]
            private object KnowledgeSourceDetails {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("policy")]
            private AssistantsV1ServiceCreatePolicyRequest Policy {get; set;}
            [JsonProperty("type")]
            private string Type {get; set;}
            [JsonProperty("embedding_model")]
            private string EmbeddingModel {get; set;}
            public AssistantsV1ServiceUpdateKnowledgeRequest() { }
            public class Builder
            {
                private AssistantsV1ServiceUpdateKnowledgeRequest _assistantsV1ServiceUpdateKnowledgeRequest = new AssistantsV1ServiceUpdateKnowledgeRequest();
                public Builder()
                {
                }
                public Builder WithDescription(string description)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.Description= description;
                    return this;
                }
                public Builder WithKnowledgeSourceDetails(object knowledgeSourceDetails)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.KnowledgeSourceDetails= knowledgeSourceDetails;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.Name= name;
                    return this;
                }
                public Builder WithPolicy(AssistantsV1ServiceCreatePolicyRequest policy)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.Policy= policy;
                    return this;
                }
                public Builder WithType(string type)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.Type= type;
                    return this;
                }
                public Builder WithEmbeddingModel(string embeddingModel)
                {
                    _assistantsV1ServiceUpdateKnowledgeRequest.EmbeddingModel= embeddingModel;
                    return this;
                }
                public AssistantsV1ServiceUpdateKnowledgeRequest Build()
                {
                    return _assistantsV1ServiceUpdateKnowledgeRequest;
                }
            }
        }

    

        
        private static Request BuildCreateRequest(CreateKnowledgeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Knowledge";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Assistants,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Create knowledge </summary>
        /// <param name="options"> Create Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Create(CreateKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create knowledge </summary>
        /// <param name="options"> Create Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<KnowledgeResource> CreateAsync(CreateKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create knowledge </summary>
        /// <param name="assistantsV1ServiceCreateKnowledgeRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Create(
                                          KnowledgeResource.AssistantsV1ServiceCreateKnowledgeRequest assistantsV1ServiceCreateKnowledgeRequest,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateKnowledgeOptions(assistantsV1ServiceCreateKnowledgeRequest){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create knowledge </summary>
        /// <param name="assistantsV1ServiceCreateKnowledgeRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<KnowledgeResource> CreateAsync(
                                                                                  KnowledgeResource.AssistantsV1ServiceCreateKnowledgeRequest assistantsV1ServiceCreateKnowledgeRequest,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateKnowledgeOptions(assistantsV1ServiceCreateKnowledgeRequest){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete knowledge </summary>
        /// <param name="options"> Delete Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        private static Request BuildDeleteRequest(DeleteKnowledgeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Knowledge/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"id"+"}", PathId);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete knowledge </summary>
        /// <param name="options"> Delete Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static bool Delete(DeleteKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete knowledge </summary>
        /// <param name="options"> Delete Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteKnowledgeOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete knowledge </summary>
        /// <param name="pathId"> the Knowledge ID. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static bool Delete(string pathId, ITwilioRestClient client = null)
        {
            var options = new DeleteKnowledgeOptions(pathId)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete knowledge </summary>
        /// <param name="pathId"> the Knowledge ID. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathId, ITwilioRestClient client = null)
        {
            var options = new DeleteKnowledgeOptions(pathId) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchKnowledgeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Knowledge/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"id"+"}", PathId);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Get knowledge </summary>
        /// <param name="options"> Fetch Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Fetch(FetchKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Get knowledge </summary>
        /// <param name="options"> Fetch Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<KnowledgeResource> FetchAsync(FetchKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Get knowledge </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Fetch(
                                         string pathId, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchKnowledgeOptions(pathId){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Get knowledge </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<KnowledgeResource> FetchAsync(string pathId, ITwilioRestClient client = null)
        {
            var options = new FetchKnowledgeOptions(pathId){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadKnowledgeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Knowledge";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> List all knowledge </summary>
        /// <param name="options"> Read Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static ResourceSet<KnowledgeResource> Read(ReadKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<KnowledgeResource>.FromJson("knowledge", response.Content);
            return new ResourceSet<KnowledgeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> List all knowledge </summary>
        /// <param name="options"> Read Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<KnowledgeResource>> ReadAsync(ReadKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<KnowledgeResource>.FromJson("knowledge", response.Content);
            return new ResourceSet<KnowledgeResource>(page, options, client);
        }
        #endif
        /// <summary> List all knowledge </summary>
        /// <param name="assistantId">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static ResourceSet<KnowledgeResource> Read(
                                                     string assistantId = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadKnowledgeOptions(){ AssistantId = assistantId, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> List all knowledge </summary>
        /// <param name="assistantId">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<KnowledgeResource>> ReadAsync(
                                                                                             string assistantId = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadKnowledgeOptions(){ AssistantId = assistantId, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<KnowledgeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<KnowledgeResource>.FromJson("knowledge", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<KnowledgeResource> NextPage(Page<KnowledgeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<KnowledgeResource>.FromJson("knowledge", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<KnowledgeResource> PreviousPage(Page<KnowledgeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<KnowledgeResource>.FromJson("knowledge", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateKnowledgeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Knowledge/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"id"+"}", PathId);

            return new Request(
                HttpMethod.Put,
                Rest.Domain.Assistants,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Update knowledge </summary>
        /// <param name="options"> Update Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Update(UpdateKnowledgeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update knowledge </summary>
        /// <param name="options"> Update Knowledge parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<KnowledgeResource> UpdateAsync(UpdateKnowledgeOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update knowledge </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Knowledge </returns>
        public static KnowledgeResource Update(
                                          string pathId,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateKnowledgeOptions(pathId){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update knowledge </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Knowledge </returns>
        public static async System.Threading.Tasks.Task<KnowledgeResource> UpdateAsync(
                                                                              string pathId,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateKnowledgeOptions(pathId){  };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a KnowledgeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> KnowledgeResource object represented by the provided JSON </returns>
        public static KnowledgeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<KnowledgeResource>(json);
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

    
        ///<summary> The type of knowledge source. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> The description of knowledge. </summary> 
        [JsonProperty("id")]
        public string Id { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Knowledge resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The details of the knowledge source based on the type. </summary> 
        [JsonProperty("knowledge_source_details")]
        public object KnowledgeSourceDetails { get; private set; }

        ///<summary> The name of the knowledge source. </summary> 
        [JsonProperty("name")]
        public string Name { get; }

        ///<summary> The status of processing the knowledge source ('QUEUED', 'PROCESSING', 'COMPLETED', 'FAILED') </summary> 
        [JsonProperty("status")]
        public string Status { get; private set; }

        ///<summary> The type of knowledge source ('Web', 'Database', 'Text', 'File') </summary> 
        [JsonProperty("type")]
        public string Type { get; }

        ///<summary> The url of the knowledge resource. </summary> 
        [JsonProperty("url")]
        public string Url { get; private set; }

        ///<summary> The embedding model to be used for the knowledge source. </summary> 
        [JsonProperty("embedding_model")]
        public string EmbeddingModel { get; private set; }

        ///<summary> The date and time in GMT when the Knowledge was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; }

        ///<summary> The date and time in GMT when the Knowledge was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; }



        private KnowledgeResource() {

        }
    }
}


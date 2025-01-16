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
    public class AssistantResource : Resource
    {
    
        public class AssistantsV1ServiceCustomerAi
        {
            [JsonProperty("perception_engine_enabled")]
            private bool? PerceptionEngineEnabled {get; set;}
            [JsonProperty("personalization_engine_enabled")]
            private bool? PersonalizationEngineEnabled {get; set;}
            public AssistantsV1ServiceCustomerAi() { }
            public class Builder
            {
                private AssistantsV1ServiceCustomerAi _assistantsV1ServiceCustomerAi = new AssistantsV1ServiceCustomerAi();
                public Builder()
                {
                }
                public Builder WithPerceptionEngineEnabled(bool? perceptionEngineEnabled)
                {
                    _assistantsV1ServiceCustomerAi.PerceptionEngineEnabled= perceptionEngineEnabled;
                    return this;
                }
                public Builder WithPersonalizationEngineEnabled(bool? personalizationEngineEnabled)
                {
                    _assistantsV1ServiceCustomerAi.PersonalizationEngineEnabled= personalizationEngineEnabled;
                    return this;
                }
                public AssistantsV1ServiceCustomerAi Build()
                {
                    return _assistantsV1ServiceCustomerAi;
                }
            }
        }
        public class AssistantsV1ServiceSegmentCredential
        {
            [JsonProperty("profile_api_key")]
            private string ProfileApiKey {get; set;}
            [JsonProperty("space_id")]
            private string SpaceId {get; set;}
            [JsonProperty("write_key")]
            private string WriteKey {get; set;}
            public AssistantsV1ServiceSegmentCredential() { }
            public class Builder
            {
                private AssistantsV1ServiceSegmentCredential _assistantsV1ServiceSegmentCredential = new AssistantsV1ServiceSegmentCredential();
                public Builder()
                {
                }
                public Builder WithProfileApiKey(string profileApiKey)
                {
                    _assistantsV1ServiceSegmentCredential.ProfileApiKey= profileApiKey;
                    return this;
                }
                public Builder WithSpaceId(string spaceId)
                {
                    _assistantsV1ServiceSegmentCredential.SpaceId= spaceId;
                    return this;
                }
                public Builder WithWriteKey(string writeKey)
                {
                    _assistantsV1ServiceSegmentCredential.WriteKey= writeKey;
                    return this;
                }
                public AssistantsV1ServiceSegmentCredential Build()
                {
                    return _assistantsV1ServiceSegmentCredential;
                }
            }
        }
        public class AssistantsV1ServiceCreateAssistantRequest
        {
            [JsonProperty("customer_ai")]
            private AssistantsV1ServiceCustomerAi CustomerAi {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("owner")]
            private string Owner {get; set;}
            [JsonProperty("personality_prompt")]
            private string PersonalityPrompt {get; set;}
            [JsonProperty("segment_credential")]
            private AssistantsV1ServiceSegmentCredential SegmentCredential {get; set;}
            public AssistantsV1ServiceCreateAssistantRequest() { }
            public class Builder
            {
                private AssistantsV1ServiceCreateAssistantRequest _assistantsV1ServiceCreateAssistantRequest = new AssistantsV1ServiceCreateAssistantRequest();
                public Builder()
                {
                }
                public Builder WithCustomerAi(AssistantsV1ServiceCustomerAi customerAi)
                {
                    _assistantsV1ServiceCreateAssistantRequest.CustomerAi= customerAi;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceCreateAssistantRequest.Name= name;
                    return this;
                }
                public Builder WithOwner(string owner)
                {
                    _assistantsV1ServiceCreateAssistantRequest.Owner= owner;
                    return this;
                }
                public Builder WithPersonalityPrompt(string personalityPrompt)
                {
                    _assistantsV1ServiceCreateAssistantRequest.PersonalityPrompt= personalityPrompt;
                    return this;
                }
                public Builder WithSegmentCredential(AssistantsV1ServiceSegmentCredential segmentCredential)
                {
                    _assistantsV1ServiceCreateAssistantRequest.SegmentCredential= segmentCredential;
                    return this;
                }
                public AssistantsV1ServiceCreateAssistantRequest Build()
                {
                    return _assistantsV1ServiceCreateAssistantRequest;
                }
            }
        }
        public class AssistantsV1ServiceUpdateAssistantRequest
        {
            [JsonProperty("customer_ai")]
            private AssistantsV1ServiceCustomerAi CustomerAi {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("owner")]
            private string Owner {get; set;}
            [JsonProperty("personality_prompt")]
            private string PersonalityPrompt {get; set;}
            [JsonProperty("segment_credential")]
            private AssistantsV1ServiceSegmentCredential SegmentCredential {get; set;}
            public AssistantsV1ServiceUpdateAssistantRequest() { }
            public class Builder
            {
                private AssistantsV1ServiceUpdateAssistantRequest _assistantsV1ServiceUpdateAssistantRequest = new AssistantsV1ServiceUpdateAssistantRequest();
                public Builder()
                {
                }
                public Builder WithCustomerAi(AssistantsV1ServiceCustomerAi customerAi)
                {
                    _assistantsV1ServiceUpdateAssistantRequest.CustomerAi= customerAi;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceUpdateAssistantRequest.Name= name;
                    return this;
                }
                public Builder WithOwner(string owner)
                {
                    _assistantsV1ServiceUpdateAssistantRequest.Owner= owner;
                    return this;
                }
                public Builder WithPersonalityPrompt(string personalityPrompt)
                {
                    _assistantsV1ServiceUpdateAssistantRequest.PersonalityPrompt= personalityPrompt;
                    return this;
                }
                public Builder WithSegmentCredential(AssistantsV1ServiceSegmentCredential segmentCredential)
                {
                    _assistantsV1ServiceUpdateAssistantRequest.SegmentCredential= segmentCredential;
                    return this;
                }
                public AssistantsV1ServiceUpdateAssistantRequest Build()
                {
                    return _assistantsV1ServiceUpdateAssistantRequest;
                }
            }
        }
        public class AssistantsV1ServiceKnowledge
        {
            [JsonProperty("description")]
            private string Description {get; set;}
            [JsonProperty("id")]
            private string Id {get; set;}
            [JsonProperty("account_sid")]
            private string AccountSid {get; set;}
            [JsonProperty("knowledge_source_details")]
            private object KnowledgeSourceDetails {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("status")]
            private string Status {get; set;}
            [JsonProperty("type")]
            private string Type {get; set;}
            [JsonProperty("url")]
            private string Url {get; set;}
            [JsonProperty("embedding_model")]
            private string EmbeddingModel {get; set;}
            [JsonProperty("date_created")]
            private DateTime? DateCreated {get; set;}
            [JsonProperty("date_updated")]
            private DateTime? DateUpdated {get; set;}
            public AssistantsV1ServiceKnowledge() { }
            public class Builder
            {
                private AssistantsV1ServiceKnowledge _assistantsV1ServiceKnowledge = new AssistantsV1ServiceKnowledge();
                public Builder()
                {
                }
                public Builder WithDescription(string description)
                {
                    _assistantsV1ServiceKnowledge.Description= description;
                    return this;
                }
                public Builder WithId(string id)
                {
                    _assistantsV1ServiceKnowledge.Id= id;
                    return this;
                }
                public Builder WithAccountSid(string accountSid)
                {
                    _assistantsV1ServiceKnowledge.AccountSid= accountSid;
                    return this;
                }
                public Builder WithKnowledgeSourceDetails(object knowledgeSourceDetails)
                {
                    _assistantsV1ServiceKnowledge.KnowledgeSourceDetails= knowledgeSourceDetails;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceKnowledge.Name= name;
                    return this;
                }
                public Builder WithStatus(string status)
                {
                    _assistantsV1ServiceKnowledge.Status= status;
                    return this;
                }
                public Builder WithType(string type)
                {
                    _assistantsV1ServiceKnowledge.Type= type;
                    return this;
                }
                public Builder WithUrl(string url)
                {
                    _assistantsV1ServiceKnowledge.Url= url;
                    return this;
                }
                public Builder WithEmbeddingModel(string embeddingModel)
                {
                    _assistantsV1ServiceKnowledge.EmbeddingModel= embeddingModel;
                    return this;
                }
                public Builder WithDateCreated(DateTime? dateCreated)
                {
                    _assistantsV1ServiceKnowledge.DateCreated= dateCreated;
                    return this;
                }
                public Builder WithDateUpdated(DateTime? dateUpdated)
                {
                    _assistantsV1ServiceKnowledge.DateUpdated= dateUpdated;
                    return this;
                }
                public AssistantsV1ServiceKnowledge Build()
                {
                    return _assistantsV1ServiceKnowledge;
                }
            }
        }
        public class AssistantsV1ServiceTool
        {
            [JsonProperty("account_sid")]
            private string AccountSid {get; set;}
            [JsonProperty("description")]
            private string Description {get; set;}
            [JsonProperty("enabled")]
            private bool? Enabled {get; set;}
            [JsonProperty("id")]
            private string Id {get; set;}
            [JsonProperty("meta")]
            private object Meta {get; set;}
            [JsonProperty("name")]
            private string Name {get; set;}
            [JsonProperty("requires_auth")]
            private bool? RequiresAuth {get; set;}
            [JsonProperty("type")]
            private string Type {get; set;}
            [JsonProperty("url")]
            private string Url {get; set;}
            [JsonProperty("date_created")]
            private DateTime? DateCreated {get; set;}
            [JsonProperty("date_updated")]
            private DateTime? DateUpdated {get; set;}
            public AssistantsV1ServiceTool() { }
            public class Builder
            {
                private AssistantsV1ServiceTool _assistantsV1ServiceTool = new AssistantsV1ServiceTool();
                public Builder()
                {
                }
                public Builder WithAccountSid(string accountSid)
                {
                    _assistantsV1ServiceTool.AccountSid= accountSid;
                    return this;
                }
                public Builder WithDescription(string description)
                {
                    _assistantsV1ServiceTool.Description= description;
                    return this;
                }
                public Builder WithEnabled(bool? enabled)
                {
                    _assistantsV1ServiceTool.Enabled= enabled;
                    return this;
                }
                public Builder WithId(string id)
                {
                    _assistantsV1ServiceTool.Id= id;
                    return this;
                }
                public Builder WithMeta(object meta)
                {
                    _assistantsV1ServiceTool.Meta= meta;
                    return this;
                }
                public Builder WithName(string name)
                {
                    _assistantsV1ServiceTool.Name= name;
                    return this;
                }
                public Builder WithRequiresAuth(bool? requiresAuth)
                {
                    _assistantsV1ServiceTool.RequiresAuth= requiresAuth;
                    return this;
                }
                public Builder WithType(string type)
                {
                    _assistantsV1ServiceTool.Type= type;
                    return this;
                }
                public Builder WithUrl(string url)
                {
                    _assistantsV1ServiceTool.Url= url;
                    return this;
                }
                public Builder WithDateCreated(DateTime? dateCreated)
                {
                    _assistantsV1ServiceTool.DateCreated= dateCreated;
                    return this;
                }
                public Builder WithDateUpdated(DateTime? dateUpdated)
                {
                    _assistantsV1ServiceTool.DateUpdated= dateUpdated;
                    return this;
                }
                public AssistantsV1ServiceTool Build()
                {
                    return _assistantsV1ServiceTool;
                }
            }
        }

    

        
        private static Request BuildCreateRequest(CreateAssistantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Assistants,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> create an assistant </summary>
        /// <param name="options"> Create Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Create(CreateAssistantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create an assistant </summary>
        /// <param name="options"> Create Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<AssistantResource> CreateAsync(CreateAssistantOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create an assistant </summary>
        /// <param name="assistantsV1ServiceCreateAssistantRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Create(
                                          AssistantResource.AssistantsV1ServiceCreateAssistantRequest assistantsV1ServiceCreateAssistantRequest,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateAssistantOptions(assistantsV1ServiceCreateAssistantRequest){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create an assistant </summary>
        /// <param name="assistantsV1ServiceCreateAssistantRequest">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<AssistantResource> CreateAsync(
                                                                                  AssistantResource.AssistantsV1ServiceCreateAssistantRequest assistantsV1ServiceCreateAssistantRequest,
                                                                                    ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreateAssistantOptions(assistantsV1ServiceCreateAssistantRequest){  };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
        
        /// <summary> delete an assistant </summary>
        /// <param name="options"> Delete Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        private static Request BuildDeleteRequest(DeleteAssistantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"Id"+"}", PathId);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete an assistant </summary>
        /// <param name="options"> Delete Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static bool Delete(DeleteAssistantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete an assistant </summary>
        /// <param name="options"> Delete Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteAssistantOptions options, 
                                                                        ITwilioRestClient client = null,
                                                                        System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client), cancellationToken);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static bool Delete(string pathId, ITwilioRestClient client = null)
        {
            var options = new DeleteAssistantOptions(pathId)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathId, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new DeleteAssistantOptions(pathId) ;
            return await DeleteAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchAssistantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"Id"+"}", PathId);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> get an assistant </summary>
        /// <param name="options"> Fetch Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Fetch(FetchAssistantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> get an assistant </summary>
        /// <param name="options"> Fetch Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<AssistantResource> FetchAsync(FetchAssistantOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif
        /// <summary> get an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Fetch(
                                         string pathId, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchAssistantOptions(pathId){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> get an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<AssistantResource> FetchAsync(string pathId, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new FetchAssistantOptions(pathId){  };
            return await FetchAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildReadRequest(ReadAssistantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Assistants,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> list assistants </summary>
        /// <param name="options"> Read Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static ResourceSet<AssistantResource> Read(ReadAssistantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<AssistantResource>.FromJson("assistants", response.Content);
            return new ResourceSet<AssistantResource>(page, options, client);
        }

        #if !NET35
        /// <summary> list assistants </summary>
        /// <param name="options"> Read Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssistantResource>> ReadAsync(ReadAssistantOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client), cancellationToken);

            var page = Page<AssistantResource>.FromJson("assistants", response.Content);
            return new ResourceSet<AssistantResource>(page, options, client);
        }
        #endif
        /// <summary> list assistants </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static ResourceSet<AssistantResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadAssistantOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> list assistants </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssistantResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new ReadAssistantOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client, cancellationToken);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<AssistantResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AssistantResource>.FromJson("assistants", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<AssistantResource> NextPage(Page<AssistantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssistantResource>.FromJson("assistants", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<AssistantResource> PreviousPage(Page<AssistantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssistantResource>.FromJson("assistants", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateAssistantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{id}";

            string PathId = options.PathId;
            path = path.Replace("{"+"Id"+"}", PathId);

            return new Request(
                HttpMethod.Put,
                Rest.Domain.Assistants,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> update an assistant </summary>
        /// <param name="options"> Update Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Update(UpdateAssistantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update an assistant </summary>
        /// <param name="options"> Update Assistant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<AssistantResource> UpdateAsync(UpdateAssistantOptions options, 
                                                                                                    ITwilioRestClient client = null,
                                                                                                    System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Assistant </returns>
        public static AssistantResource Update(
                                          string pathId,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateAssistantOptions(pathId){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update an assistant </summary>
        /// <param name="pathId">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Assistant </returns>
        public static async System.Threading.Tasks.Task<AssistantResource> UpdateAsync(
                                                                              string pathId,
                                                                                ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new UpdateAssistantOptions(pathId){  };
            return await UpdateAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AssistantResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AssistantResource object represented by the provided JSON </returns>
        public static AssistantResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AssistantResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Assistant resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; }

        ///<summary> The Personalization and Perception Engine settings. </summary> 
        [JsonProperty("customer_ai")]
        public object CustomerAi { get; }

        ///<summary> The Assistant ID. </summary> 
        [JsonProperty("id")]
        public string Id { get; }

        ///<summary> The default model used by the assistant. </summary> 
        [JsonProperty("model")]
        public string Model { get; }

        ///<summary> The name of the assistant. </summary> 
        [JsonProperty("name")]
        public string Name { get; }

        ///<summary> The owner/company of the assistant. </summary> 
        [JsonProperty("owner")]
        public string Owner { get; }

        ///<summary> The url of the assistant resource. </summary> 
        [JsonProperty("url")]
        public string Url { get; private set; }

        ///<summary> The personality prompt to be used for assistant. </summary> 
        [JsonProperty("personality_prompt")]
        public string PersonalityPrompt { get; }

        ///<summary> The date and time in GMT when the Assistant was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; }

        ///<summary> The date and time in GMT when the Assistant was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; }

        ///<summary> The list of knowledge sources associated with the assistant. </summary> 
        [JsonProperty("knowledge")]
        public List<AssistantsV1ServiceKnowledge> Knowledge { get; }

        ///<summary> The list of tools associated with the assistant. </summary> 
        [JsonProperty("tools")]
        public List<AssistantsV1ServiceTool> Tools { get; }



        private AssistantResource() {

        }
    }
}


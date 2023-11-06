/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Intelligence
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


namespace Twilio.Rest.Intelligence.V2.Transcript
{
    public class OperatorResultResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class OperatorTypeEnum : StringEnum
        {
            private OperatorTypeEnum(string value) : base(value) {}
            public OperatorTypeEnum() {}
            public static implicit operator OperatorTypeEnum(string value)
            {
                return new OperatorTypeEnum(value);
            }
            public static readonly OperatorTypeEnum ConversationClassify = new OperatorTypeEnum("conversation_classify");
            public static readonly OperatorTypeEnum UtteranceClassify = new OperatorTypeEnum("utterance_classify");
            public static readonly OperatorTypeEnum Extract = new OperatorTypeEnum("extract");
            public static readonly OperatorTypeEnum ExtractNormalize = new OperatorTypeEnum("extract_normalize");
            public static readonly OperatorTypeEnum PiiExtract = new OperatorTypeEnum("pii_extract");

        }

        
        private static Request BuildFetchRequest(FetchOperatorResultOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Transcripts/{TranscriptSid}/OperatorResults/{OperatorSid}";

            string PathTranscriptSid = options.PathTranscriptSid;
            path = path.Replace("{"+"TranscriptSid"+"}", PathTranscriptSid);
            string PathOperatorSid = options.PathOperatorSid;
            path = path.Replace("{"+"OperatorSid"+"}", PathOperatorSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Operator Result for the given Transcript. </summary>
        /// <param name="options"> Fetch OperatorResult parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorResult </returns>
        public static OperatorResultResource Fetch(FetchOperatorResultOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Operator Result for the given Transcript. </summary>
        /// <param name="options"> Fetch OperatorResult parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorResult </returns>
        public static async System.Threading.Tasks.Task<OperatorResultResource> FetchAsync(FetchOperatorResultOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Operator Result for the given Transcript. </summary>
        /// <param name="pathTranscriptSid"> A 34 character string that uniquely identifies this Transcript. </param>
        /// <param name="pathOperatorSid"> A 34 character string that identifies this Language Understanding operator sid. </param>
        /// <param name="redacted"> Grant access to PII redacted/unredacted Language Understanding operator. If redaction is enabled, the default is True. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorResult </returns>
        public static OperatorResultResource Fetch(
                                         string pathTranscriptSid, 
                                         string pathOperatorSid, 
                                         bool? redacted = null, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchOperatorResultOptions(pathTranscriptSid, pathOperatorSid){ Redacted = redacted };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Operator Result for the given Transcript. </summary>
        /// <param name="pathTranscriptSid"> A 34 character string that uniquely identifies this Transcript. </param>
        /// <param name="pathOperatorSid"> A 34 character string that identifies this Language Understanding operator sid. </param>
        /// <param name="redacted"> Grant access to PII redacted/unredacted Language Understanding operator. If redaction is enabled, the default is True. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorResult </returns>
        public static async System.Threading.Tasks.Task<OperatorResultResource> FetchAsync(string pathTranscriptSid, string pathOperatorSid, bool? redacted = null, ITwilioRestClient client = null)
        {
            var options = new FetchOperatorResultOptions(pathTranscriptSid, pathOperatorSid){ Redacted = redacted };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadOperatorResultOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Transcripts/{TranscriptSid}/OperatorResults";

            string PathTranscriptSid = options.PathTranscriptSid;
            path = path.Replace("{"+"TranscriptSid"+"}", PathTranscriptSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of Operator Results for the given Transcript. </summary>
        /// <param name="options"> Read OperatorResult parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorResult </returns>
        public static ResourceSet<OperatorResultResource> Read(ReadOperatorResultOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<OperatorResultResource>.FromJson("operator_results", response.Content);
            return new ResourceSet<OperatorResultResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Operator Results for the given Transcript. </summary>
        /// <param name="options"> Read OperatorResult parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorResult </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OperatorResultResource>> ReadAsync(ReadOperatorResultOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<OperatorResultResource>.FromJson("operator_results", response.Content);
            return new ResourceSet<OperatorResultResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of Operator Results for the given Transcript. </summary>
        /// <param name="pathTranscriptSid"> A 34 character string that uniquely identifies this Transcript. </param>
        /// <param name="redacted"> Grant access to PII redacted/unredacted Language Understanding operator. If redaction is enabled, the default is True. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorResult </returns>
        public static ResourceSet<OperatorResultResource> Read(
                                                     string pathTranscriptSid,
                                                     bool? redacted = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadOperatorResultOptions(pathTranscriptSid){ Redacted = redacted, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Operator Results for the given Transcript. </summary>
        /// <param name="pathTranscriptSid"> A 34 character string that uniquely identifies this Transcript. </param>
        /// <param name="redacted"> Grant access to PII redacted/unredacted Language Understanding operator. If redaction is enabled, the default is True. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorResult </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OperatorResultResource>> ReadAsync(
                                                                                             string pathTranscriptSid,
                                                                                             bool? redacted = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadOperatorResultOptions(pathTranscriptSid){ Redacted = redacted, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<OperatorResultResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<OperatorResultResource>.FromJson("operator_results", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<OperatorResultResource> NextPage(Page<OperatorResultResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OperatorResultResource>.FromJson("operator_results", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<OperatorResultResource> PreviousPage(Page<OperatorResultResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OperatorResultResource>.FromJson("operator_results", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a OperatorResultResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OperatorResultResource object represented by the provided JSON </returns>
        public static OperatorResultResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<OperatorResultResource>(json);
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

    
        
        [JsonProperty("operator_type")]
        public OperatorResultResource.OperatorTypeEnum OperatorType { get; private set; }

        ///<summary> The name of the applied Language Understanding. </summary> 
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///<summary> A 34 character string that identifies this Language Understanding operator sid. </summary> 
        [JsonProperty("operator_sid")]
        public string OperatorSid { get; private set; }

        ///<summary> Boolean to tell if extract Language Understanding Processing model matches results. </summary> 
        [JsonProperty("extract_match")]
        public bool? ExtractMatch { get; private set; }

        ///<summary> Percentage of 'matching' class needed to consider a sentence matches </summary> 
        [JsonProperty("match_probability")]
        public decimal? MatchProbability { get; private set; }

        ///<summary> Normalized output of extraction stage which matches Label. </summary> 
        [JsonProperty("normalized_result")]
        public string NormalizedResult { get; private set; }

        ///<summary> List of mapped utterance object which matches sentences. </summary> 
        [JsonProperty("utterance_results")]
        public List<object> UtteranceResults { get; private set; }

        ///<summary> Boolean to tell if Utterance matches results. </summary> 
        [JsonProperty("utterance_match")]
        public bool? UtteranceMatch { get; private set; }

        ///<summary> The 'matching' class. This might be available on conversation classify model outputs. </summary> 
        [JsonProperty("predicted_label")]
        public string PredictedLabel { get; private set; }

        ///<summary> Percentage of 'matching' class needed to consider a sentence matches. </summary> 
        [JsonProperty("predicted_probability")]
        public decimal? PredictedProbability { get; private set; }

        ///<summary> The labels probabilities. This might be available on conversation classify model outputs. </summary> 
        [JsonProperty("label_probabilities")]
        public object LabelProbabilities { get; private set; }

        ///<summary> List of text extraction results. This might be available on classify-extract model outputs. </summary> 
        [JsonProperty("extract_results")]
        public object ExtractResults { get; private set; }

        ///<summary> Output of a text generation operator for example Conversation Sumamary. </summary> 
        [JsonProperty("text_generation_results")]
        public object TextGenerationResults { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this Transcript. </summary> 
        [JsonProperty("transcript_sid")]
        public string TranscriptSid { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private OperatorResultResource() {

        }
    }
}


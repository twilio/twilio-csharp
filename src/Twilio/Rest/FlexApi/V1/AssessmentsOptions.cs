/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.FlexApi.V1
{

    /// <summary> Add assessments against conversation to dynamo db. Used in assessments screen by user. Users can select the questionnaire and pick up answers for each and every question. </summary>
    public class CreateAssessmentsOptions : IOptions<AssessmentsResource>
    {
        
        ///<summary> The SID of the category  </summary> 
        public string CategorySid { get; }

        ///<summary> The name of the category </summary> 
        public string CategoryName { get; }

        ///<summary> Segment Id of the conversation </summary> 
        public string SegmentId { get; }

        ///<summary> The id of the Agent </summary> 
        public string AgentId { get; }

        ///<summary> The offset of the conversation. </summary> 
        public decimal? Offset { get; }

        ///<summary> The question SID selected for assessment </summary> 
        public string MetricId { get; }

        ///<summary> The question name of the assessment </summary> 
        public string MetricName { get; }

        ///<summary> The answer text selected by user </summary> 
        public string AnswerText { get; }

        ///<summary> The id of the answer selected by user </summary> 
        public string AnswerId { get; }

        ///<summary> Questionnaire SID of the associated question </summary> 
        public string QuestionnaireSid { get; }

        ///<summary> The Authorization HTTP request header </summary> 
        public string Authorization { get; set; }


        /// <summary> Construct a new CreateInsightsAssessmentsOptions </summary>
        /// <param name="categorySid"> The SID of the category  </param>
        /// <param name="categoryName"> The name of the category </param>
        /// <param name="segmentId"> Segment Id of the conversation </param>
        /// <param name="agentId"> The id of the Agent </param>
        /// <param name="offset"> The offset of the conversation. </param>
        /// <param name="metricId"> The question SID selected for assessment </param>
        /// <param name="metricName"> The question name of the assessment </param>
        /// <param name="answerText"> The answer text selected by user </param>
        /// <param name="answerId"> The id of the answer selected by user </param>
        /// <param name="questionnaireSid"> Questionnaire SID of the associated question </param>
        public CreateAssessmentsOptions(string categorySid, string categoryName, string segmentId, string agentId, decimal? offset, string metricId, string metricName, string answerText, string answerId, string questionnaireSid)
        {
            CategorySid = categorySid;
            CategoryName = categoryName;
            SegmentId = segmentId;
            AgentId = agentId;
            Offset = offset;
            MetricId = metricId;
            MetricName = metricName;
            AnswerText = answerText;
            AnswerId = answerId;
            QuestionnaireSid = questionnaireSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (CategorySid != null)
            {
                p.Add(new KeyValuePair<string, string>("CategorySid", CategorySid));
            }
            if (CategoryName != null)
            {
                p.Add(new KeyValuePair<string, string>("CategoryName", CategoryName));
            }
            if (SegmentId != null)
            {
                p.Add(new KeyValuePair<string, string>("SegmentId", SegmentId));
            }
            if (AgentId != null)
            {
                p.Add(new KeyValuePair<string, string>("AgentId", AgentId));
            }
            if (Offset != null)
            {
                p.Add(new KeyValuePair<string, string>("Offset", Offset.Value.ToString()));
            }
            if (MetricId != null)
            {
                p.Add(new KeyValuePair<string, string>("MetricId", MetricId));
            }
            if (MetricName != null)
            {
                p.Add(new KeyValuePair<string, string>("MetricName", MetricName));
            }
            if (AnswerText != null)
            {
                p.Add(new KeyValuePair<string, string>("AnswerText", AnswerText));
            }
            if (AnswerId != null)
            {
                p.Add(new KeyValuePair<string, string>("AnswerId", AnswerId));
            }
            if (QuestionnaireSid != null)
            {
                p.Add(new KeyValuePair<string, string>("QuestionnaireSid", QuestionnaireSid));
            }
            return p;
        }

        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (Authorization != null)
        {
            p.Add(new KeyValuePair<string, string>("Authorization", Authorization));
        }
        return p;
    }

    }
    /// <summary> Get assessments done for a conversation by logged in user </summary>
    public class ReadAssessmentsOptions : ReadOptions<AssessmentsResource>
    {
    
        ///<summary> The Authorization HTTP request header </summary> 
        public string Authorization { get; set; }

        ///<summary> The id of the segment. </summary> 
        public string SegmentId { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (SegmentId != null)
            {
                p.Add(new KeyValuePair<string, string>("SegmentId", SegmentId));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (Authorization != null)
        {
            p.Add(new KeyValuePair<string, string>("Authorization", Authorization));
        }
        return p;
    }

    }

    /// <summary> Update a specific Assessment assessed earlier </summary>
    public class UpdateAssessmentsOptions : IOptions<AssessmentsResource>
    {
    
        ///<summary> The SID of the assessment to be modified </summary> 
        public string PathAssessmentSid { get; }

        ///<summary> The offset of the conversation </summary> 
        public decimal? Offset { get; }

        ///<summary> The answer text selected by user </summary> 
        public string AnswerText { get; }

        ///<summary> The id of the answer selected by user </summary> 
        public string AnswerId { get; }

        ///<summary> The Authorization HTTP request header </summary> 
        public string Authorization { get; set; }



        /// <summary> Construct a new UpdateInsightsAssessmentsOptions </summary>
        /// <param name="pathAssessmentSid"> The SID of the assessment to be modified </param>
        /// <param name="offset"> The offset of the conversation </param>
        /// <param name="answerText"> The answer text selected by user </param>
        /// <param name="answerId"> The id of the answer selected by user </param>
        public UpdateAssessmentsOptions(string pathAssessmentSid, decimal? offset, string answerText, string answerId)
        {
            PathAssessmentSid = pathAssessmentSid;
            Offset = offset;
            AnswerText = answerText;
            AnswerId = answerId;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Offset != null)
            {
                p.Add(new KeyValuePair<string, string>("Offset", Offset.Value.ToString()));
            }
            if (AnswerText != null)
            {
                p.Add(new KeyValuePair<string, string>("AnswerText", AnswerText));
            }
            if (AnswerId != null)
            {
                p.Add(new KeyValuePair<string, string>("AnswerId", AnswerId));
            }
            return p;
        }

        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (Authorization != null)
        {
            p.Add(new KeyValuePair<string, string>("Authorization", Authorization));
        }
        return p;
    }

    }


}


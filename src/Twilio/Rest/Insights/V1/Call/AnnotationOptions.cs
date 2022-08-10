/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Insights.V1.Call
{

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Create/Update the annotation for the call
    /// </summary>
    public class UpdateAnnotationOptions : IOptions<AnnotationResource>
    {
        /// <summary>
        /// The SID of the call.
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// Indicates the answering entity as determined by Answering Machine Detection.
        /// </summary>
        public AnnotationResource.AnsweredByEnum AnsweredBy { get; set; }
        /// <summary>
        /// Indicates if the call had any connectivity issue
        /// </summary>
        public AnnotationResource.ConnectivityIssueEnum ConnectivityIssue { get; set; }
        /// <summary>
        /// Indicates if the call had audio quality issues.
        /// </summary>
        public string QualityIssues { get; set; }
        /// <summary>
        /// Call spam indicator
        /// </summary>
        public bool? Spam { get; set; }
        /// <summary>
        /// Call Score
        /// </summary>
        public int? CallScore { get; set; }
        /// <summary>
        /// User comments
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Call tag for incidents or support ticket
        /// </summary>
        public string Incident { get; set; }

        /// <summary>
        /// Construct a new UpdateAnnotationOptions
        /// </summary>
        /// <param name="pathCallSid"> The SID of the call. </param>
        public UpdateAnnotationOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (AnsweredBy != null)
            {
                p.Add(new KeyValuePair<string, string>("AnsweredBy", AnsweredBy.ToString()));
            }

            if (ConnectivityIssue != null)
            {
                p.Add(new KeyValuePair<string, string>("ConnectivityIssue", ConnectivityIssue.ToString()));
            }

            if (QualityIssues != null)
            {
                p.Add(new KeyValuePair<string, string>("QualityIssues", QualityIssues));
            }

            if (Spam != null)
            {
                p.Add(new KeyValuePair<string, string>("Spam", Spam.Value.ToString().ToLower()));
            }

            if (CallScore != null)
            {
                p.Add(new KeyValuePair<string, string>("CallScore", CallScore.ToString()));
            }

            if (Comment != null)
            {
                p.Add(new KeyValuePair<string, string>("Comment", Comment));
            }

            if (Incident != null)
            {
                p.Add(new KeyValuePair<string, string>("Incident", Incident));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Fetch a specific Annotation.
    /// </summary>
    public class FetchAnnotationOptions : IOptions<AnnotationResource>
    {
        /// <summary>
        /// Call SID.
        /// </summary>
        public string PathCallSid { get; }

        /// <summary>
        /// Construct a new FetchAnnotationOptions
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        public FetchAnnotationOptions(string pathCallSid)
        {
            PathCallSid = pathCallSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

}
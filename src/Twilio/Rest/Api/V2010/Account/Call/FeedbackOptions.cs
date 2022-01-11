/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Call
{

  /// <summary>
  /// Fetch a Feedback resource from a call
  /// </summary>
  public class FetchFeedbackOptions : IOptions<FeedbackResource>
  {
    /// <summary>
    /// The unique sid that identifies this account
    /// </summary>
    public string PathAccountSid { get; set; }
    /// <summary>
    /// The call sid that uniquely identifies the call
    /// </summary>
    public string PathCallSid { get; }

    /// <summary>
    /// Construct a new FetchFeedbackOptions
    /// </summary>
    /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
    public FetchFeedbackOptions(string pathCallSid)
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

  /// <summary>
  /// Create a Feedback resource for a call
  /// </summary>
  public class CreateFeedbackOptions : IOptions<FeedbackResource>
  {
    /// <summary>
    /// The unique sid that identifies this account
    /// </summary>
    public string PathAccountSid { get; set; }
    /// <summary>
    /// The call sid that uniquely identifies the call
    /// </summary>
    public string PathCallSid { get; }
    /// <summary>
    /// The call quality expressed as an integer from 1 to 5
    /// </summary>
    public int? QualityScore { get; }
    /// <summary>
    /// Issues experienced during the call
    /// </summary>
    public List<FeedbackResource.IssuesEnum> Issue { get; set; }

    /// <summary>
    /// Construct a new CreateFeedbackOptions
    /// </summary>
    /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
    /// <param name="qualityScore"> The call quality expressed as an integer from 1 to 5 </param>
    public CreateFeedbackOptions(string pathCallSid, int? qualityScore)
    {
      PathCallSid = pathCallSid;
      QualityScore = qualityScore;
      Issue = new List<FeedbackResource.IssuesEnum>();
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (QualityScore != null)
      {
        p.Add(new KeyValuePair<string, string>("QualityScore", QualityScore.ToString()));
      }

      if (Issue != null)
      {
        p.AddRange(Issue.Select(prop => new KeyValuePair<string, string>("Issue", prop.ToString())));
      }

      return p;
    }
  }

  /// <summary>
  /// Update a Feedback resource for a call
  /// </summary>
  public class UpdateFeedbackOptions : IOptions<FeedbackResource>
  {
    /// <summary>
    /// The unique sid that identifies this account
    /// </summary>
    public string PathAccountSid { get; set; }
    /// <summary>
    /// The call sid that uniquely identifies the call
    /// </summary>
    public string PathCallSid { get; }
    /// <summary>
    /// The call quality expressed as an integer from 1 to 5
    /// </summary>
    public int? QualityScore { get; set; }
    /// <summary>
    /// Issues experienced during the call
    /// </summary>
    public List<FeedbackResource.IssuesEnum> Issue { get; set; }

    /// <summary>
    /// Construct a new UpdateFeedbackOptions
    /// </summary>
    /// <param name="pathCallSid"> The call sid that uniquely identifies the call </param>
    public UpdateFeedbackOptions(string pathCallSid)
    {
      PathCallSid = pathCallSid;
      Issue = new List<FeedbackResource.IssuesEnum>();
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (QualityScore != null)
      {
        p.Add(new KeyValuePair<string, string>("QualityScore", QualityScore.ToString()));
      }

      if (Issue != null)
      {
        p.AddRange(Issue.Select(prop => new KeyValuePair<string, string>("Issue", prop.ToString())));
      }

      return p;
    }
  }

}
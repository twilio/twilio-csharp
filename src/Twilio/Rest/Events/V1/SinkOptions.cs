/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Events.V1
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Fetch a specific Sink.
  /// </summary>
  public class FetchSinkOptions : IOptions<SinkResource>
  {
    /// <summary>
    /// A string that uniquely identifies this Sink.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchSinkOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies this Sink. </param>
    public FetchSinkOptions(string pathSid)
    {
      PathSid = pathSid;
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
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Create a new Sink
  /// </summary>
  public class CreateSinkOptions : IOptions<SinkResource>
  {
    /// <summary>
    /// Sink Description.
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// JSON Sink configuration.
    /// </summary>
    public object SinkConfiguration { get; }
    /// <summary>
    /// Sink type.
    /// </summary>
    public SinkResource.SinkTypeEnum SinkType { get; }

    /// <summary>
    /// Construct a new CreateSinkOptions
    /// </summary>
    /// <param name="description"> Sink Description. </param>
    /// <param name="sinkConfiguration"> JSON Sink configuration. </param>
    /// <param name="sinkType"> Sink type. </param>
    public CreateSinkOptions(string description, object sinkConfiguration, SinkResource.SinkTypeEnum sinkType)
    {
      Description = description;
      SinkConfiguration = sinkConfiguration;
      SinkType = sinkType;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Description != null)
      {
        p.Add(new KeyValuePair<string, string>("Description", Description));
      }

      if (SinkConfiguration != null)
      {
        p.Add(new KeyValuePair<string, string>("SinkConfiguration", Serializers.JsonObject(SinkConfiguration)));
      }

      if (SinkType != null)
      {
        p.Add(new KeyValuePair<string, string>("SinkType", SinkType.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Delete a specific Sink.
  /// </summary>
  public class DeleteSinkOptions : IOptions<SinkResource>
  {
    /// <summary>
    /// A string that uniquely identifies this Sink.
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteSinkOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies this Sink. </param>
    public DeleteSinkOptions(string pathSid)
    {
      PathSid = pathSid;
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
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Retrieve a paginated list of Sinks belonging to the account used to make the request.
  /// </summary>
  public class ReadSinkOptions : ReadOptions<SinkResource>
  {
    /// <summary>
    /// A boolean to return sinks used/not used by a subscription.
    /// </summary>
    public bool? InUse { get; set; }
    /// <summary>
    /// A string to filter sinks by status.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public override List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (InUse != null)
      {
        p.Add(new KeyValuePair<string, string>("InUse", InUse.Value.ToString().ToLower()));
      }

      if (Status != null)
      {
        p.Add(new KeyValuePair<string, string>("Status", Status));
      }

      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Update a specific Sink
  /// </summary>
  public class UpdateSinkOptions : IOptions<SinkResource>
  {
    /// <summary>
    /// A string that uniquely identifies this Sink.
    /// </summary>
    public string PathSid { get; }
    /// <summary>
    /// Sink Description
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Construct a new UpdateSinkOptions
    /// </summary>
    /// <param name="pathSid"> A string that uniquely identifies this Sink. </param>
    /// <param name="description"> Sink Description </param>
    public UpdateSinkOptions(string pathSid, string description)
    {
      PathSid = pathSid;
      Description = description;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (Description != null)
      {
        p.Add(new KeyValuePair<string, string>("Description", Description));
      }

      return p;
    }
  }

}
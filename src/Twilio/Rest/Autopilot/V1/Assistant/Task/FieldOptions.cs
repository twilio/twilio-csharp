/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Autopilot.V1.Assistant.Task
{

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// FetchFieldOptions
  /// </summary>
  public class FetchFieldOptions : IOptions<FieldResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the Task associated with the resource to fetch
    /// </summary>
    public string PathAssistantSid { get; }
    /// <summary>
    /// The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource associated with the Field resource to fetch
    /// </summary>
    public string PathTaskSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new FetchFieldOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the Task associated with the
    ///                        resource to fetch </param>
    /// <param name="pathTaskSid"> The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource
    ///                   associated with the Field resource to fetch </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public FetchFieldOptions(string pathAssistantSid, string pathTaskSid, string pathSid)
    {
      PathAssistantSid = pathAssistantSid;
      PathTaskSid = pathTaskSid;
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
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// ReadFieldOptions
  /// </summary>
  public class ReadFieldOptions : ReadOptions<FieldResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the Task associated with the resources to read.
    /// </summary>
    public string PathAssistantSid { get; }
    /// <summary>
    /// The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource associated with the Field resources to read
    /// </summary>
    public string PathTaskSid { get; }

    /// <summary>
    /// Construct a new ReadFieldOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the Task associated with the
    ///                        resources to read. </param>
    /// <param name="pathTaskSid"> The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource
    ///                   associated with the Field resources to read </param>
    public ReadFieldOptions(string pathAssistantSid, string pathTaskSid)
    {
      PathAssistantSid = pathAssistantSid;
      PathTaskSid = pathTaskSid;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public override List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (PageSize != null)
      {
        p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// CreateFieldOptions
  /// </summary>
  public class CreateFieldOptions : IOptions<FieldResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the Task associated with the new resource
    /// </summary>
    public string PathAssistantSid { get; }
    /// <summary>
    /// The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource associated with the new Field resource
    /// </summary>
    public string PathTaskSid { get; }
    /// <summary>
    /// The Field Type of this field
    /// </summary>
    public string FieldType { get; }
    /// <summary>
    /// An application-defined string that uniquely identifies the new resource
    /// </summary>
    public string UniqueName { get; }

    /// <summary>
    /// Construct a new CreateFieldOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the Task associated with the new
    ///                        resource </param>
    /// <param name="pathTaskSid"> The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource
    ///                   associated with the new Field resource </param>
    /// <param name="fieldType"> The Field Type of this field </param>
    /// <param name="uniqueName"> An application-defined string that uniquely identifies the new resource </param>
    public CreateFieldOptions(string pathAssistantSid, string pathTaskSid, string fieldType, string uniqueName)
    {
      PathAssistantSid = pathAssistantSid;
      PathTaskSid = pathTaskSid;
      FieldType = fieldType;
      UniqueName = uniqueName;
    }

    /// <summary>
    /// Generate the necessary parameters
    /// </summary>
    public List<KeyValuePair<string, string>> GetParams()
    {
      var p = new List<KeyValuePair<string, string>>();
      if (FieldType != null)
      {
        p.Add(new KeyValuePair<string, string>("FieldType", FieldType));
      }

      if (UniqueName != null)
      {
        p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
      }

      return p;
    }
  }

  /// <summary>
  /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
  /// currently do not have developer preview access, please contact help@twilio.com.
  ///
  /// DeleteFieldOptions
  /// </summary>
  public class DeleteFieldOptions : IOptions<FieldResource>
  {
    /// <summary>
    /// The SID of the Assistant that is the parent of the Task associated with the resources to delete
    /// </summary>
    public string PathAssistantSid { get; }
    /// <summary>
    /// The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource associated with the Field resource to delete
    /// </summary>
    public string PathTaskSid { get; }
    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    public string PathSid { get; }

    /// <summary>
    /// Construct a new DeleteFieldOptions
    /// </summary>
    /// <param name="pathAssistantSid"> The SID of the Assistant that is the parent of the Task associated with the
    ///                        resources to delete </param>
    /// <param name="pathTaskSid"> The SID of the [Task](https://www.twilio.com/docs/autopilot/api/task) resource
    ///                   associated with the Field resource to delete </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    public DeleteFieldOptions(string pathAssistantSid, string pathTaskSid, string pathSid)
    {
      PathAssistantSid = pathAssistantSid;
      PathTaskSid = pathTaskSid;
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

}
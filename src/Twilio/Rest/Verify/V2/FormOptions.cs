/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Verify.V2
{

  /// <summary>
  /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
  ///
  /// Fetch the forms for a specific Form Type.
  /// </summary>
  public class FetchFormOptions : IOptions<FormResource>
  {
    /// <summary>
    /// The Type of this Form
    /// </summary>
    public FormResource.FormTypesEnum PathFormType { get; }

    /// <summary>
    /// Construct a new FetchFormOptions
    /// </summary>
    /// <param name="pathFormType"> The Type of this Form </param>
    public FetchFormOptions(FormResource.FormTypesEnum pathFormType)
    {
      PathFormType = pathFormType;
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
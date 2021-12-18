/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
/// ChannelResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.TrustedComms.BrandedChannel
{

  public class ChannelResource : Resource
  {
    private static Request BuildCreateRequest(CreateChannelOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Preview,
          "/TrustedComms/BrandedChannels/" + options.PathBrandedChannelSid + "/Channels",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Associate a channel to a branded channel
    /// </summary>
    /// <param name="options"> Create Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Create(CreateChannelOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Associate a channel to a branded channel
    /// </summary>
    /// <param name="options"> Create Channel parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(CreateChannelOptions options,
                                                                                 ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Associate a channel to a branded channel
    /// </summary>
    /// <param name="pathBrandedChannelSid"> Branded Channel Sid. </param>
    /// <param name="phoneNumberSid"> Phone Number Sid to be branded. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Channel </returns>
    public static ChannelResource Create(string pathBrandedChannelSid,
                                         string phoneNumberSid,
                                         ITwilioRestClient client = null)
    {
      var options = new CreateChannelOptions(pathBrandedChannelSid, phoneNumberSid);
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// Associate a channel to a branded channel
    /// </summary>
    /// <param name="pathBrandedChannelSid"> Branded Channel Sid. </param>
    /// <param name="phoneNumberSid"> Phone Number Sid to be branded. </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Channel </returns>
    public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(string pathBrandedChannelSid,
                                                                                 string phoneNumberSid,
                                                                                 ITwilioRestClient client = null)
    {
      var options = new CreateChannelOptions(pathBrandedChannelSid, phoneNumberSid);
      return await CreateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a ChannelResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> ChannelResource object represented by the provided JSON </returns>
    public static ChannelResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<ChannelResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// Account Sid.
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// Business Sid.
    /// </summary>
    [JsonProperty("business_sid")]
    public string BusinessSid { get; private set; }
    /// <summary>
    /// Brand Sid.
    /// </summary>
    [JsonProperty("brand_sid")]
    public string BrandSid { get; private set; }
    /// <summary>
    /// Branded Channel Sid.
    /// </summary>
    [JsonProperty("branded_channel_sid")]
    public string BrandedChannelSid { get; private set; }
    /// <summary>
    /// Phone Number Sid to be branded.
    /// </summary>
    [JsonProperty("phone_number_sid")]
    public string PhoneNumberSid { get; private set; }
    /// <summary>
    /// Twilio number to assign to the Branded Channel
    /// </summary>
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; private set; }
    /// <summary>
    /// The URL of this resource.
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }

    private ChannelResource()
    {

    }
  }

}
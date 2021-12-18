/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
///
/// PhoneNumberResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Proxy.V1.Service
{

  public class PhoneNumberResource : Resource
  {
    private static Request BuildCreateRequest(CreatePhoneNumberOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Proxy,
          "/v1/Services/" + options.PathServiceSid + "/PhoneNumbers",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Add a Phone Number to a Service's Proxy Number Pool.
    /// </summary>
    /// <param name="options"> Create PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Create(CreatePhoneNumberOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Add a Phone Number to a Service's Proxy Number Pool.
    /// </summary>
    /// <param name="options"> Create PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(CreatePhoneNumberOptions options,
                                                                                     ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Add a Phone Number to a Service's Proxy Number Pool.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the resource's parent Service </param>
    /// <param name="sid"> The SID of a Twilio IncomingPhoneNumber resource </param>
    /// <param name="phoneNumber"> The phone number in E.164 format </param>
    /// <param name="isReserved"> Whether the new phone number should be reserved </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Create(string pathServiceSid,
                                             string sid = null,
                                             Types.PhoneNumber phoneNumber = null,
                                             bool? isReserved = null,
                                             ITwilioRestClient client = null)
    {
      var options = new CreatePhoneNumberOptions(pathServiceSid) { Sid = sid, PhoneNumber = phoneNumber, IsReserved = isReserved };
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// Add a Phone Number to a Service's Proxy Number Pool.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the resource's parent Service </param>
    /// <param name="sid"> The SID of a Twilio IncomingPhoneNumber resource </param>
    /// <param name="phoneNumber"> The phone number in E.164 format </param>
    /// <param name="isReserved"> Whether the new phone number should be reserved </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(string pathServiceSid,
                                                                                     string sid = null,
                                                                                     Types.PhoneNumber phoneNumber = null,
                                                                                     bool? isReserved = null,
                                                                                     ITwilioRestClient client = null)
    {
      var options = new CreatePhoneNumberOptions(pathServiceSid) { Sid = sid, PhoneNumber = phoneNumber, IsReserved = isReserved };
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeletePhoneNumberOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Proxy,
          "/v1/Services/" + options.PathServiceSid + "/PhoneNumbers/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Delete a specific Phone Number from a Service.
    /// </summary>
    /// <param name="options"> Delete PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static bool Delete(DeletePhoneNumberOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// Delete a specific Phone Number from a Service.
    /// </summary>
    /// <param name="options"> Delete PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePhoneNumberOptions options,
                                                                      ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }
#endif

    /// <summary>
    /// Delete a specific Phone Number from a Service.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to delete </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeletePhoneNumberOptions(pathServiceSid, pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// Delete a specific Phone Number from a Service.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to delete </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid,
                                                                      string pathSid,
                                                                      ITwilioRestClient client = null)
    {
      var options = new DeletePhoneNumberOptions(pathServiceSid, pathSid);
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadPhoneNumberOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Proxy,
          "/v1/Services/" + options.PathServiceSid + "/PhoneNumbers",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Retrieve a list of all Phone Numbers in the Proxy Number Pool for a Service. A maximum of 100 records will be
    /// returned per page.
    /// </summary>
    /// <param name="options"> Read PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static ResourceSet<PhoneNumberResource> Read(ReadPhoneNumberOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
      return new ResourceSet<PhoneNumberResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of all Phone Numbers in the Proxy Number Pool for a Service. A maximum of 100 records will be
    /// returned per page.
    /// </summary>
    /// <param name="options"> Read PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(ReadPhoneNumberOptions options,
                                                                                                ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
      return new ResourceSet<PhoneNumberResource>(page, options, client);
    }
#endif

    /// <summary>
    /// Retrieve a list of all Phone Numbers in the Proxy Number Pool for a Service. A maximum of 100 records will be
    /// returned per page.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static ResourceSet<PhoneNumberResource> Read(string pathServiceSid,
                                                        int? pageSize = null,
                                                        long? limit = null,
                                                        ITwilioRestClient client = null)
    {
      var options = new ReadPhoneNumberOptions(pathServiceSid) { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of all Phone Numbers in the Proxy Number Pool for a Service. A maximum of 100 records will be
    /// returned per page.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to read </param>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(string pathServiceSid,
                                                                                                int? pageSize = null,
                                                                                                long? limit = null,
                                                                                                ITwilioRestClient client = null)
    {
      var options = new ReadPhoneNumberOptions(pathServiceSid) { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<PhoneNumberResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<PhoneNumberResource> NextPage(Page<PhoneNumberResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Proxy)
      );

      var response = client.Request(request);
      return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<PhoneNumberResource> PreviousPage(Page<PhoneNumberResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Proxy)
      );

      var response = client.Request(request);
      return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
    }

    private static Request BuildFetchRequest(FetchPhoneNumberOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Proxy,
          "/v1/Services/" + options.PathServiceSid + "/PhoneNumbers/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Fetch a specific Phone Number.
    /// </summary>
    /// <param name="options"> Fetch PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Fetch(FetchPhoneNumberOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Fetch a specific Phone Number.
    /// </summary>
    /// <param name="options"> Fetch PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(FetchPhoneNumberOptions options,
                                                                                    ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Fetch a specific Phone Number.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to fetch </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Fetch(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchPhoneNumberOptions(pathServiceSid, pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Fetch a specific Phone Number.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to fetch </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(string pathServiceSid,
                                                                                    string pathSid,
                                                                                    ITwilioRestClient client = null)
    {
      var options = new FetchPhoneNumberOptions(pathServiceSid, pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildUpdateRequest(UpdatePhoneNumberOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Proxy,
          "/v1/Services/" + options.PathServiceSid + "/PhoneNumbers/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Update a specific Proxy Number.
    /// </summary>
    /// <param name="options"> Update PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Update(UpdatePhoneNumberOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Update a specific Proxy Number.
    /// </summary>
    /// <param name="options"> Update PhoneNumber parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> UpdateAsync(UpdatePhoneNumberOptions options,
                                                                                     ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Update a specific Proxy Number.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to update </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="isReserved"> Whether the new phone number should be reserved </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of PhoneNumber </returns>
    public static PhoneNumberResource Update(string pathServiceSid,
                                             string pathSid,
                                             bool? isReserved = null,
                                             ITwilioRestClient client = null)
    {
      var options = new UpdatePhoneNumberOptions(pathServiceSid, pathSid) { IsReserved = isReserved };
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// Update a specific Proxy Number.
    /// </summary>
    /// <param name="pathServiceSid"> The SID of the parent Service resource of the PhoneNumber resource to update </param>
    /// <param name="pathSid"> The unique string that identifies the resource </param>
    /// <param name="isReserved"> Whether the new phone number should be reserved </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
    public static async System.Threading.Tasks.Task<PhoneNumberResource> UpdateAsync(string pathServiceSid,
                                                                                     string pathSid,
                                                                                     bool? isReserved = null,
                                                                                     ITwilioRestClient client = null)
    {
      var options = new UpdatePhoneNumberOptions(pathServiceSid, pathSid) { IsReserved = isReserved };
      return await UpdateAsync(options, client);
    }
#endif

    /// <summary>
    /// Converts a JSON string into a PhoneNumberResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> PhoneNumberResource object represented by the provided JSON </returns>
    public static PhoneNumberResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
      }
      catch (JsonException e)
      {
        throw new ApiException(e.Message, e);
      }
    }

    /// <summary>
    /// The unique string that identifies the resource
    /// </summary>
    [JsonProperty("sid")]
    public string Sid { get; private set; }
    /// <summary>
    /// The SID of the Account that created the resource
    /// </summary>
    [JsonProperty("account_sid")]
    public string AccountSid { get; private set; }
    /// <summary>
    /// The SID of the PhoneNumber resource's parent Service resource
    /// </summary>
    [JsonProperty("service_sid")]
    public string ServiceSid { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was created
    /// </summary>
    [JsonProperty("date_created")]
    public DateTime? DateCreated { get; private set; }
    /// <summary>
    /// The ISO 8601 date and time in GMT when the resource was last updated
    /// </summary>
    [JsonProperty("date_updated")]
    public DateTime? DateUpdated { get; private set; }
    /// <summary>
    /// The phone number in E.164 format
    /// </summary>
    [JsonProperty("phone_number")]
    [JsonConverter(typeof(PhoneNumberConverter))]
    public Types.PhoneNumber PhoneNumber { get; private set; }
    /// <summary>
    /// The string that you assigned to describe the resource
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The ISO Country Code
    /// </summary>
    [JsonProperty("iso_country")]
    public string IsoCountry { get; private set; }
    /// <summary>
    /// The capabilities of the phone number
    /// </summary>
    [JsonProperty("capabilities")]
    public PhoneNumberCapabilities Capabilities { get; private set; }
    /// <summary>
    /// The absolute URL of the PhoneNumber resource
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }
    /// <summary>
    /// Reserve the phone number for manual assignment to participants only
    /// </summary>
    [JsonProperty("is_reserved")]
    public bool? IsReserved { get; private set; }
    /// <summary>
    /// The number of open session assigned to the number.
    /// </summary>
    [JsonProperty("in_use")]
    public int? InUse { get; private set; }

    private PhoneNumberResource()
    {

    }
  }

}
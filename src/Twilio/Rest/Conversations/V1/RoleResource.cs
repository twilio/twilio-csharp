/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// RoleResource
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

namespace Twilio.Rest.Conversations.V1
{

  public class RoleResource : Resource
  {
    public sealed class RoleTypeEnum : StringEnum
    {
      private RoleTypeEnum(string value) : base(value) { }
      public RoleTypeEnum() { }
      public static implicit operator RoleTypeEnum(string value)
      {
        return new RoleTypeEnum(value);
      }

      public static readonly RoleTypeEnum Conversation = new RoleTypeEnum("conversation");
      public static readonly RoleTypeEnum Service = new RoleTypeEnum("service");
    }

    private static Request BuildCreateRequest(CreateRoleOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Conversations,
          "/v1/Roles",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Create a new user role in your account's default service
    /// </summary>
    /// <param name="options"> Create Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Create(CreateRoleOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Create a new user role in your account's default service
    /// </summary>
    /// <param name="options"> Create Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(CreateRoleOptions options,
                                                                              ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildCreateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Create a new user role in your account's default service
    /// </summary>
    /// <param name="friendlyName"> A string to describe the new resource </param>
    /// <param name="type"> The type of role </param>
    /// <param name="permission"> A permission the role should have </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Create(string friendlyName,
                                      RoleResource.RoleTypeEnum type,
                                      List<string> permission,
                                      ITwilioRestClient client = null)
    {
      var options = new CreateRoleOptions(friendlyName, type, permission);
      return Create(options, client);
    }

#if !NET35
    /// <summary>
    /// Create a new user role in your account's default service
    /// </summary>
    /// <param name="friendlyName"> A string to describe the new resource </param>
    /// <param name="type"> The type of role </param>
    /// <param name="permission"> A permission the role should have </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(string friendlyName,
                                                                              RoleResource.RoleTypeEnum type,
                                                                              List<string> permission,
                                                                              ITwilioRestClient client = null)
    {
      var options = new CreateRoleOptions(friendlyName, type, permission);
      return await CreateAsync(options, client);
    }
#endif

    private static Request BuildUpdateRequest(UpdateRoleOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Post,
          Rest.Domain.Conversations,
          "/v1/Roles/" + options.PathSid + "",
          postParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Update an existing user role in your account's default service
    /// </summary>
    /// <param name="options"> Update Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Update(UpdateRoleOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Update an existing user role in your account's default service
    /// </summary>
    /// <param name="options"> Update Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(UpdateRoleOptions options,
                                                                              ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildUpdateRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Update an existing user role in your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to update </param>
    /// <param name="permission"> A permission the role should have </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Update(string pathSid, List<string> permission, ITwilioRestClient client = null)
    {
      var options = new UpdateRoleOptions(pathSid, permission);
      return Update(options, client);
    }

#if !NET35
    /// <summary>
    /// Update an existing user role in your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to update </param>
    /// <param name="permission"> A permission the role should have </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(string pathSid,
                                                                              List<string> permission,
                                                                              ITwilioRestClient client = null)
    {
      var options = new UpdateRoleOptions(pathSid, permission);
      return await UpdateAsync(options, client);
    }
#endif

    private static Request BuildDeleteRequest(DeleteRoleOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Delete,
          Rest.Domain.Conversations,
          "/v1/Roles/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Remove a user role from your account's default service
    /// </summary>
    /// <param name="options"> Delete Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static bool Delete(DeleteRoleOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }

#if !NET35
    /// <summary>
    /// Remove a user role from your account's default service
    /// </summary>
    /// <param name="options"> Delete Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRoleOptions options,
                                                                      ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildDeleteRequest(options, client));
      return response.StatusCode == System.Net.HttpStatusCode.NoContent;
    }
#endif

    /// <summary>
    /// Remove a user role from your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static bool Delete(string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteRoleOptions(pathSid);
      return Delete(options, client);
    }

#if !NET35
    /// <summary>
    /// Remove a user role from your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to delete </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
    {
      var options = new DeleteRoleOptions(pathSid);
      return await DeleteAsync(options, client);
    }
#endif

    private static Request BuildFetchRequest(FetchRoleOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Conversations,
          "/v1/Roles/" + options.PathSid + "",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Fetch a user role from your account's default service
    /// </summary>
    /// <param name="options"> Fetch Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Fetch(FetchRoleOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }

#if !NET35
    /// <summary>
    /// Fetch a user role from your account's default service
    /// </summary>
    /// <param name="options"> Fetch Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(FetchRoleOptions options,
                                                                             ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildFetchRequest(options, client));
      return FromJson(response.Content);
    }
#endif

    /// <summary>
    /// Fetch a user role from your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static RoleResource Fetch(string pathSid, ITwilioRestClient client = null)
    {
      var options = new FetchRoleOptions(pathSid);
      return Fetch(options, client);
    }

#if !NET35
    /// <summary>
    /// Fetch a user role from your account's default service
    /// </summary>
    /// <param name="pathSid"> The SID of the Role resource to fetch </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(string pathSid,
                                                                             ITwilioRestClient client = null)
    {
      var options = new FetchRoleOptions(pathSid);
      return await FetchAsync(options, client);
    }
#endif

    private static Request BuildReadRequest(ReadRoleOptions options, ITwilioRestClient client)
    {
      return new Request(
          HttpMethod.Get,
          Rest.Domain.Conversations,
          "/v1/Roles",
          queryParams: options.GetParams(),
          headerParams: null
      );
    }

    /// <summary>
    /// Retrieve a list of all user roles in your account's default service
    /// </summary>
    /// <param name="options"> Read Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static ResourceSet<RoleResource> Read(ReadRoleOptions options, ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = client.Request(BuildReadRequest(options, client));

      var page = Page<RoleResource>.FromJson("roles", response.Content);
      return new ResourceSet<RoleResource>(page, options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of all user roles in your account's default service
    /// </summary>
    /// <param name="options"> Read Role parameters </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(ReadRoleOptions options,
                                                                                         ITwilioRestClient client = null)
    {
      client = client ?? TwilioClient.GetRestClient();
      var response = await client.RequestAsync(BuildReadRequest(options, client));

      var page = Page<RoleResource>.FromJson("roles", response.Content);
      return new ResourceSet<RoleResource>(page, options, client);
    }
#endif

    /// <summary>
    /// Retrieve a list of all user roles in your account's default service
    /// </summary>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> A single instance of Role </returns>
    public static ResourceSet<RoleResource> Read(int? pageSize = null,
                                                 long? limit = null,
                                                 ITwilioRestClient client = null)
    {
      var options = new ReadRoleOptions() { PageSize = pageSize, Limit = limit };
      return Read(options, client);
    }

#if !NET35
    /// <summary>
    /// Retrieve a list of all user roles in your account's default service
    /// </summary>
    /// <param name="pageSize"> Page size </param>
    /// <param name="limit"> Record limit </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> Task that resolves to A single instance of Role </returns>
    public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(int? pageSize = null,
                                                                                         long? limit = null,
                                                                                         ITwilioRestClient client = null)
    {
      var options = new ReadRoleOptions() { PageSize = pageSize, Limit = limit };
      return await ReadAsync(options, client);
    }
#endif

    /// <summary>
    /// Fetch the target page of records
    /// </summary>
    /// <param name="targetUrl"> API-generated URL for the requested results page </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The target page of records </returns>
    public static Page<RoleResource> GetPage(string targetUrl, ITwilioRestClient client)
    {
      client = client ?? TwilioClient.GetRestClient();

      var request = new Request(
          HttpMethod.Get,
          targetUrl
      );

      var response = client.Request(request);
      return Page<RoleResource>.FromJson("roles", response.Content);
    }

    /// <summary>
    /// Fetch the next page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The next page of records </returns>
    public static Page<RoleResource> NextPage(Page<RoleResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetNextPageUrl(Rest.Domain.Conversations)
      );

      var response = client.Request(request);
      return Page<RoleResource>.FromJson("roles", response.Content);
    }

    /// <summary>
    /// Fetch the previous page of records
    /// </summary>
    /// <param name="page"> current page of records </param>
    /// <param name="client"> Client to make requests to Twilio </param>
    /// <returns> The previous page of records </returns>
    public static Page<RoleResource> PreviousPage(Page<RoleResource> page, ITwilioRestClient client)
    {
      var request = new Request(
          HttpMethod.Get,
          page.GetPreviousPageUrl(Rest.Domain.Conversations)
      );

      var response = client.Request(request);
      return Page<RoleResource>.FromJson("roles", response.Content);
    }

    /// <summary>
    /// Converts a JSON string into a RoleResource object
    /// </summary>
    /// <param name="json"> Raw JSON string </param>
    /// <returns> RoleResource object represented by the provided JSON </returns>
    public static RoleResource FromJson(string json)
    {
      // Convert all checked exceptions to Runtime
      try
      {
        return JsonConvert.DeserializeObject<RoleResource>(json);
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
    /// The SID of the Conversation Service that the resource is associated with
    /// </summary>
    [JsonProperty("chat_service_sid")]
    public string ChatServiceSid { get; private set; }
    /// <summary>
    /// The string that you assigned to describe the resource
    /// </summary>
    [JsonProperty("friendly_name")]
    public string FriendlyName { get; private set; }
    /// <summary>
    /// The type of role
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public RoleResource.RoleTypeEnum Type { get; private set; }
    /// <summary>
    /// An array of the permissions the role has been granted
    /// </summary>
    [JsonProperty("permissions")]
    public List<string> Permissions { get; private set; }
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
    /// An absolute URL for this user role.
    /// </summary>
    [JsonProperty("url")]
    public Uri Url { get; private set; }

    private RoleResource()
    {

    }
  }

}
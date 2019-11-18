/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Chat.V2.Service
{

    /// <summary>
    /// FetchUserOptions
    /// </summary>
    public class FetchUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the Service to fetch the resource from
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The SID of the User resource to fetch
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchUserOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the resource from </param>
        /// <param name="pathSid"> The SID of the User resource to fetch </param>
        public FetchUserOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    /// DeleteUserOptions
    /// </summary>
    public class DeleteUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the Service to delete the resource from
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The SID of  the User resource to delete
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteUserOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the resource from </param>
        /// <param name="pathSid"> The SID of  the User resource to delete </param>
        public DeleteUserOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    /// CreateUserOptions
    /// </summary>
    public class CreateUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the Service to create the new resource under
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The `identity` value that identifies the new resource's User
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// The SID of the Role assigned to this user
        /// </summary>
        public string RoleSid { get; set; }
        /// <summary>
        /// A valid JSON string that contains application-specific data
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// A string to describe the new resource
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The X-Twilio-Webhook-Enabled HTTP request header
        /// </summary>
        public UserResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; }

        /// <summary>
        /// Construct a new CreateUserOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the new resource under </param>
        /// <param name="identity"> The `identity` value that identifies the new resource's User </param>
        public CreateUserOptions(string pathServiceSid, string identity)
        {
            PathServiceSid = pathServiceSid;
            Identity = identity;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }

            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }

            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            return p;
        }
    }

    /// <summary>
    /// ReadUserOptions
    /// </summary>
    public class ReadUserOptions : ReadOptions<UserResource>
    {
        /// <summary>
        /// The SID of the Service to read the User resources from
        /// </summary>
        public string PathServiceSid { get; }

        /// <summary>
        /// Construct a new ReadUserOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the User resources from </param>
        public ReadUserOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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
    /// UpdateUserOptions
    /// </summary>
    public class UpdateUserOptions : IOptions<UserResource>
    {
        /// <summary>
        /// The SID of the Service to update the resource from
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The SID of the User resource to update
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The SID id of the Role assigned to this user
        /// </summary>
        public string RoleSid { get; set; }
        /// <summary>
        /// A valid JSON string that contains application-specific data
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// A string to describe the resource
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The X-Twilio-Webhook-Enabled HTTP request header
        /// </summary>
        public UserResource.WebhookEnabledTypeEnum XTwilioWebhookEnabled { get; }

        /// <summary>
        /// Construct a new UpdateUserOptions
        /// </summary>
        /// <param name="pathServiceSid"> The SID of the Service to update the resource from </param>
        /// <param name="pathSid"> The SID of the User resource to update </param>
        public UpdateUserOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (RoleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("RoleSid", RoleSid.ToString()));
            }

            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            return p;
        }
    }

}
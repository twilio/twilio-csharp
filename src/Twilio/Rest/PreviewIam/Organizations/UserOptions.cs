/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Organization Public API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.PreviewIam.Organizations
{

    /// <summary> create </summary>
    public class CreateUserOptions : IOptions<UserResource>
    {
        
        
        public string PathOrganizationSid { get; }

        
        public UserResource.ScimUser ScimUser { get; }


        /// <summary> Construct a new CreateOrganizationUserOptions </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="scimUser">  </param>
        public CreateUserOptions(string pathOrganizationSid, UserResource.ScimUser scimUser)
        {
            PathOrganizationSid = pathOrganizationSid;
            ScimUser = scimUser;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (ScimUser != null)
            {
                body = UserResource.ToJson(ScimUser);
            }
            return body;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteUserOptions : IOptions<UserResource>
    {
        
        
        public string PathOrganizationSid { get; }

        
        public string PathUserSid { get; }



        /// <summary> Construct a new DeleteOrganizationUserOptions </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pathUserSid">  </param>
        public DeleteUserOptions(string pathOrganizationSid, string pathUserSid)
        {
            PathOrganizationSid = pathOrganizationSid;
            PathUserSid = pathUserSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> fetch </summary>
    public class FetchUserOptions : IOptions<UserResource>
    {
    
        
        public string PathOrganizationSid { get; }

        
        public string PathUserSid { get; }



        /// <summary> Construct a new FetchOrganizationUserOptions </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pathUserSid">  </param>
        public FetchUserOptions(string pathOrganizationSid, string pathUserSid)
        {
            PathOrganizationSid = pathOrganizationSid;
            PathUserSid = pathUserSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> read </summary>
    public class ReadUserOptions : ReadOptions<UserResource>
    {
    
        
        public string PathOrganizationSid { get; }

        
        public string Filter { get; set; }



        /// <summary> Construct a new ListOrganizationUsersOptions </summary>
        /// <param name="pathOrganizationSid">  </param>
        public ReadUserOptions(string pathOrganizationSid)
        {
            PathOrganizationSid = pathOrganizationSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Filter != null)
            {
                p.Add(new KeyValuePair<string, string>("filter", Filter));
            }
            return p;
        }

    

    }

    /// <summary> update </summary>
    public class UpdateUserOptions : IOptions<UserResource>
    {
    
        
        public string PathOrganizationSid { get; }

        
        public string PathUserSid { get; }

        
        public UserResource.ScimUser ScimUser { get; }

        
        public string IfMatch { get; set; }



        /// <summary> Construct a new UpdateOrganizationUserOptions </summary>
        /// <param name="pathOrganizationSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="scimUser">  </param>
        public UpdateUserOptions(string pathOrganizationSid, string pathUserSid, UserResource.ScimUser scimUser)
        {
            PathOrganizationSid = pathOrganizationSid;
            PathUserSid = pathUserSid;
            ScimUser = scimUser;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (ScimUser != null)
            {
                body = UserResource.ToJson(ScimUser);
            }
            return body;
        }
        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (IfMatch != null)
        {
            p.Add(new KeyValuePair<string, string>("If-Match", IfMatch));
        }
        return p;
    }

    }


}


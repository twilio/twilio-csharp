/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Autopilot
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Autopilot.V1
{

    /// <summary> create </summary>
    public class CreateAssistantOptions : IOptions<AssistantResource>
    {
        
        ///<summary> A descriptive string that you create to describe the new resource. It is not unique and can be up to 255 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Whether queries should be logged and kept after training. Can be: `true` or `false` and defaults to `true`. If `true`, queries are stored for 30 days, and then deleted. If `false`, no queries are stored. </summary> 
        public bool? LogQueries { get; set; }

        ///<summary> An application-defined string that uniquely identifies the new resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </summary> 
        public string UniqueName { get; set; }

        ///<summary> Reserved. </summary> 
        public Uri CallbackUrl { get; set; }

        ///<summary> Reserved. </summary> 
        public string CallbackEvents { get; set; }

        ///<summary> The JSON string that defines the Assistant's [style sheet](https://www.twilio.com/docs/autopilot/api/assistant/stylesheet) </summary> 
        public object StyleSheet { get; set; }

        ///<summary> A JSON object that defines the Assistant's [default tasks](https://www.twilio.com/docs/autopilot/api/assistant/defaults) for various scenarios, including initiation actions and fallback tasks. </summary> 
        public object Defaults { get; set; }



        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (LogQueries != null)
            {
                p.Add(new KeyValuePair<string, string>("LogQueries", LogQueries.Value.ToString().ToLower()));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", Serializers.Url(CallbackUrl)));
            }
            if (CallbackEvents != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackEvents", CallbackEvents));
            }
            if (StyleSheet != null)
            {
                p.Add(new KeyValuePair<string, string>("StyleSheet", Serializers.JsonObject(StyleSheet)));
            }
            if (Defaults != null)
            {
                p.Add(new KeyValuePair<string, string>("Defaults", Serializers.JsonObject(Defaults)));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteAssistantOptions : IOptions<AssistantResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the Assistant resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteAssistantOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Assistant resource to delete. </param>

        public DeleteAssistantOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchAssistantOptions : IOptions<AssistantResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Assistant resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchAssistantOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Assistant resource to fetch. </param>

        public FetchAssistantOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadAssistantOptions : ReadOptions<AssistantResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> update </summary>
    public class UpdateAssistantOptions : IOptions<AssistantResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Assistant resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> Whether queries should be logged and kept after training. Can be: `true` or `false` and defaults to `true`. If `true`, queries are stored for 30 days, and then deleted. If `false`, no queries are stored. </summary> 
        public bool? LogQueries { get; set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used as an alternative to the `sid` in the URL path to address the resource. The first 64 characters must be unique. </summary> 
        public string UniqueName { get; set; }

        ///<summary> Reserved. </summary> 
        public Uri CallbackUrl { get; set; }

        ///<summary> Reserved. </summary> 
        public string CallbackEvents { get; set; }

        ///<summary> The JSON string that defines the Assistant's [style sheet](https://www.twilio.com/docs/autopilot/api/assistant/stylesheet) </summary> 
        public object StyleSheet { get; set; }

        ///<summary> A JSON object that defines the Assistant's [default tasks](https://www.twilio.com/docs/autopilot/api/assistant/defaults) for various scenarios, including initiation actions and fallback tasks. </summary> 
        public object Defaults { get; set; }

        ///<summary> A string describing the state of the assistant. </summary> 
        public string DevelopmentStage { get; set; }



        /// <summary> Construct a new UpdateAssistantOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Assistant resource to update. </param>

        public UpdateAssistantOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (LogQueries != null)
            {
                p.Add(new KeyValuePair<string, string>("LogQueries", LogQueries.Value.ToString().ToLower()));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (CallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackUrl", Serializers.Url(CallbackUrl)));
            }
            if (CallbackEvents != null)
            {
                p.Add(new KeyValuePair<string, string>("CallbackEvents", CallbackEvents));
            }
            if (StyleSheet != null)
            {
                p.Add(new KeyValuePair<string, string>("StyleSheet", Serializers.JsonObject(StyleSheet)));
            }
            if (Defaults != null)
            {
                p.Add(new KeyValuePair<string, string>("Defaults", Serializers.JsonObject(Defaults)));
            }
            if (DevelopmentStage != null)
            {
                p.Add(new KeyValuePair<string, string>("DevelopmentStage", DevelopmentStage));
            }
            return p;
        }
        

    }


}


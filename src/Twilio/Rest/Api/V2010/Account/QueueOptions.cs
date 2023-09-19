/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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




namespace Twilio.Rest.Api.V2010.Account
{

    /// <summary> Create a queue </summary>
    public class CreateQueueOptions : IOptions<QueueResource>
    {
        
        ///<summary> A descriptive string that you created to describe this resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> The maximum number of calls allowed to be in the queue. The default is 1000. The maximum is 5000. </summary> 
        public int? MaxSize { get; set; }


        /// <summary> Construct a new CreateQueueOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you created to describe this resource. It can be up to 64 characters long. </param>
        public CreateQueueOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (MaxSize != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> Remove an empty queue </summary>
    public class DeleteQueueOptions : IOptions<QueueResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the Queue resource to delete </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Queue resource to delete. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new DeleteQueueOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Queue resource to delete </param>
        public DeleteQueueOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Fetch an instance of a queue identified by the QueueSid </summary>
    public class FetchQueueOptions : IOptions<QueueResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Queue resource to fetch </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Queue resource to fetch. </summary> 
        public string PathAccountSid { get; set; }



        /// <summary> Construct a new FetchQueueOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Queue resource to fetch </param>
        public FetchQueueOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> Retrieve a list of queues belonging to the account used to make the request </summary>
    public class ReadQueueOptions : ReadOptions<QueueResource>
    {
    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Queue resources to read. </summary> 
        public string PathAccountSid { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> Update the queue with the new parameters </summary>
    public class UpdateQueueOptions : IOptions<QueueResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the Queue resource to update </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Queue resource to update. </summary> 
        public string PathAccountSid { get; set; }

        ///<summary> A descriptive string that you created to describe this resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The maximum number of calls allowed to be in the queue. The default is 1000. The maximum is 5000. </summary> 
        public int? MaxSize { get; set; }



        /// <summary> Construct a new UpdateQueueOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Queue resource to update </param>
        public UpdateQueueOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (MaxSize != null)
            {
                p.Add(new KeyValuePair<string, string>("MaxSize", MaxSize.ToString()));
            }
            return p;
        }
        

    }


}


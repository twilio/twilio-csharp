/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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




namespace Twilio.Rest.Numbers.V2
{

    /// <summary> Host multiple phone numbers on Twilio's platform. </summary>
    public class CreateBulkHostedNumberOrderOptions : IOptions<BulkHostedNumberOrderResource>
    {
        


        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

        

    }
    /// <summary> Fetch a specific BulkHostedNumberOrder. </summary>
    public class FetchBulkHostedNumberOrderOptions : IOptions<BulkHostedNumberOrderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this BulkHostedNumberOrder. </summary> 
        public string PathBulkHostingSid { get; }

        ///<summary> Order status can be used for filtering on Hosted Number Order status values. To see a complete list of order statuses, please check 'https://www.twilio.com/docs/phone-numbers/hosted-numbers/hosted-numbers-api/hosted-number-order-resource#status-values'. </summary> 
        public string OrderStatus { get; set; }



        /// <summary> Construct a new FetchBulkHostedNumberOrderOptions </summary>
        /// <param name="pathBulkHostingSid"> A 34 character string that uniquely identifies this BulkHostedNumberOrder. </param>
        public FetchBulkHostedNumberOrderOptions(string pathBulkHostingSid)
        {
            PathBulkHostingSid = pathBulkHostingSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (OrderStatus != null)
            {
                p.Add(new KeyValuePair<string, string>("OrderStatus", OrderStatus));
            }
            return p;
        }

        

    }


}


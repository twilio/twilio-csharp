/*
 * Example: ListRecordings
 * Description: Get a list of audio recordings for a certain call, HTTP GET
 * Author: Twilio, Inc. <help@twilio.com>
 */

using System;
using System.Collections;

using TwilioRest;

class ListRecordings
{
    // Twilio REST API version
    const string API_VERSION = "2010-04-01";
    
    // Twilio AccountSid and AuthToken
    const string ACCOUNT_SID = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    const string ACCOUNT_TOKEN = "YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY";
    
    // Outgoing Caller ID previously validated with Twilio
    const string CALLER_ID = "NNNNNNNNNN";
    
    static void Main(string[] args)
    {
        TwilioRest.Account account;
        Hashtable h;
        
        // Create Twilio REST account object using Twilio account ID and token
        account = new TwilioRest.Account(ACCOUNT_SID, ACCOUNT_TOKEN);
        
        try
        {
            h = new Hashtable();
            h.Add("CallSid", "CAb30903a698e2fcd5ea2ea776078686f4");
            Console.WriteLine(account.request(
                                              String.Format("/{0}/Accounts/{1}/Recordings", 
                                                            API_VERSION, ACCOUNT_SID), "GET", h));
        }
        catch(TwilioRestException e)
        {
            Console.WriteLine("An error occurred: {0}", e.Message);
        }
        
    }
}

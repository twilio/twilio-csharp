/*
 * Example: DeleteRecordings
 * Description: Delete a specific recording, HTTP DELETE
 * Author: Twilio, Inc. <help@twilio.com>
 */

using System;
using System.Collections;

using TwilioRest;

class DeleteRecordings
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
        
        // Create Twilio REST account object using Twilio account ID and token
        account = new TwilioRest.Account(ACCOUNT_SID, ACCOUNT_TOKEN);
        
        try
        {
            Console.WriteLine(account.request(String.Format(
                                                            "/{0}/Accounts/{1}/Recordings/RE67147f4464d55f390577137b97fc3667", 
                                                            API_VERSION, ACCOUNT_SID), "DELETE"));
        }
        catch(TwilioRestException e)
        {
            Console.WriteLine("An error occurred: {0}", e.Message);
        }
        
    }
}
